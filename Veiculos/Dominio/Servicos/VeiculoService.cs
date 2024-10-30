using Microsoft.EntityFrameworkCore;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Interfaces;
using Veiculos.Infraestrutura.Db;

namespace Veiculos.Dominio.Servicos;

public class VeiculoService : IVeiculoService
{
    private readonly VeiculosDbContext _context;

    public VeiculoService(VeiculosDbContext context)
    {
        _context = context;
    }

    public List<Veiculo> ListarTodos(int pagina = 1, string? nome = null, string? marca = null)
    {
        var query = _context.Veiculos.AsQueryable();
        if (!string.IsNullOrEmpty(nome))
        {
            query = query.Where(v => EF.Functions.Like(v.Nome.ToLower(),
                $"&{nome}&"));
        }

        int itensPorPaginas = 10;
        query = query.Skip((pagina - 1) * itensPorPaginas).Take(itensPorPaginas);

        return query.ToList();
    }

    public Veiculo? BuscaPorId(int id)
    {
        var veiculo = _context.Veiculos.Where(v => v.Id == id).FirstOrDefault();
        return veiculo;
    }

    public Veiculo CriarVeiculo(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        _context.SaveChanges();
        return veiculo;
    }

    public Veiculo? AlterarVeiculo(Veiculo veiculo)
    {
        _context.Entry(veiculo).State = EntityState.Modified;
        _context.SaveChanges();
        return veiculo;
    }

    public void DeletarVeiculo(int id)
    {
        var veiculo = _context.Veiculos.FirstOrDefault(v => v.Id == id);
        _context.Remove(veiculo);
        _context.SaveChanges();
    }
}