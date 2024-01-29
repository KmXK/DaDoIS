using DaDoIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Logging.AddConsole();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.LogTo(Console.WriteLine, LogLevel.Debug);
});

Console.WriteLine(connectionString);

var app = builder.Build();

app.Services.GetRequiredService<AppDbContext>().Database.Migrate();

app.UseHttpsRedirection();

app.MapGet("/", () => connectionString);

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

app.Run();