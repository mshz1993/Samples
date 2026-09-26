// Abstraction
public abstract class Shape
{
    protected IRenderer renderer;

    public Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }
    public abstract void Draw();
}
public class Circle : Shape
{
    private float radius;
    public Circle(IRenderer renderer, float radius) : base(renderer)
    {
        this.radius = radius;
    }
    public override void Draw()
    {
        renderer.RenderCircle(radius);
    }
}
public class Square : Shape
{
    private float side;
    public Square(IRenderer renderer, float side) : base(renderer)
    {
        this.side = side;
    }
    public override void Draw()
    {
        renderer.RenderSquare(side);
    }
}
// Implementation
public interface IRenderer
{
    void RenderCircle(float radius);
    void RenderSquare(float side);
}
// Concrete Implementation
public class VectorRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Drawing a circle of radius {radius} using vector graphics.");
    }
    public void RenderSquare(float side)
    {
        Console.WriteLine($"Drawing a square of side {side} using vector graphics.");
    }
}
// Concrete Implementation
public class RasterRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Drawing a circle of radius {radius} using raster graphics.");
    }
    public void RenderSquare(float side)
    {
        Console.WriteLine($"Drawing a square of side {side} using raster graphics.");
    }
}
class MainClass
{
    static void Main(string[] args)
    {
        // Client code
        var vectorCircle = new Circle(new VectorRenderer(), 5);
        vectorCircle.Draw(); // Output: Drawing a circle of radius 5 using vector graphics.
        var rasterSquare = new Square(new RasterRenderer(), 10);
        rasterSquare.Draw(); // Output: Drawing a square of side 10 using raster graphics.
    }
}

