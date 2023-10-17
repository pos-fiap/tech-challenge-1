# tech-challenge-1# Manobra Fácil API

A API Manobra Fácil foi desenvolvida para o controle de vagas de estacionamento. Este projeto foi criado como para o Tech Challenge FIAP e foi modelado seguindo os princípios de DDD (Domain Driven Design) e Clean Architecture.

## Tecnologias Utilizadas

- .NET 7
- SQL Server LocalDB
- Entity Framework


## Integrantes do Projeto

- Ricardo Maciel da Silva
- Jacó Isaque dos Santos Penteado
- Luana Santos Lima
- Luiz Gustavo Mendes Batista
- João Carlos Baldi Júnior

## Requisitos

Antes de rodar a API, certifique-se de que você tenha os seguintes pré-requisitos instalados:

- [SDK do .NET 7](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

## Configuração do Banco de Dados

1. Abra o Visual Studio Code ou sua IDE preferida.
2. Abra o arquivo `appsettings.json` na pasta raiz do projeto e configure a string de conexão com o SQL Server LocalDB de acordo com suas preferências:

```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ManobraFacilDb;Trusted_Connection=True;"
   }  
```

## Configuração do Banco de Dados
Executando as Migrações do Banco de Dados
Para criar ou atualizar o banco de dados, você precisa executar as migrações. Siga as etapas abaixo:

1 - Abra um terminal na pasta raiz do projeto.
Certifique-se de que você tenha a ferramenta dotnet ef instalada globalmente. Se não estiver instalada, você pode instalá-la com o seguinte comando:

```
dotnet tool install --global dotnet-ef
```

2 - Execute as migrações para criar ou atualizar o banco de dados:

```
dotnet ef database update
```

Isso aplicará todas as migrações pendentes e criará ou atualizará o banco de dados com base no modelo definido em seu aplicativo.

## Executando a API
Abra um terminal na pasta raiz do projeto. Execute o seguinte comando para iniciar a API:

```
dotnet run
```

A API estará disponível em https://localhost:7250. Você pode acessar os endpoints da API para realizar operações de controle de vagas de estacionamento.
