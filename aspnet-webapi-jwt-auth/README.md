# ASP.net Core WebAPI 
## Jwt Based Auth Using Google 

- Configure Database in `appsettings.json`
```json
"PgSettings": {
    "Host": "",
    "Port": "",
    "User": "",
    "Database": ""
}
```
- Set Password && JWT Key
```sh
dotnet user-secrets set PgSettings:Password <Password>
dotnet user-secrets set JwtAuth:SecretKey <SECRET KEY>
dotnet user-secrets set URL:frontend <FRONTEND URL>
```

- Table for Database
```sql
CREATE TABLE IF NOT EXISTS users
(
    sub   VARCHAR(35) PRIMARY KEY,
    name  VARCHAR(100),
    email VARCHAR(100)
);
```