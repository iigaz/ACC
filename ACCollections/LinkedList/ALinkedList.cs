using System.Collections;

namespace ACCollections.LinkedList;

/// <summary>
///     Связный список. Ориентирован на работу больше с элементами, чем с узлами.
/// </summary>
/// <typeparam name="TData">Тип элементов связного списка.</typeparam>
public class ALinkedList<TData> : ILinkedList<TData>
{
    /// <summary>
    ///     Связный список.
    /// </summary>
    /// <param name="enumerable">Начальные элементы списка. Инициализация производится за O(n).</param>
    public ALinkedList(IEnumerable<TData> enumerable)
    {
        foreach (var element in enumerable) AddLast(element);
    }

    /// <summary>
    ///     Связный список.
    /// </summary>
    public ALinkedList()
    {
        Clear();
    }

    /// <summary>
    ///     Первый узел в списке. Получение выполняется за O(1).
    /// </summary>
    public LinkedListNode<TData>? FirstNode { get; private set; }

    /// <summary>
    ///     Последний узел в списке. Получение выполняется за O(1).
    /// </summary>
    public LinkedListNode<TData>? LastNode { get; private set; }

    /// <summary>
    ///     Итератор по связному списку. Начало в первом узле.
    /// </summary>
    /// <returns>Итератор по элементам.</returns>
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

    /// <summary>
    ///     Количество элементов в связном списке.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    ///     Проверка связного списка на пустоту.
    /// </summary>
    public bool IsEmpty => Count == 0;

    /// <summary>
    ///     Первый элемент в списке. То же самое, что и this[0], или FirstNode.Data. Получение выполняется за O(1).
    /// </summary>
    public TData First => this[0];

    /// <summary>
    ///     Последний элемент в списке. То же самое, что и this[^1], или LastNode.Data. Получение выполняется за O(1).
    /// </summary>
    public TData Last => this[^1];

    /// <summary>
    ///     Получение элемента по его индексу в списке. Эта операция выполняется за O(1) при index == 0 или index == Count - 1
    ///     (первый и последний элемент соответственно), и за O(n) в остальных случаях. При выходе индекса за границы списка
    ///     выбрасывается соответствующее исключение.
    /// </summary>
    public TData this[int index]
    {
        get => GetNode(index).Data;
        set => GetNode(index).Data = value;
    }

    /// <summary>
    ///     Добавить элемент в начало списка. Эта операция выполняется за O(1).
    /// </summary>
    public void AddFirst(TData data)
    {
        var node = new LinkedListNode<TData>(data);
        if (IsEmpty)
            LastNode = node;
        else
            node.Next = FirstNode;
        FirstNode = node;
        Count++;
    }

    /// <summary>
    ///     Добавить элемент в конец списка. Эта операция выполняется за O(1).
    /// </summary>
    public void AddLast(TData data)
    {
        var node = new LinkedListNode<TData>(data);
        if (IsEmpty)
            FirstNode = node;
        else
            LastNode!.Next = node;
        LastNode = node;
        Count++;
    }

    /// <summary>
    ///     Удалить указанный элемент из списка. Если элемент встречается несколько раз, будет удалено только первое
    ///     совпадение. Эта операция выполняется в среднем за O(n).
    /// </summary>
    /// <returns>True если элемент был удален, false иначе.</returns>
    public bool Remove(TData data)
    {
        if (IsEmpty) return false;
        if (FirstNode!.Data!.Equals(data)) return RemoveFirst();
        var current = FirstNode.Next;
        var last = FirstNode;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                last.Next = current.Next;
                Count--;
                return true;
            }

            last = current;
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    ///     Удалить элемент по указанному индексу из списка. Эта операция выполняется в среднем за O(n).
    /// </summary>
    /// <returns>True если элемент был удален, false иначе.</returns>
    public bool RemoveAt(int index)
    {
        if (index >= Count || index < 0) return false;
        if (index == 0) return RemoveFirst();
        var previous = GetNode(index - 1);
        previous.Next = previous.Next!.Next;
        Count--;
        return true;
    }

