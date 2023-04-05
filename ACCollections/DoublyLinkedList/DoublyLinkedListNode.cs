namespace ACCollections.DoublyLinkedList;

/// <summary>
///     Узел двусвязного списка.
/// </summary>
/// <typeparam name="TData">Тип узла двусвязного списка.</typeparam>
public class DoublyLinkedListNode<TData>
{
    /// <summary>
    ///     Этот класс не предназначен для создания объектов вручную. Пожалуйста, используйте методы получения узлов из
    ///     двусвязного списка.
    /// </summary>
    public DoublyLinkedListNode(TData data)
    {
        Data = data;
    }

    /// <summary>
    ///     Элемент узла.
    /// </summary>
    public TData Data { get; set; }

    /// <summary>
    ///     Следующий элемент.
    /// </summary>
    public DoublyLinkedListNode<TData>? Next { get; set; }

    /// <summary>
    ///     Предыдущий элемент.
    /// </summary>
    public DoublyLinkedListNode<TData>? Previous { get; set; }

    /// <summary>
    ///     Преобразование в строку для красивого отображения :3
    /// </summary>
    public override string ToString()
    {
        return $"[{Data}↔{Next}]";
    }
}