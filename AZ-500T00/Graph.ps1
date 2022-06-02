$OAuth = @{
    grant_type = "client_credentials"
    scope = "https://graph.microsoft.com/.default"
    client_id = "8b9df025-46d5-4c6e-9cb4-b1a9fa6ef3ab"
    client_secret = "f0~8Q~SZG6tM.nqmO.wEtBv_kfredGUpjrs1RcJ8"
}
$Url = "https://login.microsoftonline.com/ddd8f7b5-8453-4ae8-b08a-2641f1c24d0b/oauth2/v2.0/token"

$Token = (Invoke-RestMethod -Method Post -Uri $Url -Body $OAuth).access_token
$Token

$groups = (Invoke-RestMethod -Method Get -Uri "https://graph.microsoft.com/v1.0/groups" -Headers @{Authorization = "Bearer $($Token)"}).value
$groups | Select-Object displayName