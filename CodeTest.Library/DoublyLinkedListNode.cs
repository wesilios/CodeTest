namespace CodeTest.Library
{
    public class DoublyLinkedListNode<T>
    {
        public T Data { get; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public DoublyLinkedListNode<T> Previous { get; set; }

        public DoublyLinkedListNode(T data)
        {
            Data = data;
        }
    }
}