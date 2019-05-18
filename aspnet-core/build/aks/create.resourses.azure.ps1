$AZ_GROUP = "GROUP_CAPRIMULDIDAE"
$ACR_NAME = "ACRCAPRIMULDIDAE"
$AKS_CLUSTER = "CLUSTERCAPRIMULDIDAE"

az login -u 'mauricio.moccelin@keyworks.com.br' -p 'Kokinho4$'

az group create --name $AZ_GROUP --location eastus

az acr create --resource-group $AZ_GROUP --name $ACR_NAME --sku Basic
az acr update -n $AZ_GROUP --admin-enabled true

# Needs permission: "AZURE KUBERNETES SERVICE CLUSTER USER ROLE"
az aks create --resource-group $AZ_GROUP --name $AKS_CLUSTER --node-count 1 --enable-addons monitoring --generate-ssh-keys

az aks get-credentials --resource-group $AZ_GROUP --name $AKS_CLUSTER
