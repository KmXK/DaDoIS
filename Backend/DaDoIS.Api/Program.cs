using DaDoIS.Api.Validators;
using DaDoIS.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Logging.AddConsole();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.LogTo(Console.WriteLine, LogLevel.Debug);
});
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<CreateClientDtoValidator>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

await app.Services.GetRequiredService<AppDbContext>().Database.MigrateAsync();

app.Run();
