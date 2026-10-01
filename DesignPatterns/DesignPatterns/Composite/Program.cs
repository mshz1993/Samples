using System;
using System.Collections.Generic;
using System.Linq;

public interface IFileSystemItem
{
    int GetSize();
}

// Leaf
public class File : IFileSystemItem
{
    private readonly int size;

    public File(int size)
    {
        this.size = size;
    }

    public int GetSize()
    {
        return size;
    }
}

// Composite
public class Folder : IFileSystemItem
{
    private readonly List<IFileSystemItem> items = new();

    public void Add(IFileSystemItem item)
    {
        items.Add(item);
    }

    public int GetSize()
    {
        return items.Sum(x => x.GetSize());
    }
}

//class Program
//{
//    static void Main()
//    {
//        var file1 = new File(100);
//        var file2 = new File(200);
//        var file3 = new File(300);

//        var imagesFolder = new Folder();
//        imagesFolder.Add(file2);
//        imagesFolder.Add(file3);

//        var documentsFolder = new Folder();
//        documentsFolder.Add(file1);
//        documentsFolder.Add(imagesFolder);

//        Console.WriteLine(documentsFolder.GetSize());
//    }
//}