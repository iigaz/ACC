namespace ACCollections.LinkedList;

public interface ILinkedList<TData> : IEnumerable<TData>
{
    int Count { get; }
    bool IsEmpty { get; }
    TData First { get; }
    TData Last { get; }
    TData this[int index] { get; set; }
    void AddFirst(TData data);
    void AddLast(TData data);
    bool Remove(TData data);
    bool RemoveAt(int index);
    bool RemoveFirst();
    bool RemoveLast();
    void Clear();
    bool Contains(TData data);
    int IndexOf(TData data);
    void Insert(int index, TData data);
}