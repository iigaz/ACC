namespace ACCollections.Stack;

/// <summary>
///     Интерфейс стека.
/// </summary>
/// <typeparam name="TData">Тип элемента в стеке.</typeparam>
public interface IStack<TData> : IEnumerable<TData>
{
    /// <summary>
    ///     Количество элементов в стеке.
    /// </summary>
    int Count { get; }

    /// <summary>
    ///     Проверка стека на пустоту.
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    ///     Добавить элемент в стек.
    /// </summary>
    /// <param name="item">Элемент.</param>
    void Push(TData item);

    /// <summary>
    ///     Удалить последний добавленный элемент из стека.
    /// </summary>
    /// <returns>Удаленный элемент.</returns>
    TData Pop();

    /// <summary>
    ///     Посмотреть последний добавленный элемент.
    /// </summary>
    TData Peek();

    /// <summary>
    ///     Очистить стек.
    /// </summary>
    void Clear();

    /// <summary>
    ///     Проверка на наличие элемента в стеке.
    /// </summary>
    /// <param name="data">Элемент.</param>
    bool Contains(TData data);
}