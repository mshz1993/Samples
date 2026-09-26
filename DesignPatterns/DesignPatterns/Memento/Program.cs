using System;
using System.Collections.Generic;

// Memento
public class EditorMemento
{
    public string Content { get; }

    public EditorMemento(string content)
    {
        Content = content;
    }
}

// Originator
public class TextEditor
{
    private string content;

    public string Content
    {
        get => content;
        set
        {
            content = value;
            Console.WriteLine($"Current Content: {content}");
        }
    }

    public EditorMemento Save()
    {
        return new EditorMemento(content);
    }

    public void Restore(EditorMemento memento)
    {
        content = memento.Content;
        Console.WriteLine($"Restored Content: {content}");
    }
}

// Caretaker
public class History
{
    private List<EditorMemento> states = new List<EditorMemento>();

    public void SaveState(EditorMemento memento)
    {
        states.Add(memento);
    }

    public EditorMemento GetLastState()
    {
        if (states.Count == 0)
            return null;

        var lastState = states[^1];
        states.RemoveAt(states.Count - 1);
        return lastState;
    }
}

// Client Code
class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor();
        History history = new History();

        // Initial content
        editor.Content = "Hello, ";

        // Save state
        history.SaveState(editor.Save());

        // Make changes
        editor.Content += "world!";

        // Save state
        history.SaveState(editor.Save());

        // Undo
        editor.Restore(history.GetLastState());
    }
}
