using System.Collections;

namespace ACCollections.Queue;

public class Queue<TData> : IQueue<TData>
{
    public IEnumerator<TData> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool IsEmpty { get; }
    public int Count { get; }
    public void Enqueue(TData data)
    {
        throw new NotImplementedException();
    }

    public TData Dequeue()
    {
        throw new NotImplementedException();
    }

    public TData Peek()
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(TData data)
    {
        throw new NotImplementedException();
    }
}