using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Planner.Data.Migrator;

public static class MigratorHelper
{
	public static int MigrateDb<T>(IDesignTimeDbContextFactory<T> contextFactory, string[] args) where T : DbContext
	{
		var dbContextType = typeof(T).Name;
		Console.WriteLine("Creating Db Context: {0}", dbContextType);
		var context = contextFactory.CreateDbContext(args);

		Console.WriteLine("Checking for database migration");
		if (!context.Database.GetPendingMigrations().Any())
		{
			Console.WriteLine("Database is up to date");
		}
		else
		{
			Console.WriteLine("Running {0} migrations...", context.Database.GetPendingMigrations()?.Count());
			foreach (var script in context.Database.GetPendingMigrations())
			{
				Console.WriteLine(script);
			}
			context.Database.Migrate();
			Console.WriteLine("Database migration is complete");
		}

		return 0;
	}
}
