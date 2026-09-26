using System;

// Abstract expression class
abstract class Expression
{
    public abstract int Interpret();
}

// Terminal expression class
class NumberExpression : Expression
{
    private int number;

    public NumberExpression(int number)
    {
        this.number = number;
    }

    public override int Interpret()
    {
        return number;
    }
}

// Non-terminal expression class
class AdditionExpression : Expression
{
    private Expression left;
    private Expression right;

    public AdditionExpression(Expression left, Expression right)
    {
        this.left = left;
        this.right = right;
    }

    public override int Interpret()
    {
        return left.Interpret() + right.Interpret();
    }
}

// Client code
class Program
{
    static void Main()
    {
        // Creating expressions: 1 + 2
        Expression expression = new AdditionExpression(new NumberExpression(1), new NumberExpression(2));

        // Interpreting and evaluating the expression
        int result = expression.Interpret();
        Console.WriteLine("Result: " + result); // Output: 3
    }
}
