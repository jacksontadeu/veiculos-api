using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veiculos.Dominio.DTOs;

public class VeiculoDTO
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required] [StringLength(100)] public string Nome { get; set; }
    [Required] [StringLength(100)] public string Marca { get; set; }
    [Required] public int Ano { get; set; }
}