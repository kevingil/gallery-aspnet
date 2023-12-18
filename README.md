# Image Gallery
Image gallery using ASP.NET MVC


This project uses the entity framework to connect to postgress, make sure your strings are setup correctly

```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
        "Default": "You PG database https://www.npgsql.org/efcore/"
    }
}
```

Database is setup with this schema

```sql
	id | imageurl | description | timestamp | rendertime | blurhash64
```
