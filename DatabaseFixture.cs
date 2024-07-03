using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Blazor.Services.Tests;

public class DatabaseFixture : IDisposable
{
    public IDbContextFactory<AppDbContext> DbContextFactory { get; }

    public DatabaseFixture()
    {
        var services = new ServiceCollection();
        services.AddDbContextFactory<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDb"));

        var serviceProvider = services.BuildServiceProvider();
        DbContextFactory = serviceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    }

    public void Dispose()
    {
        // Clean up the in-memory database if needed
    }
}

[CollectionDefinition("Database collection")]
public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
{
}
