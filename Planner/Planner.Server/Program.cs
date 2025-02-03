using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Planner.Api.Infrastructure.Data;
using Planner.Data.Database;
using Planner.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme)
    //.AddBearerToken(IdentityConstants.BearerScheme)
    ;

builder.Services.AddIdentityCore<ApplicationUser>()
    .AddEntityFrameworkStores<PlannerDbContext>()
    .AddApiEndpoints();

builder.Services.AddDbContextFactory<PlannerDbContext>(options =>
    options.UseSqlServer());
builder.Services.AddSingleton<PlannerDbContextFactory>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<ApplicationUser>();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
