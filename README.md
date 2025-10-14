# OptiTech

Projeto .NET Core com Clean Architecture, DDD e EF Core. API de vendas com cadastro de clientes, produtos, pedidos e controle de estoque.

## Tecnologias

- .NET Core 9
- Entity Framework Core
- SQL Server
- AutoMapper (opcional)
- Clean Architecture / DDD

## Funcionalidades

- Cadastro de clientes
- Criação de pedidos
- Adição de produtos aos pedidos
- Controle de estoque

## Como rodar

1. Clone o repositório
2. Configure a string de conexão no `appsettings.json`
3. Rode as migrations:  
   ```bash
   dotnet ef database update --project ./Infrastructure/OptiTech.Infrastructure.csproj --startup-project ./API/OptiTech.API.csproj
