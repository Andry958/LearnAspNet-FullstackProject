using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

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
