using System;
using System.Linq;
using ACCollections.Queue;
using Xunit;

namespace ACCTests;

public class QueueTest
{
    [Fact]
    public void Test_GetEnumerator()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        var actual = new int[queue.Count];
        var i = 0;
        foreach (var element in queue)
        {
            actual[i] = element;
            i++;
        }

        Assert.Equal(new[] { 1, 2, 3, 4, 5 }, actual);
    }

    [Fact]
    public void Test_Enqueue()
    {
        var queue = new Queue<int>();
        Assert.True(queue.IsEmpty);
        Assert.Equal(0, queue.Count);
        queue.Enqueue(1);
        Assert.False(queue.IsEmpty);
        Assert.Equal(1, queue.Count);
        Assert.Equal(1, queue.Peek());
    }

    [Fact]
    public void Test_Dequeue()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Peek());
        Assert.Equal(1, queue.Count);
        Assert.Equal(2, queue.Dequeue());
        Assert.True(queue.IsEmpty);
        Assert.Throws<IndexOutOfRangeException>(() => queue.Dequeue());
    }


    [Fact]
    public void Test_Clear()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Clear();
        Assert.Equal(0, queue.Count);
        Assert.True(queue.IsEmpty);
        queue.Clear();
        Assert.Equal(0, queue.Count);
        Assert.True(queue.IsEmpty);
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
        var queue = new Queue<int>();
        foreach (var e in test) queue.Enqueue(e);
        Assert.Equal(test.Contains(element), queue.Contains(element));
    }
}