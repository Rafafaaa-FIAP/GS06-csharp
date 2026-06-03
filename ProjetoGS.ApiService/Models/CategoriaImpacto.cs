namespace ProjetoGS.ApiService.Models;

public class CategoriaImpacto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public ICollection<Tecnologia>? Tecnologias { get; set; }
}