# cbw
C# Basic API endpoints. 

This project provides a C# READ ONLY backend API server that connects to a PostgreSQL database created by my dmart project, 
https://github.com/daveswork/dmart . 


The database context and models were imported using 

```
Scaffold-DbContext "Name=ConnectionStrings:DefaultConnection" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models -ContextDir Data
```

Full documentation available here:
https://learn.microsoft.com/en-us/ef/core/cli/powershell#scaffold-dbcontext



## 


### Operating system changes/updates:
Requirements to run on :
```
Amazon Linux 2023.6.20250218
```

Run the following commands as a privilidged user:

```
dnf update
dnf install dotnet-sdk-8.0
dnf install dotnet-runtime-8.0
```

### Application dependencies.
Required NuGet packages:
```
Microsoft.EntityFrameworkCore Version=8.0.13

Microsoft.EntityFrameworkCore.Tools Version=8.0.13

Npgsql.EntityFrameworkCore.PostgreSQL Version=8.0.11
```

### Application configuration Updates. 
Update the application.json file with the following:

A connection string, such as:
```
"ConnectionStrings": {
    "DefaultConnection": "Server=serverFQDNorIP; Port=5432; Database=dmartdb; Userid=myappuser; Password=myappuserpassword;"

```

A url, to keep the port consistent and avoid changing the firewall rules with each run.

```
"urls":"http://0.0.0.0:5187"
```


### To launch a development build.

From within the project folder run the following command:
```
dotnet run
```
