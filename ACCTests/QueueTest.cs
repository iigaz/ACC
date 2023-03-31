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
        queue.Enqueue(2);
        queue.Enqueue(3);
        Assert.Equal(new[] { 1, 2, 3 }, queue);
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

    [Fact]
    public void Test_PaperTask()
    {
        var matrix = new[,] { { 0, 0, 1, 0, 1 }, { 1, 0, 1, 0, 0 }, { 0, 1, 0, 1, 1 }, { 1, 0, 0, 1, 0 } };

        var n = matrix.GetLength(0);
        var m = matrix.GetLength(1);
        var numberOfRegions = 0;

        for (var i = 0; i < n; i++)
        for (var j = 0; j < m; j++)
        {
            if (matrix[i, j] != 0) continue;
            var queue = new Queue<(int X, int Y)>();
            queue.Enqueue((i, j));
            while (!queue.IsEmpty)
            {
                var currentPoint = queue.Dequeue();
                if (matrix[currentPoint.X, currentPoint.Y] != 0) continue;
                matrix[currentPoint.X, currentPoint.Y] = 2;
                foreach (var delta in new[] { (-1, 0), (0, 1), (1, 0), (0, -1) })
                {
                    var newPoint = (X: currentPoint.X + delta.Item1, Y: currentPoint.Y + delta.Item2);
                    if (newPoint.X >= 0 && newPoint.X < n && newPoint.Y >= 0 && newPoint.Y < m &&
                        matrix[newPoint.X, newPoint.Y] == 0)
                        queue.Enqueue(newPoint);
                }
            }

            numberOfRegions++;
        }

        Assert.Equal(5, numberOfRegions);
    }
}