using System.Collections;

namespace ACCollections.Stack;

public class Stack<TData> : IStack<TData>
{
    private readonly LinkedList.LinkedList<TData> _linkedList = new();

    /// <summary>
    ///     Возвращает итератор, который проходится по элементам стека в порядке их положения в стеке, т.е. начиная с
    ///     последнего добавленного элемента.
    /// </summary>
    public IEnumerator<TData> GetEnumerator()
    {
        return _linkedList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => _linkedList.Count;
    public bool IsEmpty => Count == 0;

    /// <summary>
    ///     Добавить элемент в стек. Эта операция выполняется за O(1).
    /// </summary>
    public void Push(TData item)
    {
        _linkedList.AddFirst(item);
    }

    /// <summary>
    ///     Удалить элемент из стека. Эта операция выполняется за O(1).
    /// </summary>
    /// <returns>Удаленный элемент.</returns>
    public TData Pop()
    {
        var first = _linkedList.First;
        _linkedList.RemoveFirst();
        return first;
    }

    /// <summary>
    ///     Показать последний добавленный в стек элемент. Эта операция выполняется за O(1).
    /// </summary>
    /// <returns>Последний добавленный в стек элемент.</returns>
    public TData Peek()
    {
        return _linkedList.First;
    }

    /// <summary>
    ///     Очистить стек. Эта операция выполняется за O(1).
    /// </summary>
    public void Clear()
    {
        _linkedList.Clear();
    }

    /// <summary>
    ///     Проверка за наличие элемента в стеке. Эта операция выполняется за O(n).
    /// </summary>
    /// <returns>True если элемент содержится в стеке.</returns>
    public bool Contains(TData data)
    {
        return _linkedList.Contains(data);
    }
}