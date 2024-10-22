using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veiculos.Dominio.DTOs;
using Veiculos.Dominio.Interfaces;
using Veiculos.Dominio.Servicos;
using Veiculos.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

var conexao = builder.Configuration.GetConnectionString("mysql");
builder.Services.AddDbContext<VeiculosDbContext>(options =>
    options.UseMySql(conexao, ServerVersion.AutoDetect(conexao)));

builder.Services.AddScoped<IAdministradorService, AdministradorService>();
// Add services to the container.
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

app.UseHttpsRedirection();




app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorService administradorServico) =>
{
    if (administradorServico.Login(loginDTO) != null)
        return Results.Ok("Login realizado com sucesso!!!");
    else
        return Results.Unauthorized();
});
app.Run();

