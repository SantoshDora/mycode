#$url = "https://github.com/SantoshDora/mycode/addExtension.exe"
#$output = "$PSScriptRoot\addExtension.exe"

$url = "https://github.com/SantoshDora/mycode/archive/master.zip"
$output = "$PSScriptRoot\master.zip"



$start_time = Get-Date

[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

Invoke-WebRequest -Uri $url -OutFile $output
Write-Output "Time taken: $((Get-Date).Subtract($start_time).Seconds) second(s)"

Write-Output "Time taken: $((Get-Date).Subtract($start_time).Seconds) second(s)"

Add-Type -AssemblyName System.IO.Compression.FileSystem
function Unzip
{
    param([string]$zipfile, [string]$outpath)

    [System.IO.Compression.ZipFile]::ExtractToDirectory($zipfile, $outpath)
}

Unzip "$PSScriptRoot\master.zip" "$PSScriptRoot"

$path = "$PSScriptRoot\mycode-master"

#explorer.exe $path

$fileExe = $path + "\addExtension.exe"
& $fileExe

