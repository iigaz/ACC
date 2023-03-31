using System.Collections;

namespace ACCollections.DoublyLinkedList;

public class DoublyLinkedList<TData> : IDoublyLinkedList<TData>
{
    private DoublyLinkedListNode<TData>? _first;
    private DoublyLinkedListNode<TData>? _last;

    public DoublyLinkedList(IEnumerable<TData> enumerable)
    {
        foreach (var element in enumerable) AddLast(element);
    }

    public DoublyLinkedList()
    {
        _first = null;
        _last = null;
    }

    public void Reverse()
    {
        throw new NotImplementedException();
    }

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
    public TData First { get; }
    public TData Last { get; }

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