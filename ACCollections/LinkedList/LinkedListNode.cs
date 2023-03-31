namespace ACCollections.LinkedList;

public class LinkedListNode<TData>
{
    public LinkedListNode(TData data)
    {
        Data = data;
    }

    public TData Data { get; set; }
    public LinkedListNode<TData>? Next { get; set; }
}