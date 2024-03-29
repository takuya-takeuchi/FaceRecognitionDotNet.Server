if (!(Test-Path ${env:JAVA_HOME}))
{
    Write-Host "[Error] env JAVA_HOME is empty or does not exist" -Foreground Red
    return
}

$java = Join-Path ${env:JAVA_HOME} "bin" | `
        Join-Path -Child "java"
if ($global:IsWindows)
{
    $java = $java + ".exe"
}

if (!(Test-Path ${java}))
{
    Write-Host "[Error] ${java} does not exist" -Foreground Red
    return
}

if ((Test-Path swagger.json))
{
    Write-Host "[Info] delete existing swagger.json" -Foreground Yellow
    Remove-Item swagger.json
}

# $openapiUrl = "https://oss.sonatype.org/content/repositories/snapshots/org/openapitools/openapi-generator-cli/5.0.0-SNAPSHOT/openapi-generator-cli-5.0.0-20201128.073749-892.jar"
$openapiUrl = "https://repo1.maven.org/maven2/org/openapitools/openapi-generator-cli/5.0.0-beta3/openapi-generator-cli-5.0.0-beta3.jar"
if (!(Test-Path "openapi-generator-cli.jar"))
{
    Write-Host "[Info] Download openapi-generator-cli.jar" -Foreground Yellow
    Invoke-WebRequest -Uri "${openapiUrl}" `
                      -outfile openapi-generator-cli.jar
}

Invoke-WebRequest -Uri "http://localhost:5000/swagger/v1/swagger.json" `
                  -outfile swagger.json

if (!(Test-Path swagger.json))
{
    Write-Host "[Error] swagger.json does not exist" -Foreground Red
    return
}

Write-Host "[Info] Succeed to get swagger.json" -Foreground Green

$current = Get-Location
$executable = Join-Path $current "openapi-generator-cli.jar"
$arguments = "generate " + 
             "-i swagger.json " + 
             "-g csharp-netcore " + 
             "-o FaceRecognitionDotNet.Client " + 
             "--additional-properties=netCoreProjectFile=true," + 
             "targetFramework=netstandard2.0," +
             "packageName=FaceRecognitionDotNet.Client"
Invoke-Expression "& '${java}' -jar ${executable} ${arguments}"
Remove-Item swagger.json