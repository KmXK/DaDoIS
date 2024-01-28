using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

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

app.Run();
