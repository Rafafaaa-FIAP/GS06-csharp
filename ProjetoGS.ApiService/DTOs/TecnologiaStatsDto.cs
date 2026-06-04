namespace ProjetoGS.ApiService.DTOs;

public class TecnologiaStatsDto
{
    public int TotalTecnologias { get; set; }

    public int MissoesMapeadas { get; set; }

    public int SetoresBeneficiados { get; set; }

    public List<TecnologiaPorCategoriaDto> TecnologiasPorCategoria { get; set; } = [];

    public List<UltimaTecnologiaDto> UltimasTecnologias { get; set; } = [];
}

public class TecnologiaPorCategoriaDto
{
    public string Categoria { get; set; } = string.Empty;

    public int Total { get; set; }
}

public class UltimaTecnologiaDto
{
    public int Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string MissaoOrigem { get; set; } = string.Empty;

    public string Categoria { get; set; } = string.Empty;

    public DateTime DataCadastro { get; set; }
}