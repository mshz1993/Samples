using System;

// Abstract Product
public abstract class Document
{
    public abstract void Open();
}

// Concrete Product 1
public class WordDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening Word document.");
    }
}

// Concrete Product 2
public class PDFDocument : Document
{
    public override void Open()
    {
        Console.WriteLine("Opening PDF document.");
    }
}

// Creator
public abstract class DocumentCreator
{
    protected abstract Document CreateDocument();

    public void OpenDocument()
    {
        Document document = CreateDocument();
        document.Open();
    }
}

// Concrete Creator 1
public class WordDocumentCreator : DocumentCreator
{
    protected override Document CreateDocument()
    {
        return new WordDocument();
    }
}

// Concrete Creator 2
public class PDFDocumentCreator : DocumentCreator
{
    protected override Document CreateDocument()
    {
        return new PDFDocument();
    }
}

//Client
class Program
{
    //static void Main()
    //{
    //    DocumentCreator creator;

    //    creator = new WordDocumentCreator();
    //    creator.OpenDocument();

    //    creator = new PDFDocumentCreator();
    //    creator.OpenDocument();
    //}
}