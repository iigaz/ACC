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
        Clear();
    }

    public DoublyLinkedListNode<TData>? FirstNode { get; private set; }
    public DoublyLinkedListNode<TData>? LastNode { get; private set; }

    public void Reverse()
    {
        if (Count <= 1) return;
        var current = FirstNode;
        LastNode = FirstNode;
        while (current != null)
        {
            (current.Next, current.Previous) = (current.Previous, current.Next);
            FirstNode = current;
            current = current.Previous;
        }
    }

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
        var node = new DoublyLinkedListNode<TData>(data);
        if (IsEmpty)
        {
            LastNode = node;
        }
        else
        {
            node.Next = FirstNode;
            FirstNode!.Previous = node;
        }

        FirstNode = node;
        Count++;
    }

    public void AddLast(TData data)
    {
        var node = new DoublyLinkedListNode<TData>(data);
        if (IsEmpty)
        {
            FirstNode = node;
        }
        else
        {
            LastNode!.Next = node;
            node.Previous = LastNode;
        }

        LastNode = node;
        Count++;
    }

    public bool Remove(TData data)
    {
        if (IsEmpty) return false;
        if (FirstNode!.Data!.Equals(data)) return RemoveFirst();
        var current = FirstNode.Next;
        while (current != null)
        {
            if (current.Data!.Equals(data)) return RemoveNode(current);
            current = current.Next;
        }

        return false;
    }

    public bool RemoveAt(int index)
    {
        if (index >= Count || index < 0) return false;
        if (index == 0) return RemoveFirst();
        if (index == Count - 1) return RemoveLast();
        return RemoveNode(GetNode(index));
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
            FirstNode!.Previous = null;
            Count--;
        }

        return true;
    }

    public bool RemoveLast()
    {
        if (IsEmpty)
            return false;
        if (Count == 1)
        {
            Clear();
        }
        else
        {
            LastNode = LastNode!.Previous;
            LastNode!.Next = null;
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
        else AddBeforeNode(GetNode(index), data);
    }

    public DoublyLinkedListNode<TData> GetNode(int index)
    {
        if (index >= Count || index < 0) throw new IndexOutOfRangeException();
        if (index == 0) return FirstNode!;
        if (index == Count - 1) return LastNode!;

        if (index < Count / 2)
        {
            var current = FirstNode;
            var i = 0;
            while (current != null)
            {
                if (i == index) return current;
                i++;
                current = current.Next;
            }
        }
        else
        {
            var current = LastNode;
            var i = Count - 1;
            while (current != null)
            {
                if (i == index) return current;
                i--;
                current = current.Previous;
            }
        }

        throw new IndexOutOfRangeException();
    }

    public void AddAfterNode(DoublyLinkedListNode<TData> node, TData data)
    {
        var customNode = new DoublyLinkedListNode<TData>(data)
        {
            Previous = node,
            Next = node.Next
        };
        node.Next!.Previous = customNode;
        node.Next = customNode;
        Count++;
    }

    public void AddBeforeNode(DoublyLinkedListNode<TData> node, TData data)
    {
        var customNode = new DoublyLinkedListNode<TData>(data)
        {
            Previous = node.Previous,
            Next = node
        };
        node.Previous!.Next = customNode;
        node.Previous = customNode;
        Count++;
    }

    public bool RemoveNode(DoublyLinkedListNode<TData> node)
    {
        if (node == FirstNode) return RemoveFirst();
        if (node == LastNode) return RemoveLast();
        node.Previous!.Next = node.Next;
        Count--;
        return true;
    }
}