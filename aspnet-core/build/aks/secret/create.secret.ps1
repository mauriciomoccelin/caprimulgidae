$ACR_USERNAME = 'ACRCAPRIMULDIDAE'
$ACR_PASSWORD = ''
$ANY_EMAIL_ADDRESS = 'mauriciomoccellin@hotmail.com'
$ACR_SERVER = 'https://acrcaprimuldidae.azurecr.io'
$ACR_SECRETE = 'acrcaprimuldidaekey'
$AKS_NAMESPACE = "staging"

kubectl delete secret $ACR_SECRETE 
kubectl -n $AKS_NAMESPACE create secret docker-registry $ACR_SECRETE --docker-server=$ACR_SERVER --docker-username=$ACR_USERNAME --docker-password=$ACR_PASSWORD --docker-email=$ANY_EMAIL_ADDRESS
