using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point(X, Y + 1),
            Direction.Down => new Point(X, Y - 1),
            Direction.Left => new Point(X - 1, Y),
            Direction.Right => new Point(X + 1, Y),
            _ => this
        };
    }

    // rotate given direction 45 degrees clockwise
   
    public Point NextDiagonal(Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Point(X + 1, Y + 1),    // Up → Up-Right
            Direction.Right => new Point(X + 1, Y - 1), // Right → Down-Right
            Direction.Down => new Point(X - 1, Y - 1), // Down → Down-Left
            Direction.Left => new Point(X - 1, Y + 1), // Left → Up-Left
            _ => this //musiałam to sobie rozrysować  TOT sie pogubiłam w tych kierunkach T_T
        };
    }
}