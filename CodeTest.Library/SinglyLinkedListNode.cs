namespace CodeTest.Library
{
    public class SinglyLinkedListNode<T>
    {
        public T Data { get; set; }
        public SinglyLinkedListNode<T> Next { get; set; }

        public SinglyLinkedListNode(T data)
        {
            Data = data;
        }
    }
}