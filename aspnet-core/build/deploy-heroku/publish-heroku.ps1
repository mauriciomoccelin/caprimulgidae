function Get-Base-Path {
    cd ..
    cd ..
    return Get-Location
}

function Build-App {
    Notification "Gerando Arquivos para publicação ..."
    Set-Location $app_path
    dotnet publish --configuration Release --output $deploy_path_temp --verbosity quiet
    Get-ChildItem -Path $deploy_path_temp -Filter "*.pdb" -Recurse | foreach { Remove-Item -Path $_.FullName }
    Ok
}

function Publish-On-Heroku {
    Notification "Publicando imagem no Heroku: $deployment_name ..."
    Set-Location $deploy_path_temp
    Copy-Item "$deploy_path\Dockerfile" -Destination $deploy_path_temp
    heroku container:login
    heroku container:push web --app $deployment_name
    heroku container:release web --app $deployment_name
    Ok
}

function Finish {
    Notification "Removendo arquivos temporários ..."
    Set-Location $deploy_path
    Remove-Item $deploy_path_temp -Recurse
    Ok
    heroku open --app $deployment_name
}

function Notification {
    Param($message)
    Write-Host $message -ForegroundColor White -BackGroundColor Magenta
}

function Ok {
    Write-Host "Ok" -ForegroundColor White -BackGroundColor Green
}

$base_path = Get-Base-Path
$deploy_path = "$base_path\build\deploy-heroku"
$deploy_path_temp = "$base_path\build\deploy-heroku\temp"
$app_path = "$base_path\src\Caprimulgidae.WebApi"
$deployment_name = "caprimuldidae"

Build-App
Publish-On-Heroku
Finish