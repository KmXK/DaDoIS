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

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/clients", (AppDbContext db) => db.Clients);

app.MapGet("/clients/{id:Guid}", (AppDbContext db, Guid id) => db.Clients.FirstOrDefault(c => c.Id == id));

app.MapGet("/cities", (AppDbContext db) => db.Cities);

app.MapGet("/cities/{id:int}", (AppDbContext db, int id) => db.Cities.FirstOrDefault(c => c.Id == id));

app.MapGet("/citizenship", (AppDbContext db) => db.Citizenship);

app.MapGet("/citizenship/{id:int}", (AppDbContext db, int id) => db.Citizenship.FirstOrDefault(c => c.Id == id));

app.MapGet("/{id:int}", (
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
