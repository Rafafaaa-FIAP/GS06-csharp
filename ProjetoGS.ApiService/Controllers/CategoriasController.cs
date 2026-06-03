using Microsoft.AspNetCore.Mvc;
using ProjetoGS.ApiService.Data;
using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriasController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.CategoriasImpacto.ToList());
    }

    [HttpPost]
    public IActionResult Post(CategoriaImpacto categoria)
    {
        _context.CategoriasImpacto.Add(categoria);
        _context.SaveChanges();

        return Ok(categoria);
    }
}