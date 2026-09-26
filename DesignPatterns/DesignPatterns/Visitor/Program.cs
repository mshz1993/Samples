using System;
using System.Collections.Generic;

// Element interface
interface IDocumentElement
{
    void Accept(IVisitor visitor);
}

// Concrete element 1: Paragraph
class Paragraph : IDocumentElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitParagraph(this);
    }
}

// Concrete element 2: Table
class Table : IDocumentElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitTable(this);
    }
}

// Visitor interface
interface IVisitor
{
    void VisitParagraph(Paragraph paragraph);
    void VisitTable(Table table);
}

// Concrete visitor 1: RenderVisitor
class RenderVisitor : IVisitor
{
    public void VisitParagraph(Paragraph paragraph)
    {
        Console.WriteLine("Rendering Paragraph");
    }

    public void VisitTable(Table table)
    {
        Console.WriteLine("Rendering Table");
    }
}

// Concrete visitor 2: WordCountVisitor
class WordCountVisitor : IVisitor
{
    public void VisitParagraph(Paragraph paragraph)
    {
        Console.WriteLine("Counting words in Paragraph");
    }

    public void VisitTable(Table table)
    {
        Console.WriteLine("Counting words in Table");
    }
}

// Client code
class Client
{
    static void Main()
    {
        List<IDocumentElement> elements = new List<IDocumentElement>
        {
            new Paragraph(),
            new Table()
        };

        IVisitor renderVisitor = new RenderVisitor();
        IVisitor wordCountVisitor = new WordCountVisitor();

        foreach (var element in elements)
        {
            element.Accept(renderVisitor);
            element.Accept(wordCountVisitor);
        }
    }
}
