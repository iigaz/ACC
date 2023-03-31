using System.Collections;

namespace ACCollections.DoublyLinkedList;

public class DoublyLinkedList<TData> : IDoublyLinkedList<TData>
{
    public DoublyLinkedList(IEnumerable<TData> enumerable)
    {
        foreach (var element in enumerable) AddLast(element);
    }

    public DoublyLinkedList()
    {
        FirstNode = null;
        LastNode = null;
    }

    public DoublyLinkedListNode<TData>? FirstNode { get; }
    public DoublyLinkedListNode<TData>? LastNode { get; }

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
    public TData First => this[0];
    public TData Last => this[^1];

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

    public DoublyLinkedListNode<TData> GetNode(int index)
    {
        throw new NotImplementedException();
    }

    public void AddAfterNode(DoublyLinkedListNode<TData> node, TData data)
    {
        throw new NotImplementedException();
    }

    public void AddBeforeNode(DoublyLinkedListNode<TData> node, TData data)
    {
        throw new NotImplementedException();
    }

    public bool RemoveNode(DoublyLinkedListNode<TData> node)
    {
        throw new NotImplementedException();
    }
}