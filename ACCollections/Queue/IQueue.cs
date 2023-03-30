namespace ACCollections.Queue;

public interface IQueue<TData> : IEnumerable<TData>
{
    bool IsEmpty { get; }
    int Count { get; }
    void Enqueue(TData data);
    TData Dequeue();
    TData Peek();
    void Clear();
    bool Contains(TData data);
}