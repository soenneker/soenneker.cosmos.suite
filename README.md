[![](https://img.shields.io/nuget/v/Soenneker.Cosmos.Suite.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Cosmos.Suite/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cosmos.suite/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cosmos.suite/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Cosmos.Suite.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Cosmos.Suite/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cosmos.suite/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cosmos.suite/actions/workflows/codeql.yml)

# Soenneker.Cosmos.Suite

A concoction of Azure Cosmos utilities and libraries.

## Install

```bash
dotnet add package Soenneker.Cosmos.Suite
```

## Quick start

```csharp
using Soenneker.Cosmos.Suite.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddCosmosSuiteAsSingleton();
```

Adds all the Azure Cosmos utilities needed for use.

## What you get

- `CosmosSuiteRegistrar` — A concoction of Azure Cosmos utilities and libraries.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `CosmosSuiteRegistrar.AddCosmosSuiteAsSingleton(services)` | Adds all the Azure Cosmos utilities needed for use. | The same service collection, so additional registrations can be chained. |
