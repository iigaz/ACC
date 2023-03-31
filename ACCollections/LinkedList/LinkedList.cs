using System.Collections;

namespace ACCollections.LinkedList;

public class LinkedList<TData> : ILinkedList<TData>
{
    private LinkedListNode<TData>? _first;
    private readonly LinkedListNode<TData>? _last;

    public LinkedList(IEnumerable<TData> enumerable)
    {
        foreach (var element in enumerable) AddLast(element);
    }

    public LinkedList()
    {
        _first = null;
        _last = null;
    }

    public IEnumerator<TData> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count { get; private set; }
    public bool IsEmpty { get; private set; }
    public TData First => this[0];

    public TData Last
    {
        get
        {
            if (_last == null)
                throw new IndexOutOfRangeException();
            return _last.Data;
        }
    }

    public TData this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    public void AddFirst(TData data)
    {
        throw new NotImplementedException();
    }

    public void AddLast(TData data)
    {
        throw new NotImplementedException();
    }

    public bool Remove(TData data)
    {
        throw new NotImplementedException();
    }

    public bool RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public bool RemoveFirst()
    {
        throw new NotImplementedException();
    }

    public bool RemoveLast()
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

    public int IndexOf(TData data)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, TData data)
    {
        throw new NotImplementedException();
    }
}