using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veiculos.Dominio.DTOs;

public class VeiculoDTO
{
    
     public string Nome { get; set; }
    public string Marca { get; set; }
     public int Ano { get; set; }
}