using System;
using System.Collections.Generic;
using System.Linq;
using CodeTest.Library;

namespace HackerRank.Solutions
{
    public class LinkedListSolution
    {
        public SinglyLinkedListNode<int> MakeLinkedListFromTail(IEnumerable<string> stringArray)
        {
            return stringArray
                .Select(c => Convert.ToInt32(c))
                .Aggregate<int, SinglyLinkedListNode<int>>(null, InsertNodeToTail);
        }

        public SinglyLinkedListNode<int> MakeLinkedListFromHead(IEnumerable<string> stringArray)
        {
            return stringArray
                .Select(c => Convert.ToInt32(c))
                .Aggregate<int, SinglyLinkedListNode<int>>(null, InsertNodeToHead);
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

        public SinglyLinkedListNode<T> InsertNodeToHead<T>(SinglyLinkedListNode<T> head, T data)
        {
            var newHead = new SinglyLinkedListNode<T>(data);
            if (head != null)
            {
                newHead.Next = head;
            }

            return newHead;
        }

        public SinglyLinkedListNode<T> InsertNodeAtPosition<T>(SinglyLinkedListNode<T> head, T data,
            int position)
        {
            var newNode = new SinglyLinkedListNode<T>(data);
            if (head == null)
            {
                return newNode;
            }

            var temp = head;
            var i = 0;
            while (i < position - 1 && temp != null)
            {
                temp = temp.Next;
                i++;
            }

            if (temp == null) return newNode;
            newNode.Next = temp.Next;
            temp.Next = newNode;
            return head;
        }

        public SinglyLinkedListNode<T> DeleteNodeAtPosition<T>(SinglyLinkedListNode<T> head, int position)
        {
            if (head == null) return null;
            if (position == 0)
            {
                return head.Next;
            }

            var i = 0;
            var node = head;
            while (i < position - 1)
            {
                node = node.Next;
                i++;
            }

            node.Next = node.Next.Next;
            return head;
        }

        public string PrintInReverse<T>(SinglyLinkedListNode<T> head)
        {
            if (head == null) return string.Empty;
            var recursiveResult = PrintInReverse(head.Next);
            return recursiveResult + head.Data;
        }

        public SinglyLinkedListNode<T> ReversedLinkedList<T>(SinglyLinkedListNode<T> head)
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

        public SinglyLinkedListNode<int> MergeTwoLinkedLists(SinglyLinkedListNode<int> headOne,
            SinglyLinkedListNode<int> headTwo)
        {
            if (headOne == null && headTwo == null) return null;
            if (headOne == null) return headTwo;
            if (headTwo == null) return headOne;
            if (headOne.Data == headTwo.Data)
            {
                var nextOne = headOne.Next;
                var nextTwo = headTwo.Next;
                headOne.Next = headTwo;
                headTwo.Next = nextOne;
                headOne.Next.Next = MergeTwoLinkedLists(nextOne, nextTwo);
                return headOne;
            }

            if (headOne.Data < headTwo.Data)
            {
                headOne.Next = MergeTwoLinkedLists(headOne.Next, headTwo);
                return headOne;
            }

            headTwo.Next = MergeTwoLinkedLists(headOne, headTwo.Next);
            return headTwo;
        }

        public SinglyLinkedListNode<int> SwapNodeInPairs(SinglyLinkedListNode<int> head)
        {
            if (head == null) return null;
            if (head.Next == null) return head;
            var newHead = head.Next;
            head.Next = SwapNodeInPairs(newHead.Next);
            newHead.Next = head;
            return newHead;
        }

        public SinglyLinkedListNode<T> RemoveNodeByItsDataValue<T>(SinglyLinkedListNode<T> head, T value)
        {
            while (true)
            {
                if (head == null) return null;
                if (head.Data.Equals(value))
                {
                    if (head.Next == null) return null;
                    head = head.Next;
                    continue;
                }

                var next = head.Next;
                var prev = head;
                while (next != null)
                {
                    if (next.Data.Equals(value))
                    {
                        next = next.Next;
                        prev.Next = null;
                        continue;
                    }

                    prev.Next = next;
                    prev = next;
                    next = next.Next;
                }

                return head;
            }
        }

        public void DeleteNode<T>(SinglyLinkedListNode<T> node)
        {
            if (node?.Next == null) return;
            node.Data = node.Next.Data;
            node.Next = node.Next.Next;
        }
    }
}