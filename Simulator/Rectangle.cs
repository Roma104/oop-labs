using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Rectangle
{

    public readonly int X1, Y1;
    public readonly int X2, Y2;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        // zamiana, jeśli współrzędne w złej kolejności
        if (x1 > x2) (x1, x2) = (x2, x1);
        if (y1 > y2) (y1, y2) = (y2, y1);

        // sprawdzenie, czy prostokąt nie jest płaski, w sensie nie jest linią ;000
        if (x1 == x2 || y1 == y2)
            throw new ArgumentException("Rectangle sides cannot be zero-length");

        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
    }
    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y)
    {
    }

    // Sprawdzenie, czy punkt należy do prostokąta
    public bool Contains(Point point)
    {
        return point.X >= X1 && point.X <= X2 &&
               point.Y >= Y1 && point.Y <= Y2;
    }

    // Nadpisanie ToString()
    public override string ToString()
    {
        return $"({X1}, {Y1}):({X2}, {Y2})";
    }

    //dlatego klasa, a nie struktura bo przyjmując wspoółrzędne automatycznie wziął by 0,0 jako domyślne wartości dla X2 i Y2, a to tworzy nam 'prostokąt' o zerowej powierzchni, a tego nie chcemy.
}
