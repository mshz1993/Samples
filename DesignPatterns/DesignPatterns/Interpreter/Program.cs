
using System;

namespace InterpreterPatternExample
{
    // 1. قرارداد مشترک تمام عبارت‌ها
    public interface IExpression
    {
        bool Interpret(int value);
    }

    // 2. بررسی بزرگ‌تر بودن از یک عدد
    public class GreaterThanExpression : IExpression
    {
        private readonly int _number;

        public GreaterThanExpression(int number)
        {
            _number = number;
        }

        public bool Interpret(int value)
        {
            return value > _number;
        }
    }

    // 3. بررسی کوچک‌تر بودن از یک عدد
    public class LessThanExpression : IExpression
    {
        private readonly int _number;

        public LessThanExpression(int number)
        {
            _number = number;
        }

        public bool Interpret(int value)
        {
            return value < _number;
        }
    }

    // 4. ترکیب دو شرط با AND
    public class AndExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        public AndExpression(
            IExpression left,
            IExpression right)
        {
            _left = left;
            _right = right;
        }

        public bool Interpret(int value)
        {
            return _left.Interpret(value)
                && _right.Interpret(value);
        }
    }

    // 5. اجرای برنامه
    internal class Program
    {
        static void Main(string[] args)
        {
            // قانون: عدد بزرگ‌تر از 100 و کوچک‌تر از 1000 باشد
            IExpression greaterThan100 =
                new GreaterThanExpression(100);

            IExpression lessThan1000 =
                new LessThanExpression(1000);

            IExpression rule =
                new AndExpression(
                    greaterThan100,
                    lessThan1000);

            Console.WriteLine(rule.Interpret(500));  // True
            Console.WriteLine(rule.Interpret(1500)); // False
            Console.WriteLine(rule.Interpret(50));   // False

            Console.ReadKey();
        }
    }
}
