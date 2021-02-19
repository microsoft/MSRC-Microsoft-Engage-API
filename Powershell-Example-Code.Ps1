# Data model documentation at https://msrc.microsoft.com/report/developer
$body = Read-Host 'Insert JSON Body here'
Invoke-WebRequest -UseBasicParsing https://api.msrc.microsoft.com/report/v2.0/abuse -ContentType "application/json" -Method POST -Body $body
Read-Host -Prompt "Press Enter to Exit..."
