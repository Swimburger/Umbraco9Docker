using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Umbraco9Docker
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    // /run/secrets/ is the default secrets path for Linux Docker containers
                    config.AddKeyPerFile(directoryPath: "/run/secrets/", optional: true);
                })
                .Build()
                .Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(x => x.ClearProviders())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
