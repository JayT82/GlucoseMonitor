# Azurite starten
Write-Host "🚀 Azurite Queue emulator wordt gestart..."
Start-Process -NoNewWindow `
    -FilePath "G:\Program Files\Microsoft Visual Studio\Common7\IDE\Extensions\Microsoft\Azure Storage Emulator\azurite.exe" `
    -ArgumentList "--queue --silent"
# Wacht tot Azurite op poort 10001 reageert (max 10 seconden)
$timeout = 10
$elapsed = 0
$port = 10001

do {
    $check = Test-NetConnection -ComputerName 127.0.0.1 -Port $port
    if ($check.TcpTestSucceeded) {
        Write-Host "✅ Azurite draait op poort $port"
        break
    } else {
        Start-Sleep -Seconds 1
        $elapsed++
    }
} while ($elapsed -lt $timeout)

if (-not $check.TcpTestSucceeded) {
    Write-Host "❌ Azurite is niet gestart binnen $timeout seconden"
    exit
}
Start-Sleep -Seconds 3

# Controle of poort 10001 actief is
$portCheck = Test-NetConnection -ComputerName 127.0.0.1 -Port 10001
if ($portCheck.TcpTestSucceeded) {
    Write-Host "✅ Azurite draait op poort 10001"
} else {
    Write-Host "❌ Azurite lijkt niet goed gestart (poort 10001 niet bereikbaar)"
    exit
}

# Start jouw WebAPI-project
Write-Host "🧠 Starten van GlucoseMonitor.API..."
Start-Process "dotnet" -ArgumentList "run --project src\GlucoseMonitor.API" -NoNewWindow

Write-Host "📡 WebAPI draait, Swagger bereikbaar zodra build gereed is."
