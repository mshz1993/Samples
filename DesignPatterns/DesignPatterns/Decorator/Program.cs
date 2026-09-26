using System;

// Abstract Pizza class (All classes extend from this)
abstract class Pizza
{
    // it is an abstract pizza
    protected string description = "Unknown Pizza";

    public virtual string GetDescription()
    {
        return description;
    }

    public abstract int GetCost();
}

// The decorator class: It extends Pizza to be interchangeable with it toppings decorator can also be implemented as an interface
abstract class ToppingsDecorator : Pizza
{
    public abstract new string GetDescription();
}

// Concrete pizza classes
class PeppyPaneer : Pizza
{
    public PeppyPaneer() { description = "PeppyPaneer"; }
    public override int GetCost() { return 100; }
}

class FarmHouse : Pizza
{
    public FarmHouse() { description = "FarmHouse"; }
    public override int GetCost() { return 200; }
}

class Margherita : Pizza
{
    public Margherita() { description = "Margherita"; }
    public override int GetCost() { return 100; }
}

class ChickenFiesta : Pizza
{
    public ChickenFiesta() { description = "ChickenFiesta"; }
    public override int GetCost() { return 200; }
}

class SimplePizza : Pizza
{
    public SimplePizza() { description = "SimplePizza"; }
    public override int GetCost() { return 50; }
}

// Concrete toppings classes
class FreshTomato : ToppingsDecorator
{
    // we need a reference to obj we are decorating
    Pizza pizza;

    public FreshTomato(Pizza pizza) { this.pizza = pizza; }
    public override string GetDescription()
    {
        return pizza.GetDescription() + ", Fresh Tomato ";
    }
    public override int GetCost() { return 40 + pizza.GetCost(); }
}

class Barbeque : ToppingsDecorator
{
    Pizza pizza;

    public Barbeque(Pizza pizza) { this.pizza = pizza; }
    public override string GetDescription()
    {
        return pizza.GetDescription() + ", Barbeque ";
    }
    public override int GetCost()
    {
        // Check if the base pizza is null
        return pizza != null ? 90 + pizza.GetCost() : 90;
    }
}

class Paneer : ToppingsDecorator
{
    Pizza pizza;

    public Paneer(Pizza pizza) { this.pizza = pizza; }
    public override string GetDescription()
    {
        return pizza.GetDescription() + ", Paneer ";
    }
    public override int GetCost() { return 70 + pizza.GetCost(); }
}

// Other toppings can be coded in a similar way

// Driver class and method
class PizzaStore
{
    static void Main(string[] args)
    {
        // create new margherita pizza
        Pizza pizza = new Margherita();
        Console.WriteLine(pizza.GetDescription() +
                        " Cost :" + pizza.GetCost());

        // create new FarmHouse pizza
        Pizza pizza2 = new FarmHouse();

        // decorate it with freshtomato topping
        pizza2 = new FreshTomato(pizza2);

        // decorate it with paneer topping
        pizza2 = new Paneer(pizza2);

        Console.WriteLine(pizza2.GetDescription() +
                        " Cost :" + pizza2.GetCost());

        Pizza pizza3 = new Barbeque(null); // no specific pizza
        Console.WriteLine(pizza3.GetDescription() + " Cost :" + pizza3.GetCost());
    }
}
