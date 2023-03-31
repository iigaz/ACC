using System.Collections;

namespace ACCollections.LinkedList;

public class LinkedList<TData> : ILinkedList<TData>
{
    public LinkedList(IEnumerable<TData> enumerable)
    {
        foreach (var element in enumerable) AddLast(element);
    }

    public LinkedList()
    {
        Clear();
    }

    public LinkedListNode<TData>? FirstNode { get; private set; }
    public LinkedListNode<TData>? LastNode { get; private set; }

    public IEnumerator<TData> GetEnumerator()
    {
        var current = FirstNode;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count { get; private set; }
    public bool IsEmpty => Count == 0;
    public TData First => this[0];

    public TData Last => this[^1];

    public TData this[int index]
    {
        get => GetNode(index).Data;
        set => GetNode(index).Data = value;
    }

    public void AddFirst(TData data)
    {
        var node = new LinkedListNode<TData>(data);
        if (IsEmpty)
            LastNode = node;
        else
            node.Next = FirstNode;
        FirstNode = node;
        Count++;
    }

    public void AddLast(TData data)
    {
        var node = new LinkedListNode<TData>(data);
        if (IsEmpty)
            FirstNode = node;
        else
            LastNode!.Next = node;
        LastNode = node;
        Count++;
    }

    public bool Remove(TData data)
    {
        if (IsEmpty) return false;
        if (FirstNode!.Data!.Equals(data)) return RemoveFirst();
        var current = FirstNode.Next;
        var last = FirstNode;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                last.Next = current.Next;
                Count--;
                return true;
            }

            last = current;
            current = current.Next;
        }

        return false;
    }

    public bool RemoveAt(int index)
    {
        if (index >= Count) return false;
        if (index == 0) return RemoveFirst();
        var previous = GetNode(index - 1);
        previous.Next = previous.Next!.Next;
        Count--;
        return true;
    }

    public bool RemoveFirst()
    {
        if (IsEmpty)
            return false;
        if (Count == 1)
        {
            Clear();
        }
        else
        {
            FirstNode = FirstNode!.Next;
            Count--;
        }

        return true;
    }

    public void Clear()
    {
        FirstNode = null;
        LastNode = null;
        Count = 0;
    }

    public bool Contains(TData data)
    {
        if (IsEmpty) return false;
        if (FirstNode!.Data!.Equals(data) || LastNode!.Data!.Equals(data)) return true;
        return this.Any(element => element!.Equals(data));
    }

    public int IndexOf(TData data)
    {
        var i = 0;
        foreach (var element in this)
        {
            if (element!.Equals(data))
                return i;
            i++;
        }

        return -1;
    }

    public void Insert(int index, TData data)
    {
        if (index > Count || index < 0) throw new IndexOutOfRangeException();
        if (index == Count) AddLast(data);
        else if (index == 0) AddFirst(data);
        else AddAfterNode(GetNode(index - 1), data);
    }

    public LinkedListNode<TData> GetNode(int index)
    {
        if (index >= Count || index < 0) throw new IndexOutOfRangeException();
        if (index == 0) return FirstNode!;
        if (index == Count - 1) return LastNode!;

        var current = FirstNode;
        var i = 0;
        while (current != null)
        {
            if (i == index) return current;
            i++;
            current = current.Next;
        }

        throw new IndexOutOfRangeException();
    }

    public void AddAfterNode(LinkedListNode<TData> node, TData data)
    {
        var newNode = new LinkedListNode<TData>(data);
        newNode.Next = node.Next;
        node.Next = newNode;
        Count++;
    }
}