using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veiculos.Dominio.DTOs;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Interfaces;
using Veiculos.Dominio.Servicos;
using Veiculos.Dominio.Validacao;
using Veiculos.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

var conexao = builder.Configuration.GetConnectionString("mysql");
builder.Services.AddDbContext<VeiculosDbContext>(options =>
    options.UseMySql(conexao, ServerVersion.AutoDetect(conexao)));

builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IVeiculoService, VeiculoService>();
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

app.MapGet("veiculo/Listartodos", (IVeiculoService veiculoService) =>
{
     return veiculoService.ListarTodos();
});
app.MapGet("veiculo/Buscarporid/{id}", ([FromRoute]int id, IVeiculoService veiculoService) =>
{
    var veiculo = veiculoService.BuscaPorId(id);
    if (veiculo is null) return Results.NotFound();
    return Results.Ok(veiculo);
});

app.MapPost("/veiculo/Cadastrarveiculo", ([FromBody] VeiculoDTO veiculoDTO, IVeiculoService veiculoService) =>
{
    var validacao = new ValidaVeiculo();
    var valida = validacao.ValidaDTO(veiculoDTO);

    if (valida.Mensagens.Count > 0)
        return Results.BadRequest(valida);

    var veiculo = new Veiculo
    {
        Nome = veiculoDTO.Nome,
        Marca = veiculoDTO.Marca,
        Ano = veiculoDTO.Ano

    };
    veiculoService.CriarVeiculo(veiculo);
    return Results.Created(string.Empty, veiculo);

});







app.Run();

