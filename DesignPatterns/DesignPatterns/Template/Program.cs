
using System;

namespace TemplateMethodPatternExample
{
    // 1. کلاس پایه با الگوریتم کلی
    public abstract class ReportGenerator
    {
        // Template Method: ترتیب مراحل را مشخص می‌کند
        public void GenerateReport()
        {
            GetData();
            ProcessData();
            ExportReport();
        }

        // مراحل مشترک
        private void GetData()
        {
            Console.WriteLine("Getting data...");
        }

        private void ProcessData()
        {
            Console.WriteLine("Processing data...");
        }

        // مرحله‌ای که فرزندها پیاده‌سازی می‌کنند
        protected abstract void ExportReport();
    }

    // 2. تولید گزارش PDF
    public class PdfReportGenerator : ReportGenerator
    {
        protected override void ExportReport()
        {
            Console.WriteLine("Exporting report to PDF.");
        }
    }

    // 3. تولید گزارش Excel
    public class ExcelReportGenerator : ReportGenerator
    {
        protected override void ExportReport()
        {
            Console.WriteLine("Exporting report to Excel.");
        }
    }

    // 4. اجرای برنامه
    internal class Program
    {
        static void Main(string[] args)
        {
            ReportGenerator pdfReport =
                new PdfReportGenerator();

            pdfReport.GenerateReport();

            Console.WriteLine();

            ReportGenerator excelReport =
                new ExcelReportGenerator();

            excelReport.GenerateReport();

            Console.ReadKey();
        }
    }
}
