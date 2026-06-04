namespace ProjetoGS.Web.Models;

public class TecnologiaStatsViewModel
{
    public int TotalTecnologias { get; set; }

    public int MissoesMapeadas { get; set; }

    public int SetoresBeneficiados { get; set; }

    public List<TecnologiaPorCategoriaViewModel> TecnologiasPorCategoria { get; set; } = [];

    public List<UltimaTecnologiaViewModel> UltimasTecnologias { get; set; } = [];
}

public class TecnologiaPorCategoriaViewModel
{
    public string Categoria { get; set; } = string.Empty;

    public int Total { get; set; }
}

public class UltimaTecnologiaViewModel
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string MissaoOrigem { get; set; } = string.Empty;

    public string Categoria { get; set; } = string.Empty;

    public DateTime DataCadastro { get; set; }
}