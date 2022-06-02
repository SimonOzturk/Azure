Invoke-RestMethod -Method Get -Uri "https://jsonplaceholder.typicode.com/todos"

$BaseUri = [Uri]::new("https://jsonplaceholder.typicode.com/") 
$Request = @{
    Method      = 'Post' 
    Uri         = [uri]::new($BaseUri,"todos")
    Body        = '{"id":201,"title":"Simon","completed":false}' 
    ContentType = 'application/json'
}

Invoke-RestMethod @Request