using ACCollections.LinkedList;

namespace ACCollections.DoublyLinkedList;

/// <summary>
///     Интерфейс двусвязного списка.
/// </summary>
/// <typeparam name="TData">Тип элементов двусвязного списка.</typeparam>
public interface IDoublyLinkedList<TData> : ILinkedList<TData>
{
    /// <summary>
    ///     Перевернуть двусвязный список.
    /// </summary>
    void Reverse();

    /// <summary>
    ///     Удалить последний элемент двусвязного списка.
    /// </summary>
    /// <returns>True, если элемент был удален, false иначе.</returns>
    bool RemoveLast();
}