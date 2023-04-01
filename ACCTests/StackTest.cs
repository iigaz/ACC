using System;
using System.Linq;
using ACCollections.Stack;
using Xunit;

namespace ACCTests;

public class StackTest
{
    [Fact]
    public void Test_GetEnumerator()
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        var actual = new int[stack.Count];
        var i = 0;
        foreach (var element in stack)
        {
            actual[i] = element;
            i++;
        }

        Assert.Equal(new[] { 5, 4, 3, 2, 1 }, actual);
    }

    [Fact]
    public void Test_Push()
    {
        var stack = new Stack<int>();
        Assert.True(stack.IsEmpty);
        Assert.Equal(0, stack.Count);
        stack.Push(1);
        Assert.False(stack.IsEmpty);
        Assert.Equal(1, stack.Count);
        Assert.Equal(1, stack.Peek());
        stack.Push(2);
        stack.Push(3);
        Assert.Equal(new[] { 3, 2, 1 }, stack);
    }

    [Fact]
    public void Test_Pop()
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Peek());
        Assert.Equal(1, stack.Count);
        Assert.Equal(1, stack.Pop());
        Assert.True(stack.IsEmpty);
        Assert.Throws<IndexOutOfRangeException>(() => stack.Pop());
    }


    [Fact]
    public void Test_Clear()
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Clear();
        Assert.Equal(0, stack.Count);
        Assert.True(stack.IsEmpty);
        stack.Clear();
        Assert.Equal(0, stack.Count);
        Assert.True(stack.IsEmpty);
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
        var stack = new Stack<int>();
        foreach (var e in test) stack.Push(e);
        Assert.Equal(test.Contains(element), stack.Contains(element));
    }

    [Theory]
    [InlineData("{<>}()[]", true)]
    [InlineData("<{])", false)]
    [InlineData("((({})))", true)]
    [InlineData("", true)]
    [InlineData("(", false)]
    [InlineData("({)}", false)]
    [InlineData(")()(", false)]
    [InlineData("(correct)[sequence]{with}<some>([<text>])", true)]
    [InlineData("Incorrect sequence :)", false)]
    [InlineData("(]", false)]
    public void Test_BracketPairsTask(string line, bool expected)
    {
        var openingBrackets = new[] { '(', '{', '[', '<' };
        var closingBrackets = new[] { ')', '}', ']', '>' };

        var stack = new Stack<char>();

        foreach (var character in line)
            if (openingBrackets.Contains(character))
                stack.Push(character);
            else if (closingBrackets.Contains(character))
                if (stack.IsEmpty || Array.IndexOf(openingBrackets, stack.Pop()) !=
                    Array.IndexOf(closingBrackets, character))
                {
                    Assert.False(expected);
                    return;
                }

        Assert.Equal(expected, stack.IsEmpty);
    }
}