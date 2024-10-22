using Microsoft.AspNetCore.Mvc.Razor;
using Veiculos.Dominio.DTOs;
using Veiculos.Dominio.Entidades;
using Veiculos.Dominio.Interfaces;
using Veiculos.Infraestrutura.Db;

namespace Veiculos.Dominio.Servicos;

public class AdministradorService : IAdministradorService
{
    private readonly VeiculosDbContext _context;

    public AdministradorService(VeiculosDbContext context)
    {
        _context = context;
    }
    public Administrador? Login(LoginDTO loginDTO)
    {
        var usuario = _context.Administradores.Where(u =>
            u.Email.Equals(loginDTO.Email) && u.Senha.Equals(loginDTO.Senha)).FirstOrDefault();
        return usuario;
    }
   
}