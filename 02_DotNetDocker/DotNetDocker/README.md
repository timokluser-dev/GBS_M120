# DotNetDocker

```bash
docker-compose build --no-cache

docker-compose run app
```

## SDK standalone

to use the dotnet cli

```bash
docker run --rm -it -v $(pwd):/work mcr.microsoft.com/dotnet/sdk:5.0.404 bash

cd /work

dotnet new console --name DotNetDocker
```

_OR_

```bash
docker-compose run sdk
```
