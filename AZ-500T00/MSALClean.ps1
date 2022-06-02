Import-Module -Name 'MSAL.PS'

$MSAL = @{
    TenantId = 'ddd8f7b5-8453-4ae8-b08a-2641f1c24d0b'
    ClientId = '8b9df025-46d5-4c6e-9cb4-b1a9fa6ef3ab'
    ClientSecret = ConvertTo-SecureString 'f0~8Q~SZG6tM.nqmO.wEtBv_kfredGUpjrs1RcJ8' -AsPlainText -Force
}
$Token = (Get-MsalToken @MSAL).AccessToken

$Graph = @{
    Method = 'Get'
    Uri = 'https://graph.microsoft.com/v1.0/groups'
    Headers = @{Authorization = "Bearer $($Token)"}
}

$groups = (Invoke-RestMethod @Graph).value
$groups | Select-Object displayName