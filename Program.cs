using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EmployeeWebAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeWebAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeWebAPIContext") ?? throw new InvalidOperationException("Connection string 'EmployeeWebAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
