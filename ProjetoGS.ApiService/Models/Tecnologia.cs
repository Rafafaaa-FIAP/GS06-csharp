namespace ProjetoGS.ApiService.Models;

public class Tecnologia
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string MissaoOrigem { get; set; } = string.Empty;

    public DateTime DataCadastro { get; set; } = DateTime.Now;

    public int CategoriaImpactoId { get; set; }

    public CategoriaImpacto? CategoriaImpacto { get; set; }
}