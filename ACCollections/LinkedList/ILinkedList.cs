namespace ACCollections.LinkedList;

/// <summary>
///     Интерфейс связного списка.
/// </summary>
/// <typeparam name="TData">Тип элементов связного списка.</typeparam>
public interface ILinkedList<TData> : IEnumerable<TData>
{
    /// <summary>
    ///     Количество элементов в связном списке.
    /// </summary>
    int Count { get; }

    /// <summary>
    ///     Проверка связного списка на пустоту.
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    ///     Первый элемент связного списка.
    /// </summary>
    TData First { get; }

    /// <summary>
    ///     Последний элемент связного списка.
    /// </summary>
    TData Last { get; }

    /// <summary>
    ///     Получение элементов связного списка по индексу.
    /// </summary>
    /// <param name="index"></param>
    TData this[int index] { get; set; }

    /// <summary>
    ///     Добавить элемент в начало списка.
    /// </summary>
    /// <param name="data">Элемент.</param>
    void AddFirst(TData data);

    /// <summary>
    ///     Добавить элемент в конец списка.
    /// </summary>
    /// <param name="data">Элемент.</param>
    void AddLast(TData data);

    /// <summary>
    ///     Удалить элемент из списка.
    /// </summary>
    /// <param name="data">Элемент.</param>
    /// <returns>True, если элемент был удален, false иначе.</returns>
    bool Remove(TData data);

    /// <summary>
    ///     Удалить элемент по индексу.
    /// </summary>
    /// <param name="index">Индекс элемента.</param>
    /// <returns>True, если элемент был удален, false иначе.</returns>
    bool RemoveAt(int index);

    /// <summary>
    ///     Удалить первый элемент списка.
    /// </summary>
    /// <returns>True, если элемент был удален, false иначе.</returns>
    bool RemoveFirst();

    /// <summary>
    ///     Очистить список.
    /// </summary>
    void Clear();

    /// <summary>
    ///     Проверка на наличие элемента в списке.
    /// </summary>
    /// <param name="data">Элемент.</param>
    bool Contains(TData data);

    /// <summary>
    ///     Получить индекс элемента в списке.
    /// </summary>
    /// <param name="data">Элемент.</param>
    /// <returns>Индекс элемента.</returns>
    int IndexOf(TData data);

    /// <summary>
    ///     Вставить элемент в список по указанному индексу.
    /// </summary>
    /// <param name="index">Индекс нового элемента.</param>
    /// <param name="data">Элемент.</param>
    void Insert(int index, TData data);
}