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
        var linkedList = new ALinkedList<int>(expected);
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
        var linkedList = new ALinkedList<int>(test);
        Assert.Equal(test[index], linkedList[index]);
        linkedList[index] = 1337;
        Assert.Equal(1337, linkedList[index]);
    }

    [Fact]
    public void Test_WrongIndex()
    {
        Assert.Throws<IndexOutOfRangeException>(() => new ALinkedList<int>(new[] { 1, 2, 3 })[3]);
    }

    [Fact]
    public void Test_AddFirst()
    {
        var test = new ALinkedList<int>(new[] { 1, 2 });
        test.AddFirst(0);
        Assert.Equal(3, test.Count);
        Assert.Equal(0, test.First);
        Assert.Equal(0, test[0]);
    }

    [Fact]
    public void Test_AddLast()
    {
        var test = new ALinkedList<int>(new[] { 1, 2 });
        test.AddLast(3);
        Assert.Equal(3, test.Count);
        Assert.Equal(3, test.Last);
        Assert.Equal(3, test[^1]);
    }

    [Fact]
    public void Test_AddToEmptyList()
    {
        var test = new ALinkedList<int>();
        test.AddFirst(1);
        Assert.Equal(1, test.First);
        Assert.Equal(1, test.Last);
        Assert.Equal(1, test.Count);
    }

    [Fact]
    public void Test_AddRangeToBeginning()
    {
        var linkedList = new ALinkedList<int>();
        linkedList.AddRangeToBeginning(new[] { 1, 2 });
        linkedList.AddRangeToBeginning(Array.Empty<int>());
        linkedList.AddRangeToBeginning(new ALinkedList<int>(new[] { 3, 4, 5 }));
        Assert.Equal(5, linkedList.Count);
        Assert.Equal(new[] { 3, 4, 5, 1, 2 }, linkedList);
    }

    [Fact]
    public void Test_AddRangeToEnd()
    {
        var linkedList = new ALinkedList<int>();
        linkedList.AddRangeToEnd(new[] { 1, 2 });
        linkedList.AddRangeToEnd(Array.Empty<int>());
        linkedList.AddRangeToEnd(new ALinkedList<int>(new[] { 3, 4, 5 }));
        Assert.Equal(5, linkedList.Count);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, linkedList);
    }

    [Fact]
    public void Test_Remove()
    {
        var test = new ALinkedList<int>(new[] { 1, 2, 3 });
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
        var test = new ALinkedList<int>(new[] { 1, 2, 3 });
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
        var test = new ALinkedList<int>(new[] { 1, 2 });
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
    public void Test_RemoveRange()
    {
        var linkedList = new ALinkedList<int>(new[] { 1, 2, 3, 4, 5 });
        var removed = linkedList.RemoveRange(1, 2);
        Assert.True(removed);
        Assert.Equal(3, linkedList.Count);
        Assert.Equal(new[] { 1, 4, 5 }, linkedList);
        removed = linkedList.RemoveRange(0, 1);
        Assert.True(removed);
        Assert.Equal(2, linkedList.Count);
        Assert.Equal(new[] { 4, 5 }, linkedList);
        removed = linkedList.RemoveRange(0, 2);
        Assert.True(removed);
        Assert.Equal(0, linkedList.Count);
        Assert.Equal(Array.Empty<int>(), linkedList);
        linkedList = new ALinkedList<int>(new[] { 1, 2, 3, 4, 5 });
        removed = linkedList.RemoveRange(0, 3);
        Assert.True(removed);
        Assert.Equal(2, linkedList.Count);
        Assert.Equal(new[] { 4, 5 }, linkedList);
        removed = linkedList.RemoveRange(0, 3);
        Assert.False(removed);
        removed = linkedList.RemoveRange(-1, 1);
        Assert.False(removed);
        removed = linkedList.RemoveRange(3, 1);
        Assert.False(removed);
        removed = linkedList.RemoveRange(0, -1);
        Assert.False(removed);
        Assert.Equal(2, linkedList.Count);
        Assert.Equal(new[] { 4, 5 }, linkedList);
    }

    [Fact]
    public void Test_Clear()
    {
        var test = new ALinkedList<int>(new[] { 1, 2, 3 });
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
        Assert.Equal(test.Contains(element), new ALinkedList<int>(test).Contains(element));
    }

    [Fact]
    public void Test_Insert()
    {
        var test = new ALinkedList<int>(new[] { 1, 3, 5 });
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
        Assert.Throws<IndexOutOfRangeException>(() => test.Insert(-1, 8));
    }

    [Fact]
    public void Test_InsertRange()
    {
        var linkedList = new ALinkedList<int>(new[] { 1, 4, 5 });
        linkedList.InsertRange(0, new[] { -1, 0 });
        linkedList.InsertRange(1, new[] { 2, 3 });
        linkedList.InsertRange(linkedList.Count, new[] { 6, 7 });
        linkedList.InsertRange(0, new ALinkedList<int>(new[] { -3, -2 }));
        linkedList.InsertRange(4, new ALinkedList<int>(new[] { 1, 0 }));
        linkedList.InsertRange(linkedList.Count, new ALinkedList<int>(new[] { 8, 9 }));
        Assert.Equal(15, linkedList.Count);
        Assert.Equal(new[] { -3, -2, -1, 0, 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, linkedList);
        Assert.Throws<IndexOutOfRangeException>(() =>
            linkedList.InsertRange(linkedList.Count + 1, new ALinkedList<int>(new[] { 1, 2 })));
        Assert.Throws<IndexOutOfRangeException>(() =>
            linkedList.InsertRange(-1, new ALinkedList<int>(new[] { 1, 2 })));
        Assert.Equal(15, linkedList.Count);
        Assert.Equal(new[] { -3, -2, -1, 0, 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, linkedList);
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
        Assert.Equal(expected, new ALinkedList<int>(test).IndexOf(element));
    }

    [Fact]
    public void Test_Slice()
    {
        var linkedList = new ALinkedList<int>(new[] { 1, 2, 3, 4, 5 });
        Assert.Equal(2, linkedList.Slice(0, 2).Count);
        Assert.Equal(new[] { 1, 2 }, linkedList.Slice(0, 2));
        Assert.Equal(3, linkedList.Slice(1, 3).Count);
        Assert.Equal(new[] { 2, 3, 4 }, linkedList.Slice(1, 3));
        Assert.Equal(1, linkedList.Slice(4, 1).Count);
        Assert.Equal(new[] { 5 }, linkedList.Slice(4, 1));
        Assert.Equal(0, linkedList.Slice(4, 0).Count);
        Assert.Equal(Array.Empty<int>(), linkedList.Slice(4, 0));
        Assert.Equal(5, linkedList.Slice(0, linkedList.Count).Count);
        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, linkedList.Slice(0, linkedList.Count));
        Assert.Equal(new[] { 3, 4 }, linkedList[2..4]);
        Assert.Equal(new[] { 1, 2, 3 }, linkedList[..3]);
        Assert.Equal(new[] { 2, 3, 4 }, linkedList[1..^1]);
        Assert.Equal(new[] { 4, 5 }, linkedList[3..]);
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.Slice(linkedList.Count, 10));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.Slice(3, 10));
        Assert.Throws<IndexOutOfRangeException>(() => linkedList.Slice(1, -1));
    }

    [Fact]
    public void Test_Recount()
    {
        var linkedList = new ALinkedList<int>(new[] { 1, 2, 3, 4, 5 });
        var changed = linkedList.Recount();
        Assert.False(changed);
        Assert.Equal(5, linkedList.Count);

        linkedList.GetNode(2).Next = null;
        changed = linkedList.Recount();
        Assert.True(changed);
        Assert.Equal(3, linkedList.Count);
        Assert.Equal(new[] { 1, 2, 3 }, linkedList);
        Assert.Equal(3, linkedList.Last);

        linkedList.GetNode(1).Next = null;
        changed = linkedList.Recount();
        Assert.True(changed);
        Assert.Equal(2, linkedList.Count);
        Assert.Equal(new[] { 1, 2 }, linkedList);
        Assert.Equal(2, linkedList.Last);

        linkedList.GetNode(0).Next = null;
        changed = linkedList.Recount();
        Assert.True(changed);
        Assert.Equal(1, linkedList.Count);
        Assert.Equal(new[] { 1 }, linkedList);
        Assert.Equal(1, linkedList.Last);

        var newNode = new LinkedListNode<int>(10)
        {
            Next = new LinkedListNode<int>(11)
            {
                Next = new LinkedListNode<int>(100)
            }
        };

        linkedList.LastNode!.Next = newNode;
        changed = linkedList.Recount();
        Assert.True(changed);
        Assert.Equal(4, linkedList.Count);
        Assert.Equal(new[] { 1, 10, 11, 100 }, linkedList);
        Assert.Equal(100, linkedList.Last);

        changed = linkedList.Recount();
        Assert.False(changed);
    }

    [Theory]
    [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void Test_AddTwoNumbers(int[] num1Array, int[] num2Array, int[] expected)
    {
        // Taken from https://leetcode.com/problems/add-two-numbers/
        var num1 = new ALinkedList<int>(num1Array);
        var num2 = new ALinkedList<int>(num2Array);

        var result = new ALinkedList<int>();

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