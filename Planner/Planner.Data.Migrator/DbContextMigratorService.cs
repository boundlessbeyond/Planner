using Microsoft.Extensions.Hosting;
using Planner.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Planner.Api.Infrastructure.Data;

namespace Planner.Data.Migrator;
internal class DbContextMigratorService : IHostedService
{
    private readonly IHostApplicationLifetime appLifetime;

    private int? exitCode;

    public DbContextMigratorService(IHostApplicationLifetime appLifetime)
    {
        this.appLifetime = appLifetime;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        this.appLifetime.ApplicationStarted.Register(() => Task.Run(() =>
        {
            var args = Environment.GetCommandLineArgs();
            Console.WriteLine("Command Line args: {0})", string.Join(',', args));

            try
            {
                Console.WriteLine("Creating Db context factory");
                this.exitCode = MigratorHelper.MigrateDb(new PlannerDbContextFactory(), args);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while trying to migrate the database to the latest version: {0}", ex.Message);
                this.exitCode = 1;
            }
            finally
            {
                this.appLifetime.StopApplication();
            }
        }, cancellationToken));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Exiting with return code: {0}", this.exitCode);

        Environment.ExitCode = this.exitCode.GetValueOrDefault(-1);
        return Task.CompletedTask;
    }
}