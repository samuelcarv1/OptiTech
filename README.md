# OptiTech

Projeto .NET Core com **Clean Architecture, DDD e EF Core**.  
API de vendas com cadastro de clientes, produtos, pedidos e controle de estoque, incluindo publicação e consumo de eventos via **RabbitMQ**.

---

## Tecnologias

- .NET Core 9  
- Entity Framework Core  
- SQL Server  
- RabbitMQ  
- Clean Architecture / DDD  

---

## Funcionalidades Implementadas

- **Cadastro de clientes**  
- **Criação de pedidos**  
- **Adição de produtos aos pedidos**  
- **Controle de estoque** com publicação de eventos `InventoryUpdatedEvent`  
- **Consumo de eventos de atualização de estoque** via RabbitMQ  
- **Logging de mensagens processadas**  
- **Mapper manual** entre entidades e DTOs  
- **Tratamento de exceções global** com middleware personalizado  

---

## Como rodar

1. Clone o repositório
2. Configure a string de conexão no `appsettings.json`
3. Rode as migrations:  
   ```bash
   dotnet ef database update --project ./Infrastructure/OptiTech.Infrastructure.csproj --startup-project ./API/OptiTech.API.csproj
4. Certifique-se de que o RabbitMQ está rodando:
   - Porta de comunicação: 5672
   - Painel de gerenciamento: http://localhost:15672/
5. Rode a aplicação:
6. ```bash
   dotnet run --project ./API/OptiTech.API.csproj

---
