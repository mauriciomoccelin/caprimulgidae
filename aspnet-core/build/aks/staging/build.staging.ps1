[string]$pathBuild = Get-Location
[string]$pathBuildTemp = "$pathBuild\temp"
[string]$pathApp = "..\..\..\src\Caprimulgidae.WebApi"
[string]$imageDocker = "acrcaprimuldidae.azurecr.io/caprimuldidaestg:latest"

$AZ_GROUP = "GROUP_CAPRIMULDIDAE"
$ACR_NAME = "ACRCAPRIMULDIDAE"
$ACR_SERVER = 'acrcaprimuldidae.azurecr.io'
$AKS_CLUSTER = "CLUSTERCAPRIMULDIDAE"
$ACR_USERNAME = 'ACRCAPRIMULDIDAE'
$ACR_PASSWORD = 'bXLYOhp9QOHDaSWSf/t5bZViUHK40e4M'

# build dotnet
Set-Location $pathApp
dotnet publish --configuration Release --output $pathBuildTemp --verbosity quiet
Get-ChildItem -Path $pathBuildTemp -Filter "*.pdb" -Recurse | Select-String { Remove-Item -Path $_.FullName }

# build image docker
Set-Location $pathBuildTemp
az acr login --name $ACR_NAME
docker login --password $ACR_PASSWORD --username $ACR_USERNAME $ACR_SERVER
docker build -t $imageDocker .
docker push $imageDocker
az acr repository list --name $ACR_NAME --output table

# apply on kubernets
Set-Location $pathBuild
az aks get-credentials --resource-group $AZ_GROUP --name $AKS_CLUSTER
kubectl apply -n staging -f "deployment-staging.json"
kubectl apply -n staging -f "service-staging.json"

# clear before build
docker rmi $imageDocker
Remove-Item $pathBuildTemp -Recurse
Set-Location $pathBuild

kubectl get pods -n staging

# kubectl delete -n staging -f "service-staging.json"
# kubectl delete -n staging -f "deployment-staging.json"
