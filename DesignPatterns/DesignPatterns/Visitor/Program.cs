
using System;

namespace VisitorPatternExample
{
    // 1. قرارداد بازدیدکننده
    public interface IProductVisitor
    {
        void Visit(Book book);
        void Visit(Electronic electronic);
    }

    // 2. قرارداد محصولات
    public interface IProduct
    {
        void Accept(IProductVisitor visitor);
    }

    // 3. محصول اول: کتاب
    public class Book : IProduct
    {
        public decimal Price { get; }

        public Book(decimal price)
        {
            Price = price;
        }

        public void Accept(IProductVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // 4. محصول دوم: کالای الکترونیکی
    public class Electronic : IProduct
    {
        public decimal Price { get; }

        public Electronic(decimal price)
        {
            Price = price;
        }

        public void Accept(IProductVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    // 5. عملیات جدید: محاسبه مالیات
    public class TaxVisitor : IProductVisitor
    {
        public void Visit(Book book)
        {
            decimal tax = book.Price * 0.05m;

            Console.WriteLine(
                $"Book tax: {tax}");
        }

        public void Visit(Electronic electronic)
        {
            decimal tax = electronic.Price * 0.15m;

            Console.WriteLine(
                $"Electronic tax: {tax}");
        }
    }

    // 6. اجرای برنامه
    internal class Program
    {
        static void Main(string[] args)
        {
            IProduct book = new Book(100);
            IProduct electronic = new Electronic(1000);

            IProductVisitor taxVisitor = new TaxVisitor();

            book.Accept(taxVisitor);
            electronic.Accept(taxVisitor);

            Console.ReadKey();
        }
    }
}
