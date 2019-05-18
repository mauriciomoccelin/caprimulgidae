kubectl apply -n database -f "storage-class.json"
kubectl apply -n database -f "persistent-volume-claim.json"
kubectl apply -n database -f "deployment-sqlserver.json"
kubectl apply -n database -f "service-sqlserver.json"

kubectl get pods -n database

# kubectl delete -n database -f "storage-class.json"
# kubectl delete -n database -f "persistent-volume-claim.json"
# kubectl delete -n database -f "deployment-sqlserver.json"
# kubectl delete -n database -f "service-sqlserver.json"

# kubectl -n database exec -it sqlserver-56cdcd5dd4-swjp9 "bash"
#   /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P ''

# create database caprimulgidae_stg
# create database caprimulgidae_dev
# create database caprimulgidae_prod
# create database caprimulgidae_test