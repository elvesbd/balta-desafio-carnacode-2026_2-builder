using DesignPatternChallenge.Models;
using DesignPatternChallenge.Builders;

namespace DesignPatternChallenge;

public class ReportDirector(IReportBuilder builder)
{
    private readonly IReportBuilder _builder = builder;

    public Report BuildMonthlySalesReport(int year, int month)
    {
        var startDate = new DateTime(year, month, 1);
        var endDate = startDate.AddMonths(1).AddDays(-1);

        return _builder
            .SetTitle($"Vendas Mensais - {startDate:MMMM/yyyy}")
            .SetPeriod(startDate, endDate)
            .WithHeader("Relatório de Vendas Mensais")
            .WithFooter("Confidencial")
            .WithColumns("Produto", "Quantidade", "Valor")
            .WithChart("Bar")
            .WithGrouping("Categoria")
            .WithSorting("Valor")
            .WithTotals()
            .WithSummary()
            .WithLogo("logo.png")
            .WithPageNumbers()
            .Build();
    }
    
    public Report BuildQuarterlySalesReport(int year, int quarter)
    {
        var startMonth = (quarter - 1) * 3 + 1;
        var startDate = new DateTime(year, startMonth, 1);
        var endDate = startDate.AddMonths(3).AddDays(-1);

        return _builder
            .SetTitle($"Vendas Trimestrais - Q{quarter}/{year}")
            .SetPeriod(startDate, endDate)
            .WithHeader("Relatório Trimestral de Vendas")
            .WithFooter("Uso Interno")
            .WithColumns("Vendedor", "Região", "Total")
            .WithChart("Line")
            .WithGrouping("Região")
            .WithTotals()
            .WithSummary()
            .SetOrientation("Landscape")
            .Build();
    }

    public Report BuildAnnualSalesReport(int year)
    {
        return _builder
            .SetTitle($"Vendas Anuais - {year}")
            .SetPeriod(new DateTime(year, 1, 1), new DateTime(year, 12, 31))
            .WithHeader("Relatório Anual de Vendas")
            .WithFooter("Confidencial")
            .WithColumns("Mês", "Produto", "Quantidade", "Valor")
            .WithChart("Pie")
            .WithGrouping("Mês")
            .WithSorting("Mês")
            .WithTotals()
            .WithSummary()
            .WithLogo("logo.png")
            .WithWaterMark("Confidencial")
            .WithPageNumbers()
            .SetOrientation("Landscape")
            .SetPageSize("A3")
            .Build();
    }
}