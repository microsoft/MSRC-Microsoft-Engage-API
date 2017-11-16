$key = Read-Host 'What is your API Key?'
$body = Read-Host 'Insert JSON Body here'
Invoke-WebRequest -UseBasicParsing https://api.msrc.microsoft.com/engagebeta/ssi? -ContentType "application/json" -Header @{ "api-key" = $key } -Method POST -Body $body
Read-Host -Prompt "Press Enter to Exit..."