    /// <summary>
    ///     Удалить первый элемент списка. Эта операция выполняется за O(1).
    /// </summary>
    /// <returns>True если элемент был удален, false иначе.</returns>
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
            Count--;
        }

        return true;
    }

    /// <summary>
    ///     Очистить список. Эта операция выполняется за O(1).
    /// </summary>
    public void Clear()
    {
        FirstNode = null;
        LastNode = null;
        Count = 0;
    }

    /// <summary>
    ///     Проверка за наличие элемента в списке. Эта операция выполняется в среднем за O(n).
    /// </summary>
    /// <returns>True если элемент содержится в списке.</returns>
    public bool Contains(TData data)
    {
        if (IsEmpty) return false;
        if (FirstNode!.Data!.Equals(data) || LastNode!.Data!.Equals(data)) return true;
        return this.Any(element => element!.Equals(data));
    }

    /// <summary>
    ///     Получить индекс элемента в списке. Если элемент встречается несколько раз, будет возвращено первое совпадение. Эта
    ///     операция выполняется за O(n).
    /// </summary>
    /// <returns>Индекс элемента, если он присутствует в списке, -1 иначе.</returns>
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

    /// <summary>
    ///     Вставить элемент в список по указанному индексу. Если индекс равен числу элементов, эта функция будет эквивалентна
    ///     методу AddLast. Новый элемент вставляется перед старым элементом по этому же индексу, то есть после выполнения
    ///     операции новый элемент можно будет получить по указанному в аргументах индексу. Выполняется в среднем за O(n).
    /// </summary>
    public void Insert(int index, TData data)
    {
        if (index > Count || index < 0) throw new IndexOutOfRangeException();
        if (index == Count) AddLast(data);
        else if (index == 0) AddFirst(data);
        else AddAfterNode(GetNode(index - 1), data);
    }

    /// <summary>
    ///     Получение связного под-списка из текущего. Эта операция выполняется за O(n), где n - число элементов в текущем
    ///     списке.
    /// </summary>
    /// <param name="start">Индекс начала под-списка.</param>
    /// <param name="length">Длина под-списка.</param>
    /// <returns>Связный список элементов в указанном диапазоне.</returns>
    public ALinkedList<TData> Slice(int start, int length)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Вставить множество элементов в список по указанному индексу. Вставка производится таким образом, чтобы после ее
    ///     выполнения первый элемент множества находился по указанному индексу. Если индекс равен числу элементов в списке,
    ///     эта функция будет эквивалентна методу AddRangeToEnd. Операция выполняется за O(n + m), где n - размер текущего
    ///     списка, m - размер множества.
    /// </summary>
    /// <param name="index">Индекс первого элемента множества в результирующем списке.</param>
    /// <param name="enumerable">Множество элементов.</param>
    public void InsertRange(int index, IEnumerable<TData> enumerable)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Вставить список элементов в текущий список по указанному индексу. Вставка производится таким образом, чтобы после
    ///     ее выполнения первый элемент множества находился по указанному индексу. Если индекс равен числу элементов в текущем
    ///     списке, эта функция будет эквивалентна методу AddRangeToEnd. Операция выполняется за O(n), где n - размер текущего
    ///     списка.
    /// </summary>
    /// <param name="index">Индекс первого элемента множества в результирующем списке.</param>
    /// <param name="linkedList">Связный список элементов.</param>
    public void InsertRange(int index, ALinkedList<TData> linkedList)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Удалить диапазон элементов из списка. Эта операция выполняется за O(start + length) = O(n).
    /// </summary>
    /// <param name="start">Начало диапазона, включительно.</param>
    /// <param name="length">Размер диапазона удаления.</param>
    /// <returns>True если элементы были удалены, false иначе.</returns>
    public bool RemoveRange(int start, int length)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Добавить множество элементов в начало списка. Эта операция выполняется за O(n), где n - размер входного множества.
    /// </summary>
    /// <param name="enumerable">Множество элементов.</param>
    public void AddRangeToBeginning(IEnumerable<TData> enumerable)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Добавить список элементов в начало текущего списка. Эта операция выполняется за O(1).
    /// </summary>
    /// <param name="linkedList">Связный список элементов.</param>
    public void AddRangeToBeginning(ALinkedList<TData> linkedList)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Добавить множество элементов в конец списка. Эта операция выполняется за O(n), где n - размер входного множества.
    /// </summary>
    /// <param name="enumerable">Множество элементов.</param>
    public void AddRangeToEnd(IEnumerable<TData> enumerable)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Добавить список элементов в конец текущего списка. Эта операция выполняется за O(1).
    /// </summary>
    /// <param name="linkedList">Связный список элементов.</param>
    public void AddRangeToEnd(ALinkedList<TData> linkedList)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Получить узел по указанному индексу. При неправильном индексе выбрасывается исключение. Эта операция выполняется в
    ///     среднем за O(n).
    /// </summary>
    public LinkedListNode<TData> GetNode(int index)
    {
        if (index >= Count || index < 0) throw new IndexOutOfRangeException();
        if (index == 0) return FirstNode!;
        if (index == Count - 1) return LastNode!;

        var current = FirstNode;
        var i = 0;
        while (current != null)
        {
            if (i == index) return current;
            i++;
            current = current.Next;
        }

        throw new IndexOutOfRangeException();
    }

    /// <summary>
    ///     Вставить новый элемент после указанного узла. Эта операция выполняется за O(1). Для вставки по индексу смотрите
    ///     Insert.
    /// </summary>
    /// <param name="node">Узел, присутствующий в связном списке.</param>
    /// <param name="data">Новый элемент.</param>
    public void AddAfterNode(LinkedListNode<TData> node, TData data)
    {
        var newNode = new LinkedListNode<TData>(data);
        newNode.Next = node.Next;
        node.Next = newNode;
        Count++;
    }

    /// <summary>
    ///     Пересчитать элементы. Использовать в случае, если узлы текущего связного списка изменялись за пределами этого
    ///     класса. Крайне не рекомендуется доводить связный список до состояния, когда он нуждается в пересчете. Операция
    ///     выполняется за O(n).
    /// </summary>
    /// <returns>True, если список был изменен внешне. False, если после пересчета элементов длина списка осталась прежней.</returns>
    public bool Recount()
    {
        throw new NotImplementedException();
    }
}