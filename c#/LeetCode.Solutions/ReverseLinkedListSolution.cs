using CodeTest.Library;

namespace LeetCode.Solutions;

public class ReverseLinkedListSolution
{
    public SinglyLinkedListNode<T> ReverseLinkedList<T>(SinglyLinkedListNode<T> head)
    {
        if (head == null) return null;
        var current = head;
        SinglyLinkedListNode<T> prev = null;
        while (current != null)
        {
            var next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }

    public SinglyLinkedListNode<T> ReverseLinkedListInBetween<T>(SinglyLinkedListNode<T> head, int left, int right)
    {
        if (left == 0 || right == 0 || left >= right) return head;
        var currentPosition = 1;
        var currentNode = head;
        SinglyLinkedListNode<T> prev = null;
        while (currentPosition < left)
        {
            prev = currentNode;
            currentNode = currentNode.Next;
            currentPosition++;
        }

        var prevLeftNode = prev;
        var leftNode = currentNode;
        SinglyLinkedListNode<T> rightNode = null;
        while (currentPosition <= right)
        {
            if (currentPosition == right)
            {
                rightNode = currentNode;
                leftNode.Next = currentNode.Next;
            }

            var next = currentNode.Next;
            currentNode.Next = prev;
            prev = currentNode;
            currentNode = next;

            currentPosition++;
        }

        if (prevLeftNode == null) return rightNode;
        prevLeftNode.Next = rightNode;
        return head;

    }
}