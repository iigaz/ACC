namespace ACCollections.Queue;

/// <summary>
///     Интерфейс очереди.
/// </summary>
/// <typeparam name="TData">Тип элементов очереди.</typeparam>
public interface IQueue<TData> : IEnumerable<TData>
{
    /// <summary>
    ///     Проверка на пустоту.
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    ///     Количество элементов очереди.
    /// </summary>
    int Count { get; }

    /// <summary>
    ///     Добавить элемент в очередь.
    /// </summary>
    /// <param name="data">Элемент.</param>
    void Enqueue(TData data);

    /// <summary>
    ///     Убрать первый в порядке добавления элемент очереди.
    /// </summary>
    /// <returns>Удаленный элемент.</returns>
    TData Dequeue();

    /// <summary>
    ///     Показать первый в порядке добавления элемент очереди.
    /// </summary>
    TData Peek();

    /// <summary>
    ///     Очистить очередь.
    /// </summary>
    void Clear();

    /// <summary>
    ///     Проверка на наличие элемента в очереди.
    /// </summary>
    /// <param name="data">Элемент.</param>
    bool Contains(TData data);
}