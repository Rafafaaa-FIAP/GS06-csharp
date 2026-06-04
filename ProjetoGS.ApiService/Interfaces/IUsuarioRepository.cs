using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByEmailAsync(string email);

    Task AddAsync(Usuario usuario);
}