using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Builders;

public interface IReportBuilder
{
    IReportBuilder SetTitle(string title);
    IReportBuilder SetPeriod(DateTime startDate, DateTime endDate);
    IReportBuilder WithHeader(string headerText);
    IReportBuilder WithFooter(string footerText);
    IReportBuilder WithChart(string chartType);
    IReportBuilder WithColumns(params string [] columns);
    IReportBuilder WithFilters(params string[] filters);
    IReportBuilder WithSorting(string sortBy);
    IReportBuilder WithGrouping(string groupBy);
    IReportBuilder WithTotals();
    IReportBuilder WithSummary();
    IReportBuilder SetOrientation(string orientation);
    IReportBuilder SetPageSize(string pageSize);
    IReportBuilder WithPageNumbers();
    IReportBuilder WithLogo(string logoPath);
    IReportBuilder WithWaterMark(string waterMarkText);
    Report Build();
}