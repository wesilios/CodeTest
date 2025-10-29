namespace CodeTest.Library;

public class SinglyLinkedList<T>
{
    private int Size { get; set; }
    private SinglyLinkedListNode<T> Head { get; set; }
    private SinglyLinkedListNode<T> Tail { get; set; }
}