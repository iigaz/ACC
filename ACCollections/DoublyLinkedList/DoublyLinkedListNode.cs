namespace ACCollections.DoublyLinkedList;

public class DoublyLinkedListNode<TData>
{
    public DoublyLinkedListNode(TData data)
    {
        Data = data;
    }

    public TData Data { get; set; }
    public DoublyLinkedListNode<TData>? Next { get; set; }
    public DoublyLinkedListNode<TData>? Previous { get; set; }
}