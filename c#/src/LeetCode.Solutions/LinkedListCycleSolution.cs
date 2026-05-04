using System.Collections.Generic;
using Libraries;

namespace LeetCode.Solutions;

public class LinkedListCycleSolution
{
    public bool HasCycle<T>(SinglyLinkedListNode<T> head)
    {
        if (head == null) return false;
            
        var node = head;

        var nodeDictionary = new Dictionary<SinglyLinkedListNode<T>, SinglyLinkedListNode<T>>();

        var result = false;

        while (node.Next != null)
        {
            if (nodeDictionary.ContainsKey(node.Next))
            {
                result = true;
                break;
            }
                
            nodeDictionary.Add(node, node);
            node = node.Next;
        }

        return result;
    }
}