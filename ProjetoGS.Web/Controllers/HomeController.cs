using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoGS.Web.Models;
using System.Diagnostics;
using System.Text.Json;

namespace ProjetoGS.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();

            var response = await client.GetAsync(
                "https://localhost:7368/api/Tecnologias/stats");

            if (!response.IsSuccessStatusCode)
            {
                return View(new TecnologiaStatsViewModel());
            }

            var json = await response.Content.ReadAsStringAsync();

            var stats =
                JsonSerializer.Deserialize<TecnologiaStatsViewModel>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(stats);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}