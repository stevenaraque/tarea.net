using Scalar.AspNetCore;
using TareaApi.Api.Data;
using TareaApi.Api.Services;
using TareaApi.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TareaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TareaConnection")));
builder.Services.AddScoped<ITareaService, TareaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<TareaContext>();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
