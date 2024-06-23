# EconoMe API

<img src="https://github.com/murilloliveiraz/EconoMe-BackEnd/blob/main/images/image.png" alt="Header da API">

EconoMe é uma API de controle financeiro desenvolvida com .NET. Esta API permite o gerenciamento de categorias de transações, títulos a pagar, títulos a receber e usuários, utilizando uma arquitetura baseada em Domain-Driven Design (DDD). A API utiliza Entity Framework para persistência de dados em um banco de dados PostgreSQL, AutoMapper para mapeamento de objetos, contratos para transporte seguro de dados e autenticação via tokens JWT. Além disso, implementa exceções personalizadas para melhor tratamento de erros.

## Funcionalidades

- **CRUD de Categorias de Transações (TransactionCategory)**
- **CRUD de Títulos a Pagar (Payment)**
- **CRUD de Títulos a Receber (Receivable)**
- **CRUD de Usuários (User)**

## Tecnologias Utilizadas

- .NET
- Domain-Driven Design (DDD)
- Entity Framework Core
- PostgreSQL
- AutoMapper
- JWT para autenticação
- Exceções personalizadas

## Estrutura do Projeto

O projeto está organizado da seguinte maneira:

```
EconoMe.Api
├── AutoMapper
├── Contracts
|   ├── Transaction/
│   ├── TransactionCategory/
│   ├── Payment/
│   ├── Receivable/
│   └── User/
├── Controllers
│   ├── BaseController.cs
│   ├── TransactionCategoryController.cs
│   ├── PaymentController.cs
│   ├── ReceivableController.cs
│   └── UserController.cs
├── Data
│   ├── Mappings
│   └── Contexts
├── Domain
|   ├── Models
|   │   ├── Interfaces/
|   │   └── Models/
|   ├── Repositories
|   │   ├── Interfaces/
|   │   └── Models/
|   ├── Services
|   │   ├── Interfaces/
|   │   └── Models/
├── Exceptions
|   ├── NotFoundException.cs
│   └── BadRequestException.cs
├── Migrations/
├── Program.cs
└── Startup.cs
```

## Configuração do Banco de Dados

A API utiliza o Entity Framework Core para gerenciar a persistência dos dados em um banco de dados PostgreSQL. Certifique-se de configurar a string de conexão no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=econome;Username=seu_usuario;Password=sua_senha"
  }
}
```

## Autenticação

A autenticação é realizada via tokens JWT. Após criar seu usuário, é possivel fazer login, e autenticar seu token.

## Iniciando a Aplicação

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu_usuario/econome.git
   ```
2. Navegue até o diretório do projeto:
   ```bash
   cd econome
   ```
3. Restaure as dependências:
   ```bash
   dotnet restore
   ```
4. Aplique as migrações do Entity Framework:
   ```bash
   dotnet ef database update
   ```
5. Inicie a aplicação:
   ```bash
   dotnet run
   ```

## Documentação da API

A documentação da API pode ser acessada via Swagger. Após iniciar a aplicação, navegue até:

```
http://localhost:5000/swagger
```

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.
