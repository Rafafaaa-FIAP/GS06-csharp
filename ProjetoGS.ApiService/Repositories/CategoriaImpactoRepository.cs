using Microsoft.EntityFrameworkCore;
using ProjetoGS.ApiService.Data;
using ProjetoGS.ApiService.Interfaces;
using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Repositories;

public class CategoriaImpactoRepository : ICategoriaImpactoRepository
{
    private readonly ApplicationDbContext _context;

    public CategoriaImpactoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoriaImpacto>> GetAllAsync()
    {
        return await _context.CategoriasImpacto.ToListAsync();
    }

    public async Task<CategoriaImpacto?> GetByIdAsync(int id)
    {
        return await _context.CategoriasImpacto
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(CategoriaImpacto categoria)
    {
        _context.CategoriasImpacto.Add(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CategoriaImpacto categoria)
    {
        _context.CategoriasImpacto.Update(categoria);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var categoria = await _context.CategoriasImpacto.FindAsync(id);

        if (categoria == null)
            return;

        _context.CategoriasImpacto.Remove(categoria);

        await _context.SaveChangesAsync();
    }
}