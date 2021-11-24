#!/bin/bash
echo -n Enter Umbraco database connection string: 
read -s umbracoDbDSN
mediaPath="$(pwd)/wwwroot/media"
echo 
echo Executing docker run

docker run --rm -it -p 80:80 \
    -v media-volume:"$mediaPath": \
    --mount type=bind,source=$mediaPath,destination=/app/wwwroot/media \
    umbraco9-image:latest ConnectionStrings__umbracoDbDSN=$umbracoDbDSN