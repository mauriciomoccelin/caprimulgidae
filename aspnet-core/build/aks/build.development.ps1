[string]$pathBuild = Get-Location
[string]$pathApp = "..\..\"
[string]$imageDocker = "caprimuldidae/deployment:latest"

Clear-Host
docker rmi $(docker images --filter "dangling=true" -q --no-trunc) -f
# build image docker
Set-Location $pathApp
docker build --no-cache -t $imageDocker .

# deploy on kubernets
Set-Location $pathBuild
kubectl apply -n development -f "development.yaml"

Set-Location $pathBuild