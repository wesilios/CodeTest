using CodeTest.Library;

namespace LeetCode.Solutions
{
    public class RemoveDuplicatedFromSortedListSolution
    {
        public SinglyLinkedListNode<int> DeleteDuplicates(SinglyLinkedListNode<int> head)
        {
            var node = head;
            while (node != null)
            {
                if (node.Next == null) break;
                if (node.Data.Equals(node.Next.Data))
                {
                    node.Next = node.Next.Next;
                    continue;
                }

                node = node.Next;
            }
            return head;
        }
    }
}