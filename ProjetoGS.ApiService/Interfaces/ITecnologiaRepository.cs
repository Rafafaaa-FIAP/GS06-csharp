using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Interfaces;

public interface ITecnologiaRepository
{
    Task<IEnumerable<Tecnologia>> GetAllAsync();

    Task<Tecnologia?> GetByIdAsync(int id);

    Task AddAsync(Tecnologia tecnologia);

    Task UpdateAsync(Tecnologia tecnologia);

    Task DeleteAsync(int id);

    Task<int> GetTotalTecnologiasAsync();
}