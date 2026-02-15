using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Builders;

public class ExcelReportBuilder : IReportBuilder
{
    private readonly Report _report = new();

    public ExcelReportBuilder()
    {
        _report.Format = "Excel";
        _report.Orientation = "Landscape";
    }

    public IReportBuilder SetTitle(string title)
    {
        _report.Title = title;
        return this;
    }

    public IReportBuilder SetPeriod(DateTime startDate, DateTime endDate)
    {
        _report.StartDate = startDate;
        _report.EndDate = endDate;
        return this;
    }

    public IReportBuilder WithHeader(string headerText)
    {
        _report.IncludeHeader = true;
        _report.HeaderText = headerText;
        return this;
    }

    public IReportBuilder WithFooter(string footerText)
    {
        _report.IncludeFooter = true;
        _report.FooterText = footerText;
        return this;
    }

    public IReportBuilder WithChart(string chartType)
    {
        _report.IncludeCharts = true;
        _report.ChartType = chartType;
        return this;
    }

    public IReportBuilder WithColumns(params string[] columns)
    {
        _report.Columns.AddRange(columns);
        return this;
    }

    public IReportBuilder WithFilters(params string[] filters)
    {
        _report.Filters.AddRange(filters);
        return this;
    }

    public IReportBuilder WithSorting(string sortBy)
    {
        _report.SortBy = sortBy;
        return this;
    }

    public IReportBuilder WithGrouping(string groupBy)
    {
        _report.GroupBy = groupBy;
        return this;
    }

    public IReportBuilder WithTotals()
    {
        _report.IncludeTotals = true;
        return this;
    }

    public IReportBuilder WithSummary()
    {
        _report.IncludeSummary = true;
        return this;
    }

    public IReportBuilder SetOrientation(string orientation)
    {
        _report.Orientation = orientation;
        return this;
    }

    public IReportBuilder SetPageSize(string pageSize)
    {
        _report.PageSize = pageSize;
        return this;
    }

    public IReportBuilder WithPageNumbers()
    {
        _report.IncludePageNumbers = true;
        return this;
    }

    public IReportBuilder WithLogo(string logoPath)
    {
        _report.CompanyLogo = logoPath;
        return this;
    }

    public IReportBuilder WithWaterMark(string waterMark)
    {
        _report.WaterMark = waterMark;
        return this;
    }

    public Report Build()
    {
        if (string.IsNullOrEmpty(_report.Title))
            throw new InvalidOperationException("Título é obrigatório.");

        if (_report.EndDate <= _report.StartDate)
            throw new InvalidOperationException("Período inválido.");

        return _report.Columns.Count == 0
            ? throw new InvalidOperationException("Excel precisa de pelo menos uma coluna.")
            : _report;
    }
}