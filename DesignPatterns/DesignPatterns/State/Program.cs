using System;

// State interface
public interface IState
{
    void Handle();
}

// Concrete States
public class DraftState : IState
{
    public void Handle()
    {
        Console.WriteLine("Document is in Draft state. Editing is allowed.");
    }
}

public class ReviewState : IState
{
    public void Handle()
    {
        Console.WriteLine("Document is in Review state. Editing is restricted. Reviewers can provide feedback.");
    }
}

public class PublishedState : IState
{
    public void Handle()
    {
        Console.WriteLine("Document is in Published state. Editing is not allowed. It is publicly available.");
    }
}

// Context
public class Document
{
    private IState currentState;

    public Document()
    {
        currentState = new DraftState(); // Initial state is Draft
    }

    public void ChangeState(IState newState)
    {
        currentState = newState;
    }

    public void Request()
    {
        currentState.Handle();
    }
}

// Client Code
class Program
{
    static void Main()
    {
        Document document = new Document();

        document.Request(); // Output: Document is in Draft state. Editing is allowed.

        document.ChangeState(new ReviewState());
        document.Request(); // Output: Document is in Review state. Editing is restricted. Reviewers can provide feedback.

        document.ChangeState(new PublishedState());
        document.Request(); // Output: Document is in Published state. Editing is not allowed. It is publicly available.
    }
}
