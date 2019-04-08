[![NuGet](https://img.shields.io/badge/nuget-v1.0.0-blue.svg)](https://www.nuget.org/packages/Movidesk.Api.Client/)

# Movidesk.Api.Client

Uma biblioteca em .netstandard para trabalhar com as APIs da Movidesk.

## APIs implementadas na biblioteca até o momento

* Ticket
* Person
* Service
* TimeAgreement

## Como instalar

Instale o [NuGet](https://docs.microsoft.com/pt-br/nuget/install-nuget-client-tools) e execute a partir do package manager console:
```
PM> Install-Package Movidesk.Api.Client
```

## Criando o cliente

```c#
MovideskApiClientOptions options = new MovideskApiClientOptions { Token = "movidesk-token" };
MovideskClient client = new MovideskClient(new MovideskApiClient(options));
```

## Integração com Tickets

Documentação da API de Tickets da Movidesk: https://atendimento.movidesk.com/kb/pt-br/article/256/movidesk-ticket-api

### Pegar ticket por id
```c#
...
var ticket = await client.Tickets.GetById(42);
```

### Pegar uma lista de tickets
É obrigatório informar os campos do filtro $select para buscar uma lista de tickets.
```c#
...
var tickets = await client.Tickets.Get(new OData { Select = "id,subject" });
```

### Criar um ticket (POST)
```c#
...
var result = await client.Tickets.Post(new Ticket 
{
    Subject = "meu ticket",
    Type = Enums.TicketType.Internal,
    CreatedBy = new TicketPerson { Id = "ref_code" },
    Actions = new List<TicketAction>
    {
        new TicketAction {
            Description = "minha ação",
            Type = Enums.TicketType.Internal
        }
    },
    Clients = new List<TicketClient>
    {
        new TicketClient { Id = "ref_code" }
    }
});
```

### Atualizar um ticket (PATCH)
As atualizações são feitas informando somente os atributos que desejam ser atualizados. Neste exemplo somente o campo `Subject` será atualizado.
```c#
...
var result = await client.Tickets.Patch(42, new Ticket
{
    Subject = "meu assunto de ticket alterado"
});
```

## Integração com Pessoas (Persons)

Documentação da API de Pessoas da Movidesk: https://atendimento.movidesk.com/kb/pt-br/article/189/movidesk-person-api

### Pegar uma pessoa por ID
```c#
...
var person = await client.Persons.GetById("42");
```

### Pegar uma lista de pessoas
```c#
...
var persons = await client.Persons.Get();
```

### Pegar uma lista de pessoas com filtros
Retorna uma lista de pessoas, com profileType = 2, os 10 primeiros registros, pulando 30 registros e selecionando os campos id e businessName.
```c#
...
var persons = await client.Persons.Get(new OData
{
    Filter = "profileType eq 2",
    Top = 10,
    Skip = 30,
    Select = "id,businessName"
});
```

### Criar uma pessoa (POST)
```c#
...
var result = await client.Persons.Post(new Person
{
    BusinessName = "James Bond",
    ProfileType = Enums.ProfileType.Agent,
    PersonType = Enums.PersonType.Person,
    IsActive = true,
    AccessProfile = "Agentes",
    Teams = new List<string> { "Agentes" }
});
```
### Atualizar uma pessoa (PATCH)
As atualizações são feitas informando somente os atributos que desejam ser atualizados. Neste exemplo somente o campo `BusinessName` será atualizado.
```c#
...
var result = await client.Persons.Patch("007", new Person { BusinessName = "Bond, James Bond" });
```

### Excluir uma pessoa (DELETE)
```c#
...
var result = await client.Persons.Delete("007");
```

## Integração com Serviços (Services)
Documentação da API de Serviços da Movidesk: https://atendimento.movidesk.com/kb/pt-br/article/7440/api-servicos

### Pegar um serviço por Id
```c#
...
var result = await client.Services.GetById(42);
```

### Pegar uma lista de serviços
```c#
...
var result = await client.Services.Get();
```

### Pegar uma lista de serviços com filtro
```c#
...
var result = client.Services.Get(new OData { Top = 1 });
```

### Criar um serviço (POST)
```c#
...
var result = await client.Services.Post(new Service
{
    Name = "Serviço",
    Description = "Desc",
    IsVisible = ServiceVisibility.AgentAndClient,
    ServiceForTicketType = ServiceTicketType.PublicAndInternal,
    AllowSelection = ServiceSelection.AgentAndClient,
    AllowFinishTicket = true,
    IsActive = true,
    AllowAllCategories = true
});
```

### Criar um serviço (POST)
```c#
...
var result = await client.Services.Post(new Service
{
    Name = "Serviço",
    Description = "Desc",
    IsVisible = ServiceVisibility.AgentAndClient,
    ServiceForTicketType = ServiceTicketType.PublicAndInternal,
    AllowSelection = ServiceSelection.AgentAndClient,
    AllowFinishTicket = true,
    IsActive = true,
    AllowAllCategories = true
});
```

### Atualizar um serviço (PATCH)
As atualizações são feitas informando somente os atributos que desejam ser atualizados. Neste exemplo somente o campo `Description` será atualizado.

```c#
...
var result = await client.Services.Patch(42, new Service { Description = "Nova descrição" });
```

### Remover um serviço (DELETE)

```c#
...
var result = await client.Services.Delete(42);
```
