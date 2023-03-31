using System.Collections;

namespace ACCollections.Queue;

public class Queue<TData> : IQueue<TData>
{
    private readonly LinkedList.LinkedList<TData> _linkedList = new();

    public IEnumerator<TData> GetEnumerator()
    {
        return _linkedList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public bool IsEmpty => Count == 0;
    public int Count => _linkedList.Count;

    public void Enqueue(TData data)
    {
        _linkedList.AddLast(data);
    }

    public TData Dequeue()
    {
        var first = _linkedList.First;
        _linkedList.RemoveFirst();
        return first;
    }

    public TData Peek()
    {
        return _linkedList.First;
    }

    public void Clear()
    {
        _linkedList.Clear();
    }

    public bool Contains(TData data)
    {
        return _linkedList.Contains(data);
    }
}