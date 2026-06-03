using Microsoft.EntityFrameworkCore;
using ProjetoGS.ApiService.Data;
using ProjetoGS.ApiService.Interfaces;
using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Repositories;

public class TecnologiaRepository : ITecnologiaRepository
{
    private readonly ApplicationDbContext _context;

    public TecnologiaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tecnologia>> GetAllAsync()
    {
        return await _context.Tecnologias
            .Include(t => t.CategoriaImpacto)
            .ToListAsync();
    }

    public async Task<Tecnologia?> GetByIdAsync(int id)
    {
        return await _context.Tecnologias
            .Include(t => t.CategoriaImpacto)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(Tecnologia tecnologia)
    {
        _context.Tecnologias.Add(tecnologia);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tecnologia tecnologia)
    {
        _context.Tecnologias.Update(tecnologia);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tecnologia = await _context.Tecnologias.FindAsync(id);

        if (tecnologia != null)
        {
            _context.Tecnologias.Remove(tecnologia);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<int> GetTotalTecnologiasAsync()
    {
        return await _context.Tecnologias.CountAsync();
    }
}