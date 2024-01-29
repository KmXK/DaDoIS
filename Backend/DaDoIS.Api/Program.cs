using DaDoIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Logging.AddConsole();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello world!");

app.MapGet("/{id:int}",
    (
        int id,
        [FromServices] ILogger<Program> logger) =>
    {
        logger.LogInformation("My new value Id = {id}.", id);
        return TypedResults.Ok(new
        {
            data = new[]
            {
                1, 2, 3, 4
            },
            message = "Hello world!"
        });
    });

await app.Services.GetRequiredService<AppDbContext>().Database.MigrateAsync();

app.Run();
