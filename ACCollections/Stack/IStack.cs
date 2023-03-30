namespace ACCollections.Stack;

public interface IStack<TData> : IEnumerable<TData>
{
    int Count { get; }
    bool IsEmpty { get; }
    void Push(TData item);
    TData Pop();
    TData Peek();
    void Clear();
    bool Contains(TData data);
}