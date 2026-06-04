using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.DTOs;

public class RegisterUsuarioDto
{
    public string Nome { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Senha { get; set; } = string.Empty;

    public PerfilUsuario Perfil { get; set; }
}