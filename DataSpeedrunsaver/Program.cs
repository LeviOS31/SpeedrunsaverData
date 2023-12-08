
using Microsoft.EntityFrameworkCore;
using DataBase.Data;
using DataBase;
using Interfaces.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddDbContext<DBSpeedrunsaverContext>(options =>
{
    options.UseSqlServer(
        @"Server=mssqlstud.fhict.local;Database=dbi512680_speedrun;User Id=dbi512680_speedrun;Password=Admin1234;TrustServerCertificate=True;"
);
});

builder.Services.AddScoped<IDalFactory, DalFactory>();

//builder.Services.AddSingleton<DBSpeedrunsaverContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAnyOriginPolicy");

app.MapControllers();

app.Run();
