using System;
using System.Linq;
using ACCollections.DoublyLinkedList;
using Xunit;

namespace ACCTests;

public class DoublyLinkedListTest
{
    [Fact]
    public void Test_GetEnumerator()
    {
        var expected = new[] { 1, 2, 3, 4, 5 };
        var linkedList = new ADoublyLinkedList<int>(expected);
        var actual = new int[expected.Length];
        var i = 0;
        foreach (var element in linkedList)
        {
            actual[i] = element;
            i++;
        }

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, 0)]
    [InlineData(new[] { 1, 2, 3, 4 }, 3)]
    [InlineData(new[] { 1, 2, 3, 4 }, 2)]
    [InlineData(new[] { 1 }, 0)]
    public void Test_Index(int[] test, int index)
    {
        var linkedList = new ADoublyLinkedList<int>(test);
        Assert.Equal(test[index], linkedList[index]);
        linkedList[index] = 1337;
        Assert.Equal(1337, linkedList[index]);
    }

    [Fact]
    public void Test_WrongIndex()
    {
        Assert.Throws<IndexOutOfRangeException>(() => new ADoublyLinkedList<int>(new[] { 1, 2, 3 })[3]);
    }

    [Fact]
    public void Test_AddFirst()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 2 });
        test.AddFirst(0);
        Assert.Equal(3, test.Count);
        Assert.Equal(0, test.First);
        Assert.Equal(0, test[0]);
    }

    [Fact]
    public void Test_AddLast()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 2 });
        test.AddLast(3);
        Assert.Equal(3, test.Count);
        Assert.Equal(3, test.Last);
        Assert.Equal(3, test[^1]);
    }

    [Fact]
    public void Test_AddToEmptyList()
    {
        var test = new ADoublyLinkedList<int>();
        test.AddFirst(1);
        Assert.Equal(1, test.First);
        Assert.Equal(1, test.Last);
        Assert.Equal(1, test.Count);
    }

    [Fact]
    public void Test_Remove()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 2, 3 });
        var res = test.Remove(2);
        Assert.True(res);
        Assert.Equal(2, test.Count);
        Assert.Equal(1, test.First);
        Assert.Equal(3, test.Last);
        res = test.Remove(2);
        Assert.False(res);
        Assert.Equal(2, test.Count);
        Assert.Equal(1, test.First);
        Assert.Equal(3, test.Last);
        res = test.Remove(1);
        Assert.True(res);
        res = test.Remove(3);
        Assert.True(res);
        res = test.Remove(0);
        Assert.False(res);
        Assert.Equal(0, test.Count);
        Assert.True(test.IsEmpty);
        Assert.Throws<IndexOutOfRangeException>(() => test.First);
        Assert.Throws<IndexOutOfRangeException>(() => test.Last);
    }

    [Fact]
    public void Test_RemoveAt()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 2, 3 });
        var res = test.RemoveAt(1);
        Assert.True(res);
        Assert.Equal(2, test.Count);
        Assert.Equal(1, test.First);
        Assert.Equal(3, test.Last);
        res = test.RemoveAt(3);
        Assert.False(res);
        Assert.Equal(2, test.Count);
        Assert.Equal(1, test.First);
        Assert.Equal(3, test.Last);
        res = test.RemoveAt(1);
        Assert.True(res);
        res = test.RemoveAt(0);
        Assert.True(res);
        res = test.RemoveAt(0);
        Assert.False(res);
        Assert.Equal(0, test.Count);
        Assert.True(test.IsEmpty);
        Assert.Throws<IndexOutOfRangeException>(() => test.First);
        Assert.Throws<IndexOutOfRangeException>(() => test.Last);
    }

    [Fact]
    public void Test_RemoveFirst()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 2 });
        var res = test.RemoveFirst();
        Assert.True(res);
        Assert.Equal(1, test.Count);
        Assert.Equal(2, test.First);
        Assert.Equal(2, test.Last);
        res = test.RemoveFirst();
        Assert.True(res);
        Assert.Equal(0, test.Count);
        res = test.RemoveFirst();
        Assert.False(res);
    }

    [Fact]
    public void Test_RemoveLast()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 2 });
        var res = test.RemoveLast();
        Assert.True(res);
        Assert.Equal(1, test.Count);
        Assert.Equal(1, test.First);
        Assert.Equal(1, test.Last);
        res = test.RemoveLast();
        Assert.True(res);
        Assert.Equal(0, test.Count);
        res = test.RemoveLast();
        Assert.False(res);
    }

    [Fact]
    public void Test_Clear()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 2, 3 });
        test.Clear();
        Assert.Equal(0, test.Count);
    }


    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 1)]
    [InlineData(new[] { 1, 2, 3 }, 2)]
    [InlineData(new[] { 1, 2, 3 }, 3)]
    [InlineData(new[] { 1, 2, 3 }, 4)]
    [InlineData(new[] { 1 }, 1)]
    [InlineData(new int[0], 1)]
    public void Test_Contains(int[] test, int element)
    {
        Assert.Equal(test.Contains(element), new ADoublyLinkedList<int>(test).Contains(element));
    }

    [Fact]
    public void Test_Insert()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 3, 5 });
        test.Insert(0, 0);
        Assert.Equal(4, test.Count);
        test.Insert(2, 2);
        Assert.Equal(5, test.Count);
        test.Insert(4, 4);
        Assert.Equal(6, test.Count);
        test.Insert(6, 6);
        Assert.Equal(7, test.Count);
        Assert.Equal(new[] { 0, 1, 2, 3, 4, 5, 6 }, test);
        Assert.Throws<IndexOutOfRangeException>(() => test.Insert(8, 8));
    }


    [Theory]
    [InlineData(new[] { 1, 2, 3 }, 1, 0)]
    [InlineData(new[] { 1, 2, 3 }, 2, 1)]
    [InlineData(new[] { 1, 2, 3 }, 3, 2)]
    [InlineData(new[] { 1, 2, 3 }, 4, -1)]
    [InlineData(new[] { 1 }, 1, 0)]
    [InlineData(new int[0], 1, -1)]
    public void Test_IndexOf(int[] test, int element, int expected)
    {
        Assert.Equal(expected, new ADoublyLinkedList<int>(test).IndexOf(element));
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 })]
    [InlineData(new[] { 1 })]
    [InlineData(new int[0])]
    public void Test_Reverse(int[] expected)
    {
        var linkedList = new ADoublyLinkedList<int>(expected);
        Assert.Equal(expected, linkedList);
        linkedList.Reverse();
        Assert.Equal(expected.Reverse(), linkedList);
        linkedList.Reverse();
        Assert.Equal(expected, linkedList);
    }

    [Fact]
    public void Test_RemoveNode()
    {
        var linkedList = new ADoublyLinkedList<int>(new[] { 1, 2, 3, 4 });
        var res = linkedList.RemoveNode(linkedList.FirstNode!);
        Assert.True(res);
        Assert.Equal(new[] { 2, 3, 4 }, linkedList);
        res = linkedList.RemoveNode(linkedList.FirstNode!.Next!);
        Assert.True(res);
        Assert.Equal(new[] { 2, 4 }, linkedList);
        res = linkedList.RemoveNode(linkedList.LastNode!);
        Assert.True(res);
        Assert.Equal(new[] { 2 }, linkedList);
    }

    [Fact]
    public void Test_GetNode()
    {
        var linkedList = new ADoublyLinkedList<int>(new[] { 1, 2, 3, 4 });
        Assert.Equal(linkedList.FirstNode, linkedList.GetNode(0));
        Assert.Equal(linkedList.First, linkedList.GetNode(0).Data);
        Assert.Equal(linkedList.FirstNode!.Next, linkedList.GetNode(1));
        Assert.Equal(linkedList.LastNode!.Previous, linkedList.GetNode(2));
        Assert.Equal(linkedList.LastNode, linkedList.GetNode(3));
        Assert.Equal(linkedList.Last, linkedList.GetNode(3).Data);
    }

    [Fact]
    public void Test_AddAfterNode()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 3, 5 });
        var firstNode = test.FirstNode!;
        var middleNode = test.FirstNode!.Next!;
        var lastNode = test.LastNode!;
        test.AddAfterNode(firstNode, 2);
        Assert.Equal(4, test.Count);
        test.AddAfterNode(middleNode, 4);
        Assert.Equal(5, test.Count);
        test.AddAfterNode(lastNode, 6);
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, test);
        test.AddAfterNode(firstNode, 1);
        Assert.Equal(new[] { 1, 1, 2, 3, 4, 5, 6 }, test);
    }

    [Fact]
    public void Test_AddBeforeNode()
    {
        var test = new ADoublyLinkedList<int>(new[] { 1, 3, 5 });
        var firstNode = test.FirstNode!;
        var middleNode = test.FirstNode!.Next!;
        var lastNode = test.LastNode!;
        test.AddBeforeNode(firstNode, 0);
        Assert.Equal(4, test.Count);
        test.AddBeforeNode(middleNode, 2);
        Assert.Equal(5, test.Count);
        test.AddBeforeNode(lastNode, 4);
        Assert.Equal(new[] { 0, 1, 2, 3, 4, 5 }, test);
        test.AddBeforeNode(firstNode, 1);
        Assert.Equal(new[] { 0, 1, 1, 2, 3, 4, 5 }, test);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3 }, "[1↔[2↔[3↔]]]")]
    [InlineData(new[] { 5, 4, 3, 2, 1 }, "[5↔[4↔[3↔[2↔[1↔]]]]]")]
    [InlineData(new[] { 1 }, "[1↔]")]
    [InlineData(new int[0], "")]
    public void Test_ToString(int[] test, string expectedNodeString)
    {
        Assert.Equal(string.Join("↔", test), new ADoublyLinkedList<int>(test).ToString());
        if (test.Length != 0)
            Assert.Equal(expectedNodeString, new ADoublyLinkedList<int>(test).FirstNode!.ToString());
    }
}