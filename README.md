[![](https://img.shields.io/nuget/v/Soenneker.Cosmos.Suite.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Cosmos.Suite/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cosmos.suite/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cosmos.suite/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Cosmos.Suite.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Cosmos.Suite/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cosmos.suite/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cosmos.suite/actions/workflows/codeql.yml)

# Soenneker.Cosmos.Suite

One registration method for the Soenneker Azure Cosmos DB client, database, container, and setup utilities.

## Installation

```bash
dotnet add package Soenneker.Cosmos.Suite
```

## Configuration

```json
{
  "Environment": "Production",
  "Azure": {
    "Cosmos": {
      "Endpoint": "https://your-account.documents.azure.com:443/",
      "AccountKey": "your-account-key",
      "DatabaseName": "app",
      "ConnectionMode": "Direct",
      "AllowBulkExecution": false,
      "EnsureDatabaseOnFirstUse": true,
      "EnsureContainerOnFirstUse": true,
      "DatabaseThroughput": 1000,
      "DatabaseThroughputType": "autoscale",
      "ReplaceDatabaseThroughput": false
    }
  }
}
```

`Environment`, `Endpoint`, `AccountKey`, and `DatabaseName` are required. `ConnectionMode` defaults to `Direct` and accepts `Direct` or `Gateway` case-insensitively.

Database and container creation both default to enabled on first use. When database creation is enabled, `DatabaseThroughput` and `DatabaseThroughputType` are required by the setup utility. Set the ensure flags to `false` when the application must only use resources provisioned elsewhere.

## Registration and use

```csharp
using Soenneker.Cosmos.Container.Abstract;
using Soenneker.Cosmos.Database.Abstract;
using Soenneker.Cosmos.Suite.Registrars;

services.AddCosmosSuiteAsSingleton();

ICosmosDatabaseUtil databases =
    serviceProvider.GetRequiredService<ICosmosDatabaseUtil>();
ICosmosContainerUtil containers =
    serviceProvider.GetRequiredService<ICosmosContainerUtil>();

Microsoft.Azure.Cosmos.Database database =
    await databases.Get(cancellationToken);

Microsoft.Azure.Cosmos.Container orders =
    await containers.Get("orders", cancellationToken);
```

`AddCosmosSuiteAsSingleton()` registers `ICosmosDatabaseUtil` and `ICosmosContainerUtil` as singletons. Their setup, client, serializer, HTTP-cache, and memory-stream dependencies are added transitively. Registrations use `TryAdd`, so application registrations made before the suite are preserved.

The suite does not add the higher-level repository abstractions and does not create resources during service registration. Resource creation, connection failures, and cancellation occur when a utility is first used and propagate to the caller.

`AllowInsecureServerCertificate` is intentionally omitted above. If enabled, the client accepts it only when `Environment` is `Local` or `Test`; never use it for deployed environments.
