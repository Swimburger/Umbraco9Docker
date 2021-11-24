#!/bin/bash
echo -n Enter Umbraco database connection string: 
read -s umbracoDbDSN
docker run --rm -it -p 80:80 \
    --mount type=bind,source="$(pwd)/wwwroot/media",destination=/app/wwwroot/media \
    umbraco9-image:latest ConnectionStrings:umbracoDbDSN="$umbracoDbDSN"