namespace ProjetoGS.Web.Models;

public class TecnologiaViewModel
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string MissaoOrigem { get; set; } = string.Empty;

    public DateTime DataCadastro { get; set; }

    public int CategoriaImpactoId { get; set; }

    public CategoriaImpactoViewModel? CategoriaImpacto { get; set; }
}