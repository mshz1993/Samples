
using System;

namespace ChainOfResponsibilityExample
{
    // کلاس پایه مسئولان تأیید
    public abstract class ApprovalHandler
    {
        // نگهداری مسئول بعدی در زنجیره
        protected ApprovalHandler _next;

        // اتصال مسئول بعدی
        public void SetNext(ApprovalHandler next)
        {
            _next = next;
        }

        // هر مسئول باید این متد را پیاده‌سازی کند
        public abstract void Approve(decimal amount);
    }

    // مدیر: تأیید مبالغ تا 1000
    public class Manager : ApprovalHandler
    {
        public override void Approve(decimal amount)
        {
            if (amount <= 1000)
            {
                Console.WriteLine(
                    $"Manager approved: {amount}");
            }
            else if (_next != null)
            {
                // انتقال درخواست به مسئول بعدی
                _next.Approve(amount);
            }
            else
            {
                Console.WriteLine("No handler available");
            }
        }
    }

    // مدیر مالی: تأیید مبالغ تا 10000
    public class FinanceManager : ApprovalHandler
    {
        public override void Approve(decimal amount)
        {
            if (amount <= 10000)
            {
                Console.WriteLine(
                    $"Finance Manager approved: {amount}");
            }
            else if (_next != null)
            {
                // انتقال درخواست به مسئول بعدی
                _next.Approve(amount);
            }
            else
            {
                Console.WriteLine("No handler available");
            }
        }
    }

    // مدیرعامل: تأیید مبالغ بالاتر
    public class Director : ApprovalHandler
    {
        public override void Approve(decimal amount)
        {
            Console.WriteLine(
                $"Director approved: {amount}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // ایجاد مسئولان
            ApprovalHandler manager = new Manager();
            ApprovalHandler financeManager = new FinanceManager();
            ApprovalHandler director = new Director();

            // تشکیل زنجیره
            manager.SetNext(financeManager);
            financeManager.SetNext(director);

            // ارسال درخواست‌ها از ابتدای زنجیره
            manager.Approve(500);
            manager.Approve(5000);
            manager.Approve(50000);

            Console.ReadKey();
        }
    }
}
