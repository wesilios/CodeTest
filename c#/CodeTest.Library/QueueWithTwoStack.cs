using System;
using System.Collections.Generic;

namespace CodeTest.Library;

public class QueueWithTwoStack<T>
{
    private Stack<T> StackOne { get; }
    private Stack<T> StackTwo { get; }

    public QueueWithTwoStack()
    {
        StackOne = new Stack<T>();
        StackTwo = new Stack<T>();
    }

    public void Enqueue(T data)
    {
        StackOne.Push(data);
    }

    public void Dequeue()
    {
        if (StackTwo.Count == 0)
        {
            MoveStack();
        }

        StackTwo.Pop();
    }

    public void PrintFront()
    {
        if (StackTwo.Count == 0)
        {
            MoveStack();
        }

        Console.WriteLine(StackTwo.Peek());
    }

    public void MoveStack()
    {
        while (StackOne.Count != 0)
        {
            StackTwo.Push(StackOne.Pop());
        }
    }
}