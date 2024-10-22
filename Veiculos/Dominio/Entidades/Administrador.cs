using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veiculos.Dominio.Entidades;

public class Administrador
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Email { get; set; }
    [Required]
    [StringLength(50)]
    public string Senha { get; set; }
    [StringLength(10)]
    [Required]
    public string Perfil { get; set; }
}