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
        var linkedList = new LinkedList<int>(test);
        Assert.Equal(test[index], linkedList[index]);
        linkedList[index] = 1337;
        Assert.Equal(1337, linkedList[index]);
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
        res = test.RemoveAt(0);
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
        Assert.Equal(expected, new LinkedList<int>(test).IndexOf(element));
    }

    [Theory]
    [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void Test_AddTwoNumbers(int[] num1Array, int[] num2Array, int[] expected)
    {
        // Taken from https://leetcode.com/problems/add-two-numbers/
        var num1 = new LinkedList<int>(num1Array);
        var num2 = new LinkedList<int>(num2Array);

        var result = new LinkedList<int>();

        var carry = 0;

        for (var i = 0; (i < num1.Count && i < num2.Count) || carry > 0; i++)
        {
            var element1 = num1.IsEmpty ? 0 : num1.First;
            var element2 = num2.IsEmpty ? 0 : num2.First;
            var newDigit = element1 + element2 + carry;
            carry = newDigit / 10;
            newDigit %= 10;
            result.AddLast(newDigit);
            num1.RemoveFirst();
            num2.RemoveFirst();
        }

        Assert.Equal(expected, result);
    }
}