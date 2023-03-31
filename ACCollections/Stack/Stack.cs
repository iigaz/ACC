using System.Collections;

namespace ACCollections.Stack;

public class Stack<TData> : IStack<TData>
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

    public int Count => _linkedList.Count;
    public bool IsEmpty => Count == 0;

    public void Push(TData item)
    {
        _linkedList.AddFirst(item);
    }

    public TData Pop()
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