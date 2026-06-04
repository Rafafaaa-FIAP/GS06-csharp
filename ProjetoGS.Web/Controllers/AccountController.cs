using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjetoGS.Web.Models;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ProjetoGS.Web.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        using var client = new HttpClient();

        var json = JsonSerializer.Serialize(new
        {
            email = model.Email,
            senha = model.Senha
        });

        var content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json");

        var response = await client.PostAsync(
            "https://localhost:7368/api/usuarios/login",
            content);

        if (!response.IsSuccessStatusCode)
        {
            ViewBag.Erro = "Usuário ou senha inválidos.";
            return View(model);
        }

        var responseContent =
            await response.Content.ReadAsStringAsync();

        var usuario =
            JsonSerializer.Deserialize<UsuarioLoginResponse>(
                responseContent,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario!.Nome),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Perfil)
        };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction(nameof(Login));
    }

    public IActionResult AcessoNegado()
    {
        return View();
    }
}