namespace ACCollections.LinkedList;

public class LinkedListNode<TData>
{
    /// <summary>
    ///     Этот класс не предназначен для создания объектов вручную. Пожалуйста, используйте методы получения узлов из
    ///     связного списка.
    /// </summary>
    public LinkedListNode(TData data)
    {
        Data = data;
    }

    /// <summary>
    ///     Элемент узла.
    /// </summary>
    public TData Data { get; set; }

    /// <summary>
    ///     Следующий узел.
    /// </summary>
    public LinkedListNode<TData>? Next { get; set; }
}