using System;

namespace CodeTest.Library;

public class Queue<T>
{
    private SinglyLinkedListNode<T> Head { get; set; }

    public Queue()
    {
    }

    public Queue(SinglyLinkedListNode<T> head)
    {
        Head = head;
    }

    public void Enqueue(T data)
    {
        var node = new SinglyLinkedListNode<T>(data);
        if (IsEmpty())
        {
            Head = node;
            return;
        }

        Head.Next = node;
    }

    public void Enqueue(SinglyLinkedListNode<T> node)
    {
        if (IsEmpty())
        {
            Head = node;
            return;
        }

        Head.Next = node;
    }

    public bool IsEmpty()
    {
        return Head == null;
    }

    public SinglyLinkedListNode<T> Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidProgramException("Queue is empty");
        }

        var head = Head;
        Head = Head.Next;
        return head;
    }

    public void PrintFront()
    {
        if (IsEmpty())
        {
            throw new InvalidProgramException("Queue is empty");
        }

        Console.WriteLine(Head.Data);
    }
}