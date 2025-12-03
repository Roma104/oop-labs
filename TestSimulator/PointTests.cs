using Simulator;
using Xunit;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Next_ShouldMoveCorrectlyToDrawnVisualisation()
    {
        var p = new Point(5, 5);
        Assert.Equal(new Point(5, 6), p.Next(Direction.Up));
        Assert.Equal(new Point(5, 4), p.Next(Direction.Down));
        Assert.Equal(new Point(4, 5), p.Next(Direction.Left));
        Assert.Equal(new Point(6, 5), p.Next(Direction.Right));
    }

    [Fact]
    public void NextDiagonal_ShouldMoveCorrectlyDrawnVisualisation()
    {
        var p = new Point(5, 5);
        Assert.Equal(new Point(6, 6), p.NextDiagonal(Direction.Up));
        Assert.Equal(new Point(6, 4), p.NextDiagonal(Direction.Right));
        Assert.Equal(new Point(4, 4), p.NextDiagonal(Direction.Down));
        Assert.Equal(new Point(4, 6), p.NextDiagonal(Direction.Left));
    }

    //tyle rysowania qwq (bo bez tego się gubie ngl hahaa
}
