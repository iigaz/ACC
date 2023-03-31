using System.Collections;

namespace ACCollections.Stack;

public class Stack<TData> : IStack<TData>
{
    public IEnumerator<TData> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count { get; }
    public bool IsEmpty { get; }
    public void Push(TData item)
    {
        throw new NotImplementedException();
    }

    public TData Pop()
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