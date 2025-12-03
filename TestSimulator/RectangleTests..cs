using Simulator;
using Xunit;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldOrderCoordinates()
    {
        var r = new Rectangle(5, 7, 2, 3);
        Assert.Equal(2, r.X1);
        Assert.Equal(3, r.Y1);
        Assert.Equal(5, r.X2);
        Assert.Equal(7, r.Y2);
    }

    [Fact]
    public void Constructor_ZeroLength_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(1, 1, 1, 5));
        Assert.Throws<ArgumentException>(() => new Rectangle(2, 2, 5, 2));
    }

    [Fact]
    public void Contains_ShouldDetectPointsCorrectly()
    {
        var r = new Rectangle(0, 0, 3, 3);
        Assert.True(r.Contains(new Point(0, 0)));
        Assert.True(r.Contains(new Point(3, 3)));
        Assert.False(r.Contains(new Point(4, 4)));
        Assert.False(r.Contains(new Point(-1, 0)));
    }

    [Fact]
    public void ToString_ShouldReturnExpectedFormat()
    {
        var r = new Rectangle(1, 2, 3, 4);
        Assert.Equal("(1, 2):(3, 4)", r.ToString());
    }
}
