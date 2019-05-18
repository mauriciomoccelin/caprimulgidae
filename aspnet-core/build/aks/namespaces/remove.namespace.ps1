param(
  [Parameter(Mandatory=$true)][string]$Namespace
)

$Namespaces = "Development", "Staging", "Production", "Database"

function DeleteNamespace {
  param (
    $Namespace
  )
  kubectl delete namespace $Namespace.ToLower()
}

if ($Namespace -eq "All") {
  foreach ($n in $Namespaces) { DeleteNamespace($n) } 
}
elseif ($Namespaces.Contains($Namespace)) {
  DeleteNamespace($Namespace)
}
else {
  Write-Host "Namespace inválido, tente All ou specifice: opções"
  $Namespaces | Select-Object | Format-Table -AutoSize
}