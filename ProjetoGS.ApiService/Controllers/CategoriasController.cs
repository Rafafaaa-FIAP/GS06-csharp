using Microsoft.AspNetCore.Mvc;
using ProjetoGS.ApiService.Interfaces;
using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaImpactoRepository _repository;

    public CategoriasController(ICategoriaImpactoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categorias = await _repository.GetAllAsync();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var categoria = await _repository.GetByIdAsync(id);

        if (categoria == null)
            return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CategoriaImpacto categoria)
    {
        await _repository.AddAsync(categoria);

        return CreatedAtAction(
            nameof(Get),
            new { id = categoria.Id },
            categoria);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(
        int id,
        CategoriaImpacto categoria)
    {
        if (id != categoria.Id)
            return BadRequest();

        await _repository.UpdateAsync(categoria);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return NoContent();
    }
}