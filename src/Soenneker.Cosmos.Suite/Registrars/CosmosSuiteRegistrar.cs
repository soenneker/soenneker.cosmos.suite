using Microsoft.Extensions.DependencyInjection;
using Soenneker.Cosmos.Container.Registrars;
using Soenneker.Cosmos.Database.Registrars;

namespace Soenneker.Cosmos.Suite.Registrars;

/// <summary>
/// Registers the Soenneker Azure Cosmos DB client, database, container, and setup utilities.
/// </summary>
public static class CosmosSuiteRegistrar
{
    /// <summary>
    /// Adds the Cosmos database and container utilities with singleton lifetimes, including their transitive dependencies.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddCosmosSuiteAsSingleton(this IServiceCollection services)
    {
        services.AddCosmosContainerUtilAsSingleton().AddCosmosDatabaseUtilAsSingleton();

        return services;
    }
}
