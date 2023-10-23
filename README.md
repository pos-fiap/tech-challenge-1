# Manobra Fácil API

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
   "Default": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TechChallenge;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server             
   Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
}
```

### Executando as Migrações do Banco de Dados
Para criar ou atualizar o banco de dados, você precisa executar as migrações. Siga as etapas abaixo:

1 - Abra o Visual Studio.

2 - Abra o Console do Gerenciador de Pacotes do NuGet no Visual Studio. Você pode fazer isso indo em "Ferramentas" -> "Gerenciador de Pacotes do NuGet" -> "Console do Gerenciador de Pacotes".

3- Para aplicar a última verssãop da migração ao banco de dados utilize o seguinte comando:

```
Update-Database
```

## Executando a API
Abra um terminal na pasta TechChallengeAPI do projeto. Execute o seguinte comando para iniciar a API:

```
dotnet run
```

A API estará disponível em http://localhost:5023. Você pode acessar os endpoints da API para realizar operações de controle de vagas de estacionamento.
