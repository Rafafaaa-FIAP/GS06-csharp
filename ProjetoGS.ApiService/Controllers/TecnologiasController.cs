using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoGS.ApiService.Interfaces;
using ProjetoGS.ApiService.Models;
using Microsoft.EntityFrameworkCore;
using ProjetoGS.ApiService.Data;
using ProjetoGS.ApiService.DTOs;

namespace ProjetoGS.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TecnologiasController : ControllerBase
{
    private readonly ITecnologiaRepository _repository;
    private readonly ApplicationDbContext _context;

    public TecnologiasController(
        ITecnologiaRepository repository,
        ApplicationDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tecnologias = await _repository.GetAllAsync();
        return Ok(tecnologias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var tecnologia = await _repository.GetByIdAsync(id);

        if (tecnologia == null)
            return NotFound();

        return Ok(tecnologia);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Tecnologia tecnologia)
    {
        await _repository.AddAsync(tecnologia);
        return CreatedAtAction(nameof(Get), new { id = tecnologia.Id }, tecnologia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Tecnologia tecnologia)
    {
        if (id != tecnologia.Id)
            return BadRequest();

        await _repository.UpdateAsync(tecnologia);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var totalTecnologias =
            await _context.Tecnologias.CountAsync();

        var missoesMapeadas =
            await _context.Tecnologias
                .Select(t => t.MissaoOrigem)
                .Distinct()
                .CountAsync();

        var setoresBeneficiados =
            await _context.CategoriasImpacto.CountAsync();

        var tecnologiasPorCategoria =
            await _context.Tecnologias
                .Include(t => t.CategoriaImpacto)
                .GroupBy(t => t.CategoriaImpacto!.Nome)
                .Select(g => new TecnologiaPorCategoriaDto
                {
                    Categoria = g.Key,
                    Total = g.Count()
                })
                .ToListAsync();

        var ultimasTecnologias =
            await _context.Tecnologias
                .Include(t => t.CategoriaImpacto)
                .OrderByDescending(t => t.DataCadastro)
                .Take(5)
                .Select(t => new UltimaTecnologiaDto
                {
                    Id = t.Id,
                    Nome = t.Nome,
                    MissaoOrigem = t.MissaoOrigem,
                    Categoria = t.CategoriaImpacto!.Nome,
                    DataCadastro = t.DataCadastro
                })
                .ToListAsync();

        var dto = new TecnologiaStatsDto
        {
            TotalTecnologias = totalTecnologias,
            MissoesMapeadas = missoesMapeadas,
            SetoresBeneficiados = setoresBeneficiados,
            TecnologiasPorCategoria = tecnologiasPorCategoria,
            UltimasTecnologias = ultimasTecnologias
        };

        return Ok(dto);
    }
}