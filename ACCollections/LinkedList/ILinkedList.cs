namespace ACCollections.LinkedList;

public interface ILinkedList<TData> : IEnumerable<TData>
{
    int Count { get; }
    bool IsEmpty { get; }
    void AddFirst(TData data);
    void AddLast(TData data);
    bool Remove(TData data);
    bool RemoveFirst();
    bool RemoveLast();
    void Clear();
    bool Contains(TData data);
}