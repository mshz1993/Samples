using System;

namespace ProxyPattern
{
    // =========================================================
    // Subject
    // =========================================================
    // این Interface قرارداد مشترک بین RealDocument و Proxy است.
    // Client فقط این Interface را می‌شناسد.
    public interface IDocument
    {
        void Read();
    }


    // =========================================================
    // Real Subject
    // =========================================================
    // این کلاس شیء اصلی است که عملیات واقعی را انجام می‌دهد.
    //
    // Client نباید مستقیماً با این کلاس کار کند.
    internal class RealDocument : IDocument
    {
        public void Read()
        {
            Console.WriteLine("Document is being read...");
        }
    }


    // =========================================================
    // Proxy
    // =========================================================
    // Proxy همان Interface یعنی IDocument را پیاده‌سازی می‌کند.
    //
    // Client به جای RealDocument با DocumentProxy کار می‌کند.
    //
    // Proxy می‌تواند قبل از رسیدن درخواست به RealDocument
    // کارهایی مثل:
    // - بررسی دسترسی
    // - Logging
    // - Caching
    // - Lazy Loading
    // انجام دهد.
    public class DocumentProxy : IDocument
    {
        private readonly bool _hasAccess;

        public DocumentProxy(bool hasAccess)
        {
            _hasAccess = hasAccess;
        }

        public void Read()
        {
            // قبل از دسترسی به شیء اصلی، دسترسی را بررسی می‌کنیم.
            if (!_hasAccess)
            {
                Console.WriteLine("Access Denied!");
                return;
            }

            // اگر دسترسی وجود داشت،
            // Proxy شیء اصلی را ایجاد می‌کند.
            var document = new RealDocument();

            // سپس درخواست را به شیء اصلی منتقل می‌کند.
            document.Read();
        }
    }


    // =========================================================
    // Client
    // =========================================================
    // Client فقط IDocument را می‌شناسد.
    //
    // Client اصلاً کاری ندارد که پشت Proxy چه اتفاقی می‌افتد.
    public class Program
    {
        public static void Main()
        {
            // Client به جای RealDocument،
            // یک Proxy دریافت می‌کند.
            IDocument document = new DocumentProxy(true);

            // Client فقط Read را صدا می‌زند.
            //
            // ابتدا Proxy اجرا می‌شود،
            // Proxy دسترسی را بررسی می‌کند،
            // سپس در صورت مجاز بودن RealDocument را اجرا می‌کند.
            document.Read();


            Console.WriteLine("----------------");


            // این بار کاربر دسترسی ندارد.
            IDocument document2 = new DocumentProxy(false);

            // درخواست به Proxy می‌رسد.
            //
            // Proxy متوجه می‌شود دسترسی وجود ندارد
            // و اصلاً RealDocument را اجرا نمی‌کند.
            document2.Read();
        }
    }
}