using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Interfaces;

public interface ICategoriaImpactoRepository
{
    Task<IEnumerable<CategoriaImpacto>> GetAllAsync();

    Task<CategoriaImpacto?> GetByIdAsync(int id);

    Task AddAsync(CategoriaImpacto categoria);

    Task UpdateAsync(CategoriaImpacto categoria);

    Task DeleteAsync(int id);
}