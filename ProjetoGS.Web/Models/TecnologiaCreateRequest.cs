namespace ProjetoGS.Web.Models;

public class TecnologiaCreateRequest
{
    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string MissaoOrigem { get; set; } = string.Empty;

    public int CategoriaImpactoId { get; set; }
}