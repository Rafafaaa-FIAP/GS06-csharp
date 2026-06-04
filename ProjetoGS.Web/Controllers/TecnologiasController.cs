using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoGS.Web.Models;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

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

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        using var client = new HttpClient();

        var response = await client.GetAsync(
            "https://localhost:7368/api/Categorias");

        if (!response.IsSuccessStatusCode)
        {
            return View(new CreateTecnologiaViewModel());
        }

        var json = await response.Content.ReadAsStringAsync();

        var categorias =
            JsonSerializer.Deserialize<List<CategoriaImpactoViewModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        var model = new CreateTecnologiaViewModel
        {
            Categorias = categorias!
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                })
                .ToList()
        };

        return View(model);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateTecnologiaViewModel model)
    {
        using var client = new HttpClient();

        var request = new TecnologiaCreateRequest
        {
            Nome = model.Nome,
            Descricao = model.Descricao,
            MissaoOrigem = model.MissaoOrigem,
            CategoriaImpactoId = model.CategoriaImpactoId
        };

        var json = JsonSerializer.Serialize(request);

        var content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json");

        var response = await client.PostAsync(
            "https://localhost:7368/api/Tecnologias",
            content);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        using var client = new HttpClient();

        var tecnologiaResponse = await client.GetAsync(
            $"https://localhost:7368/api/Tecnologias/{id}");

        if (!tecnologiaResponse.IsSuccessStatusCode)
            return RedirectToAction(nameof(Index));

        var tecnologiaJson = await tecnologiaResponse.Content.ReadAsStringAsync();

        var tecnologia = JsonSerializer.Deserialize<TecnologiaViewModel>(
            tecnologiaJson,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        var categoriasResponse = await client.GetAsync(
            "https://localhost:7368/api/Categorias");

        var categoriasJson = await categoriasResponse.Content.ReadAsStringAsync();

        var categorias = JsonSerializer.Deserialize<List<CategoriaImpactoViewModel>>(
            categoriasJson,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        var model = new EditTecnologiaViewModel
        {
            Id = tecnologia!.Id,
            Nome = tecnologia.Nome,
            Descricao = tecnologia.Descricao,
            MissaoOrigem = tecnologia.MissaoOrigem,
            CategoriaImpactoId = tecnologia.CategoriaImpactoId,
            Categorias = categorias!
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                })
                .ToList()
        };

        return View(model);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost]
    public async Task<IActionResult> Edit(EditTecnologiaViewModel model)
    {
        using var client = new HttpClient();

        var request = new
        {
            model.Id,
            model.Nome,
            model.Descricao,
            model.MissaoOrigem,
            model.CategoriaImpactoId
        };

        var json = JsonSerializer.Serialize(request);

        var content = new StringContent(
            json,
            Encoding.UTF8,
            "application/json");

        var response = await client.PutAsync(
            $"https://localhost:7368/api/Tecnologias/{model.Id}",
            content);

        if (response.IsSuccessStatusCode)
            return RedirectToAction(nameof(Index));

        return View(model);
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        using var client = new HttpClient();

        var response = await client.GetAsync(
            $"https://localhost:7368/api/Tecnologias/{id}");

        if (!response.IsSuccessStatusCode)
            return RedirectToAction(nameof(Index));

        var json = await response.Content.ReadAsStringAsync();

        var tecnologia =
            JsonSerializer.Deserialize<TecnologiaViewModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        return View(tecnologia);
    }

    [Authorize(Roles = "Administrador")]
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        using var client = new HttpClient();

        var response = await client.DeleteAsync(
            $"https://localhost:7368/api/Tecnologias/{id}");

        return RedirectToAction(nameof(Index));
    }
}