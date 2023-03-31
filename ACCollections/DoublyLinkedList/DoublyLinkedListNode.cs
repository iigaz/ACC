namespace ACCollections.DoublyLinkedList;

public class DoublyLinkedListNode<TData>
{
    public DoublyLinkedListNode(TData data)
    {
        Data = data;
    }

    public TData Data { get; set; }
    public LinkedListNode<TData>? Next { get; set; }
    public LinkedListNode<TData>? Previous { get; set; }
}