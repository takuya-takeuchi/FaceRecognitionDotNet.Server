# define env variables
Write-Host "define env variables" -Foreground Green
$env:POSTGRES_USER="admin"
$env:POSTGRES_PASSWORD="p@ssword123"
$env:POSTGRES_DB="FaceDatabase"
$env:PGADMIN_DEFAULT_EMAIL="root"
$env:PGADMIN_DEFAULT_PASSWORD="p@ssword123"

Write-Host "launch container" -Foreground Green
docker-compose up -d