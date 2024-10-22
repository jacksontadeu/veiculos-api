using Veiculos.Dominio.DTOs;

var builder = WebApplication.CreateBuilder(args);

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


app.MapGet("/weatherforecast", () =>
    {
        return "Ola Mundo";
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.MapPost("/login", (LoginDTO loginDTO) =>
{
    if (loginDTO.Email == "administrador@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("Login com sucesso!!!");
    else
        return Results.Unauthorized();
});
app.Run();

