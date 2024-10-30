using Veiculos.Dominio.Entidades;

namespace Veiculos.Dominio.Interfaces;

public interface IVeiculoService
{
    List<Veiculo> ListarTodos(int pagina =1, string? nome = null, string? marca = null);
    Veiculo? BuscaPorId(int id);
    Veiculo CriarVeiculo(Veiculo veiculo);
    Veiculo AlterarVeiculo(Veiculo veiculo);
    void DeletarVeiculo(int id);
}