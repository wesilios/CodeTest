namespace LeetCode.Solutions
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class RotateLinkedListSolution
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null) return null;
            if (k <= 0 || head.Next is null) return head;
            var length = 0;
            var tail = head;
            while (tail.Next != null)
            {
                length++;
                tail = tail.Next;
            }

            k %= length + 1;
            while (k > 0)
            {
                var oldHead = head;
                var prev = head;
                while (head.Next is not null)
                {
                    prev = head;
                    head = head.Next;
                }

                prev.Next = null;
                head.Next = oldHead;
                k--; 
            }

            return head;
        }
    }

    public class ListNode
    {
        public readonly int Val;
        public ListNode Next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.Val = val;
            this.Next = next;
        }
    }
}