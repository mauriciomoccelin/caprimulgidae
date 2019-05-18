[string]$pathBuild = Get-Location
[string]$pathBuildTemp = "$pathBuild\temp"
[string]$pathApp = "..\..\..\src\Caprimulgidae.WebApi"
[string]$imageDocker = "caprimuldidae/deployment:latest"

# build dotnet
Set-Location $pathApp
dotnet publish --configuration Release --output $pathBuildTemp --verbosity quiet
Get-ChildItem -Path $pathBuildTemp -Filter "*.pdb" -Recurse | Select-String { Remove-Item -Path $_.FullName }

# build image docker
Set-Location $pathBuildTemp
docker build -t $imageDocker .

Set-Location $pathBuild
kubectl apply -n development -f "deployment-development.json"
kubectl apply -n development -f "service-development.json"

# clear before build
# docker rmi $imageDocker
Remove-Item $pathBuildTemp -Recurse
Set-Location $pathBuild

kubectl get pods -n development

# kubectl delete -n development -f "service-development.json"
# kubectl delete -n development -f "deployment-development.json"