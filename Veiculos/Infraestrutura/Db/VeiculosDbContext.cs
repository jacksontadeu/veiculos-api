using Microsoft.EntityFrameworkCore;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Infraestrutura.Db;

public class VeiculosDbContext : DbContext
{
    public VeiculosDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<Administrador> Administradores { get; set; } = default!;
    public DbSet<Veiculo> Veiculos { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador
            {
                Id = 1,
                Email = "administrador@teste.com",
                Senha = "123465",
                Perfil = "Adm"
            }
        );
    }
}