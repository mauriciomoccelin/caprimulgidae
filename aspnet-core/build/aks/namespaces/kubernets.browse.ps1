$AZ_GROUP = "GROUP_CAPRIMULDIDAE"
$AKS_CLUSTER = "CLUSTERCAPRIMULDIDAE"

az aks browse --resource-group $AZ_GROUP --name $AKS_CLUSTER

# Para clusters habilitados para RBAC
# kubectl create clusterrolebinding kubernetes-dashboard --clusterrole=cluster-admin --serviceaccount=kube-system:kubernetes-dashboard
# az aks browse --resource-group GROUP_CAPRIMULDIDAE --name CLUSTERCAPRIMULDIDAE
