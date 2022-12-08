using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RubiconTask.Data;

namespace RubiconTask.Test.Helpers;

/// <summary>
/// Database factory.
/// </summary>
public static class InMemoryDatabaseFactory
{
    /// <summary>
    /// Creates in memory database.
    /// </summary>
    /// <returns>In Memory DB Context.</returns>
    public static DatabaseContext CreateInMemoryDatabase()
    {
        var databaseName = Guid.NewGuid().ToString();

        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        var options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName).UseInternalServiceProvider(serviceProvider).Options;
        var databaseContextMock = new DatabaseContext(options);
        return databaseContextMock;
    }
}