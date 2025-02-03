using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Planner.Data.Database;

namespace Planner.Api.Infrastructure.Data;

/// <summary>
/// This here so the Migrator app can run migrations for the PlannerDbContext with
/// access to the appsettings for the connection string
/// Ideally this lives in the data project with the DbContext but this is fine 
/// </summary>
public class PlannerDbContextFactory : IDesignTimeDbContextFactory<PlannerDbContext>
{
    public PlannerDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string? connectionString = config.GetConnectionString(nameof(PlannerDbContext));
        var options = new DbContextOptionsBuilder<PlannerDbContext>()
            .UseSqlServer(connectionString);

        return new PlannerDbContext(options.Options);
    }
}
