using Simulator;
using Simulator.Maps;
using Xunit;

namespace TestSimulator;

public class SmallSquareMapTests
{
    

    [Fact]
    public void Exist_ShouldReturnTrueInsideAndFalseOutside()
    {
        var map = new SmallSquareMap(10);
        Assert.True(map.Exist(new Point(0, 0)));
        Assert.True(map.Exist(new Point(9, 9)));
        Assert.False(map.Exist(new Point(-1, 0)));
        Assert.False(map.Exist(new Point(10, 10)));
    }

    [Fact]
    public void Next_ShouldStayWithinLines()
    {
        var map = new SmallSquareMap(5);
        var p = new Point(0, 0);
        Assert.Equal(p, map.Next(p, Direction.Left));
        Assert.Equal(new Point(0, 1), map.Next(p, Direction.Up));
    }

    [Fact]
    public void NextDiagonal_ShouldStayWithinLines()
    {
        var map = new SmallSquareMap(5);
        var p = new Point(0, 0);
        Assert.Equal(p, map.NextDiagonal(p, Direction.Left));  // would go out
        Assert.Equal(new Point(1, 1), map.NextDiagonal(p, Direction.Up));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void Constructor_ValidSize_ShouldSetSize(int size)
    {
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrow(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }
}
