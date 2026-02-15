namespace DesignPatternChallenge.Models;

public class Report
{
    public string Title { get; set; } = string.Empty;
    public string Format { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IncludeHeader { get; set; }
    public string HeaderText { get; set; } = string.Empty;
    public bool IncludeFooter { get; set; }
    public string FooterText { get; set; } = string.Empty;
    public bool IncludeCharts { get; set; }
    public string ChartType { get; set; } = string.Empty;
    public bool IncludeSummary { get; set; }
    public List<string> Columns { get; set; } = [];
    public List<string> Filters { get; set; } = [];
    public string SortBy { get; set; } = string.Empty;
    public string GroupBy { get; set; } = string.Empty;
    public bool IncludeTotals { get; set; }
    public string Orientation { get; set; } = "Portrait";
    public string PageSize { get; set; } = "A4";
    public bool IncludePageNumbers { get; set; }
    public string CompanyLogo { get; set; } = string.Empty;
    public string WaterMark { get; set; } = string.Empty;

    public void Generate()
    {
        Console.WriteLine($"\n=== Gerando Relatório [{Format}]: {Title} ===");
        Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");
        Console.WriteLine($"Orientação: {Orientation} | Página: {PageSize}");

        if (IncludeHeader)
            Console.WriteLine($"Cabeçalho: {HeaderText}");

        if (Columns.Count > 0)
            Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");

        if (Filters.Count > 0)
            Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");

        if (IncludeCharts)
            Console.WriteLine($"Gráfico: {ChartType}");

        if (!string.IsNullOrEmpty(GroupBy))
            Console.WriteLine($"Agrupado por: {GroupBy}");

        if (!string.IsNullOrEmpty(SortBy))
            Console.WriteLine($"Ordenado por: {SortBy}");

        if (IncludeTotals)
            Console.WriteLine("Totais: Sim");

        if (IncludeSummary)
            Console.WriteLine("Resumo: Sim");

        if (!string.IsNullOrEmpty(CompanyLogo))
            Console.WriteLine($"Logo: {CompanyLogo}");

        if (!string.IsNullOrEmpty(WaterMark))
            Console.WriteLine($"Marca d'água: {WaterMark}");

        if (IncludePageNumbers)
            Console.WriteLine("Números de página: Sim");

        if (IncludeFooter)
            Console.WriteLine($"Rodapé: {FooterText}");

        Console.WriteLine("Relatório gerado com sucesso!");
    }
}