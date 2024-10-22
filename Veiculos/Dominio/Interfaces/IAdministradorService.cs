using Veiculos.Dominio.DTOs;
using Veiculos.Dominio.Entidades;

namespace Veiculos.Dominio.Interfaces;

public interface IAdministradorService
{
    Administrador? Login (LoginDTO loginDTO);
}