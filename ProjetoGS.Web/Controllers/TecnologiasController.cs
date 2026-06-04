using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoGS.Web.Models;
using System.Text.Json;

namespace ProjetoGS.Web.Controllers;

[Authorize]
public class TecnologiasController : Controller
{
    public async Task<IActionResult> Index()
    {
        using var client = new HttpClient();

        var response = await client.GetAsync(
            "https://localhost:7368/api/Tecnologias");

        if (!response.IsSuccessStatusCode)
        {
            return View(new List<TecnologiaViewModel>());
        }

        var json = await response.Content.ReadAsStringAsync();

        var tecnologias =
            JsonSerializer.Deserialize<List<TecnologiaViewModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return View(tecnologias);
    }
}