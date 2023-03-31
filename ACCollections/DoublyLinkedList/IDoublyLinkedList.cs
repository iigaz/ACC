using ACCollections.LinkedList;

namespace ACCollections.DoublyLinkedList;

public interface IDoublyLinkedList<TData> : ILinkedList<TData>
{
    void Reverse();
    bool RemoveLast();
}