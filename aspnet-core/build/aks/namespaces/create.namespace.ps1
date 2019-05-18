param(
  [Parameter(Mandatory=$true)][string]$Namespace
)

$Namespaces = @{
  "Development" = "namespace-development.json"
  "Staging" = "namespace-staging.json"
  "Production" = "namespace-production.json"
  "Database" = "namespace-database.json"
}

function CreateNamespace {
  param (
    $NamespaceFile
  )
  kubectl create -f "$(Get-Location)\$NamespaceFile"
}

if ($Namespace -eq "All") {
  foreach ($n in $Namespaces.Values) { CreateNamespace($n) }
}
elseif ($Namespaces.ContainsKey($Namespace)) {
  CreateNamespace($Namespaces[$Namespace])
}
else {
  Write-Host "Namespace ($Namespace) é inválido!" -BackgroundColor Red
  $Namespaces | Format-Table -AutoSize
}

kubectl get namespaces --show-labels | Select-String -Pattern "name="