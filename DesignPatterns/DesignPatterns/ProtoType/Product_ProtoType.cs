using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoType
{
    public class Product_ProtoType
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }

        public Product_ProtoType ShallowCopy()
        {
            return (Product_ProtoType)this.MemberwiseClone();
        }

        public Product_ProtoType DeepCopy()
        {
            var clone = (Product_ProtoType)this.MemberwiseClone();

            clone.Category = new Category
            {
                Name = this.Category.Name
            };
            return clone;
        }
    }

    public class Category
    {
        public string Name { get; set; }
    }

    class Product_ProtoType_Program
    {
        public static void Main()
        {
            var original = new Product_ProtoType
            {
                Name = "Laptop",
                Price = 50000,
                Category = new Category { Name = "Computer" }
            };

            Product_ProtoType shallowCopy = original.ShallowCopy();
            Product_ProtoType deepCopy = original.DeepCopy();


            Console.WriteLine("Before Changes:");
            Console.WriteLine("----------------");

            Console.WriteLine($"original: {original.Name} - {original.Price} - {original.Category.Name}");
            Console.WriteLine($"shallowCopy: {shallowCopy.Name} - {shallowCopy.Price} - {shallowCopy.Category.Name}");
            Console.WriteLine($"deepCopy: {deepCopy.Name} - {deepCopy.Price} - {deepCopy.Category.Name}");


            shallowCopy.Price = 60000;
            shallowCopy.Category.Name = "Mobile";


            deepCopy.Price = 70000;
            deepCopy.Category.Name = "Tablet";



            Console.WriteLine("----------------");
            Console.WriteLine("After Changes:");
            Console.WriteLine("----------------");

            Console.WriteLine($"original: {original.Name} - {original.Price} - {original.Category.Name}");
            Console.WriteLine($"shallowCopy: {shallowCopy.Name} - {shallowCopy.Price} - {shallowCopy.Category.Name}");
            Console.WriteLine($"deepCopy: {deepCopy.Name} - {deepCopy.Price} - {deepCopy.Category.Name}");


        }
    }
}
