using Backend.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
// Program.cs
builder.Services.AddDbContext<ProductDb>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductSqlServer;Trusted_Connection=True;"));

// Додаємо сервіси для контролерів
builder.Services.AddControllers();

// Додаємо підтримку Swagger для генерації документації
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Налаштовуємо CORS для дозволу всіх запитів
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Якщо середовище розробки - використовуємо Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Обов’язково використовуємо CORS перед мапінгом контролерів
app.UseCors("AllowAll");

// Мапимо контролери (API-ендпоінти)
app.MapControllers();

app.Run();
