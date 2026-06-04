using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjetoGS.Web.Models;

public class CreateTecnologiaViewModel
{
    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string MissaoOrigem { get; set; } = string.Empty;

    public int CategoriaImpactoId { get; set; }

    public List<SelectListItem> Categorias { get; set; } = [];
}