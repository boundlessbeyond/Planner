using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Planner.Domain.Entities;

namespace Planner.Data.Database;

public class PlannerDbContext : IdentityDbContext<ApplicationUser>
{
    public PlannerDbContext(DbContextOptions<PlannerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var schema = "IAM";
        builder.Entity<ApplicationUser>().ToTable(nameof(ApplicationUser)+"s", schema);
        builder.HasDefaultSchema(schema);
        // TODO - IAM is the schema for all the identity stuff. Use a different schema for the Planner
    }
}
