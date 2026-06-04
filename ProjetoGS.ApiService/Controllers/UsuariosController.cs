using Microsoft.AspNetCore.Mvc;
using ProjetoGS.ApiService.DTOs;
using ProjetoGS.ApiService.Interfaces;
using ProjetoGS.ApiService.Models;

namespace ProjetoGS.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuariosController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUsuarioDto dto)
    {
        var usuarioExistente =
            await _usuarioRepository.GetByEmailAsync(dto.Email);

        if (usuarioExistente != null)
            return BadRequest("E-mail já cadastrado.");

        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            Perfil = dto.Perfil
        };

        await _usuarioRepository.AddAsync(usuario);

        return Ok("Usuário cadastrado com sucesso.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var usuario =
            await _usuarioRepository.GetByEmailAsync(dto.Email);

        if (usuario == null)
            return Unauthorized("Usuário ou senha inválidos.");

        bool senhaValida =
            BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash);

        if (!senhaValida)
            return Unauthorized("Usuário ou senha inválidos.");

        return Ok(new
        {
            usuario.Id,
            usuario.Nome,
            usuario.Email,
            Perfil = usuario.Perfil.ToString()
        });
    }
}