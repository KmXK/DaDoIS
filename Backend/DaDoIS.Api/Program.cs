using DaDoIS.Api.GraphQl;
using DaDoIS.Api.Queries;
using DaDoIS.Api.Configuration;
using DaDoIS.Api.Validators;
using DaDoIS.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<AppDbContext>(options =>
    {
        options.UseLazyLoadingProxies();
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        options.LogTo(Console.WriteLine, LogLevel.Information);
    })
    .AddAutoMapper(typeof(Program))
    .AddValidatorsFromAssemblyContaining<CreateClientDtoValidator>()
    .AddTransient<DataSeed>();

builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>()
    .AddErrorFilter<ErrorFilter>();

var app = builder.Build();

app.MapGraphQL();

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
if (app.Environment.IsDevelopment())
{
    scope.ServiceProvider.GetRequiredService<DataSeed>().Seed();
}

app.Run();
