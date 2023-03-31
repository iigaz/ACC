using System;
using System.Linq;
using ACCollections.LinkedList;
using Xunit;

namespace ACCTests;

public class LinkedListTest
{
    [Fact]
    public void Test_GetEnumerator()
    {
        var expected = new[] { 1, 2, 3, 4, 5 };
        var linkedList = new LinkedList<int>(expected);
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
        Assert.Equal(test[index], new LinkedList<int>(test)[index]);
    }

    [Fact]
    public void Test_WrongIndex()
    {
        Assert.Throws<IndexOutOfRangeException>(() => new LinkedList<int>(new[] { 1, 2, 3 })[3]);
    }

    [Fact]
    public void Test_AddFirst()
    {
        var test = new LinkedList<int>(new[] { 1, 2 });
        test.AddFirst(0);
        Assert.Equal(3, test.Count);
        Assert.Equal(0, test.First);
        Assert.Equal(0, test[0]);
    }

    [Fact]
    public void Test_AddLast()
    {
        var test = new LinkedList<int>(new[] { 1, 2 });
        test.AddLast(3);
        Assert.Equal(3, test.Count);
        Assert.Equal(3, test.Last);
        Assert.Equal(3, test[^1]);
    }

    [Fact]
    public void Test_AddToEmptyList()
    {
        var test = new LinkedList<int>();
        test.AddFirst(1);
        Assert.Equal(1, test.First);
        Assert.Equal(1, test.Last);
        Assert.Equal(1, test.Count);
    }

    [Fact]
    public void Test_Remove()
    {
        var test = new LinkedList<int>(new[] { 1, 2, 3 });
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
    }

    [Fact]
    public void Test_RemoveAt()
    {
        var test = new LinkedList<int>(new[] { 1, 2, 3 });
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
    }

    [Fact]
    public void Test_RemoveFirst()
    {
        var test = new LinkedList<int>(new[] { 1, 2 });
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
        var test = new LinkedList<int>(new[] { 1, 2 });
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
        var test = new LinkedList<int>(new[] { 1, 2, 3 });
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
        Assert.Equal(test.Contains(element), new LinkedList<int>(test).Contains(element));
    }

    [Fact]
    public void Test_Insert()
    {
        var test = new LinkedList<int>(new[] { 1, 3, 5 });
        test.Insert(0, 0);
        Assert.Equal(4, test.Count);
        test.Insert(2, 2);
        Assert.Equal(5, test.Count);
        test.Insert(4, 4);
        Assert.Equal(6, test.Count);
        Assert.Equal(new[] { 0, 1, 2, 3, 4, 5 }, test);
        Assert.Throws<IndexOutOfRangeException>(() => test.Insert(6, 6));
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
        Assert.Equal(expected, new LinkedList<int>(test).IndexOf(element));
    }
}