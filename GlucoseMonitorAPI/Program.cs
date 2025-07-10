using GlucoseMonitor.Application.Services;
using GlucoseMonitor.Domain.Interfaces;
using GlucoseMonitor.Infrastructure.Messaging;
using GlucoseMonitor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // standaard
        // of voor snake_case: gebruik een externe library zoals System.Text.Json SnakeCasePolicy
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMessageQueueService, AzuriteQueueService>();
builder.Services.AddScoped<IMeasurementService, MeasurementService>();
builder.Services.AddSingleton<IMeasurementQueue, QueueService>();
builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowDashboard",
        policy => policy.WithOrigins("http://192.168.2.13:3000/", "https://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowDashboard");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
