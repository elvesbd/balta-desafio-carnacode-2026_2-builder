using DesignPatternChallenge;
using DesignPatternChallenge.Builders;

Console.WriteLine("=== Sistema de Relatórios (Builder Pattern) ===");

Console.WriteLine("\n--- Director + PDF Builder ---");

var pdfDirector = new ReportDirector(new PdfReportBuilder());
var monthlyPdf = pdfDirector.BuildMonthlySalesReport(2024, 3);
monthlyPdf.Generate();

Console.WriteLine("\n--- Director + Excel Builder ---");

var excelDirector = new ReportDirector(new ExcelReportBuilder());
var quarterlyExcel = excelDirector.BuildQuarterlySalesReport(2024, 1);
quarterlyExcel.Generate();

Console.WriteLine("\n--- Director + HTML Builder ---");

var htmlDirector = new ReportDirector(new HtmlReportBuilder());
var annualHtml = htmlDirector.BuildAnnualSalesReport(2024);
annualHtml.Generate();
