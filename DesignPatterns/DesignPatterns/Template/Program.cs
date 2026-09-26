using System;

abstract class ReportTemplate
{
    // Template method defining the overall structure
    public void GenerateReport()
    {
        Console.WriteLine("Generating Report Header");
        FetchData();
        FormatData();
        DisplayReport();
    }

    // Abstract methods to be implemented by concrete classes
    protected abstract void FetchData();
    protected abstract void FormatData();

    // Common implementation
    private void DisplayReport()
    {
        Console.WriteLine("Displaying Report");
    }
}

class PdfReport : ReportTemplate
{
    // Concrete implementation for PDF report
    protected override void FetchData()
    {
        Console.WriteLine("Fetching Data for PDF Report");
    }

    protected override void FormatData()
    {
        Console.WriteLine("Formatting Data for PDF Report");
    }
}

class ExcelReport : ReportTemplate
{
    // Concrete implementation for Excel report
    protected override void FetchData()
    {
        Console.WriteLine("Fetching Data for Excel Report");
    }

    protected override void FormatData()
    {
        Console.WriteLine("Formatting Data for Excel Report");
    }
}

class Program
{
    static void Main()
    {
        ReportTemplate pdfReport = new PdfReport();
        pdfReport.GenerateReport();

        ReportTemplate excelReport = new ExcelReport();
        excelReport.GenerateReport();
    }
}
