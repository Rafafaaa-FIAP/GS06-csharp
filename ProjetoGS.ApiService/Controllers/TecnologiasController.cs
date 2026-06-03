using Microsoft.AspNetCore.Mvc;
using ProjetoGS.ApiService.Interfaces;
using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TecnologiasController : ControllerBase
{
    private readonly ITecnologiaRepository _repository;

    public TecnologiasController(ITecnologiaRepository repository)
    {
        _repository = repository;
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
}