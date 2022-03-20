using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTest.Library
{
    public class LinkedList
    {
        public SinglyLinkedListNode<int> MakeLinkedListFromTail(IEnumerable<string> stringArray)
        {
            return stringArray
                .Select(c => Convert.ToInt32(c))
                .Aggregate<int, SinglyLinkedListNode<int>>(null, InsertNodeToTail);
        }

        public SinglyLinkedListNode<T> InsertNodeToTail<T>(SinglyLinkedListNode<T> head, T data)
        {
            var node = new SinglyLinkedListNode<T>(data);
            if (head == null) return node;
            var temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = node;
            return head;
        }
    }
}