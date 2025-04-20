

### crear carpeta
>- mkdir MyMicroservice
>- cd MyMicroservice

### crear solucion y proyectos
>- dotnet new sln -n MyMicroservice
>- dotnet new webapi -n MyMicroservice.API
>- dotnet new classlib -n MyMicroservice.Application
>- dotnet new classlib -n MyMicroservice.Domain
>- dotnet new classlib -n MyMicroservice.Infrastructure
>- dotnet new classlib -n MyMicroservice.GraphQL

### agregar proyectos a la solución
>- dotnet sln add **/*.csproj

### si no funciona
>- dotnet sln add MyMicroservice.API\MyMicroservice.API.csproj
>- 

# Referencias pendiente
>- dotnet add MyMicroservice.API reference MyMicroservice.Application MyMicroservice.GraphQL
>- dotnet add MyMicroservice.Application reference MyMicroservice.Domain
>- dotnet add MyMicroservice.Infrastructure reference MyMicroservice.Application MyMicroservice.Domain
>- dotnet add MyMicroservice.GraphQL reference MyMicroservice.Application MyMicroservice.Domain


>- dotnet add MyMicroservice.API reference MyMicroservice.Infrastructure 
>- dotnet add MyMicroservice.GraphQL reference MyMicroservice.Infrastructure


### 2. Instalar NuGet Packages
### En MyMicroservice.API:
>- cd MyMicroservice.API
>- dotnet add package Swashbuckle.AspNetCore
>- dotnet add package HotChocolate.AspNetCore
>- dotnet add MyMicroservice.API package Microsoft.EntityFrameworkCore.Design

### En MyMicroservice.Infrastructure:
>- cd MyMicroservice.Infrastructure
>- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
>- dotnet add package Microsoft.EntityFrameworkCore.Design



### En MyMicroservice.GraphQL:
>- dotnet add MyMicroservice.GraphQL package HotChocolate.AspNetCore


### comandos para generar tablas en base de datos
>- dotnet build MyMicroservice.sln
>- dotnet ef migrations add InitialCreate --project MyMicroservice.Infrastructure --startup-project MyMicroservice.API --output-dir Data/Migrations
>- dotnet ef database update --project MyMicroservice.Infrastructure --startup-project MyMicroservice.API
>- dotnet run --project MyMicroservice.API

>- dotnet ef migrations add UpdateTioToGuid --project MyMicroservice.Infrastructure --startup-project MyMicroservice.API --output-dir Data/Migrations
>- dotnet ef database update --project MyMicroservice.Infrastructure --startup-project MyMicroservice.API
>- dotnet run --project MyMicroservice.API

### pruebas unitarias
>- dotnet test MyMicroservice.Tests/MyMicroservice.Tests.csproj
>- dotnet new xunit -n MyMicroservice.Tests
>- dotnet sln add MyMicroservice.Tests/MyMicroservice.Tests.csproj
>- dotnet add MyMicroservice.Tests reference MyMicroservice.API
>- dotnet add MyMicroservice.Tests reference MyMicroservice.Infrastructure
>- dotnet add MyMicroservice.Tests package Moq
>- dotnet add MyMicroservice.Tests package FluentAssertions
>- dotnet add MyMicroservice.Tests package Microsoft.AspNetCore.Mvc.Testing
>- dotnet test ./MyMicroservice.Tests/MyMicroservice.Tests.csproj



### Swagger:
>- http://localhost:5062/swagger

### GraphQL:
>- ttp://localhost:5062/graphql

### Endpoint de prueba /weatherforecast:
>- http://localhost:5062/weatherforecast



