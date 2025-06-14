using Backend.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
// Program.cs
builder.Services.AddDbContext<ProductDb>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductSqlServer;Trusted_Connection=True;"));

// ������ ������ ��� ����������
builder.Services.AddControllers();

// ������ �������� Swagger ��� ��������� ������������
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ����������� CORS ��� ������� ��� ������
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// ���� ���������� �������� - ������������� Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ���������� ������������� CORS ����� ������� ����������
app.UseCors("AllowAll");

// ������ ���������� (API-��������)
app.MapControllers();

app.Run();
