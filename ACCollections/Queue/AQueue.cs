using System.Collections;
using ACCollections.LinkedList;

namespace ACCollections.Queue;

/// <summary>
///     Очередь, основанная на связном списке.
/// </summary>
/// <typeparam name="TData">Тип элементов очереди.</typeparam>
public class AQueue<TData> : IQueue<TData>
{
    private readonly ALinkedList<TData> _linkedList = new();

    /// <summary>
    ///     Возвращает итератор, который проходится по элементам в порядке очереди, т.е. начиная с самого "старого" элемента.
    /// </summary>
    public IEnumerator<TData> GetEnumerator()
    {
        return _linkedList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    ///     Проверка очереди на пустоту.
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    ///     Количество элементов в очереди.
    /// </summary>
    public int Count => _linkedList.Count;

    /// <summary>
    ///     Внести элемент в конец очереди. Эта операция выполняется за O(1).
    /// </summary>
    public void Enqueue(TData data)
    {
        _linkedList.AddLast(data);
    }

    /// <summary>
    ///     Удалить элемент из очереди. Эта операция выполняется за O(1).
    /// </summary>
    /// <returns>Удаленный элемент.</returns>
    public TData Dequeue()
    {
        var first = _linkedList.First;
        _linkedList.RemoveFirst();
        return first;
    }

    /// <summary>
    ///     Показать самый "старый" элемент. Эта операция выполняется за O(1).
    /// </summary>
    /// <returns>Элемент в начале очереди.</returns>
    public TData Peek()
    {
        return _linkedList.First;
    }

    /// <summary>
    ///     Очистить очередь. Эта операция выполняется за O(1).
    /// </summary>
    public void Clear()
    {
        _linkedList.Clear();
    }

    /// <summary>
    ///     Проверка за наличие элемента в очереди. Эта операция выполняется за O(n).
    /// </summary>
    /// <returns>True если элемент содержится в очереди.</returns>
    public bool Contains(TData data)
    {
        return _linkedList.Contains(data);
    }
}