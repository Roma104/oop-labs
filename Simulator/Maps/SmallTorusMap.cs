using System;
using System.Drawing;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        public SmallTorusMap(int sizex, int sizey) : base(sizex, sizey)
        {
            if(sizex > 20)
                throw new ArgumentOutOfRangeException(nameof(sizex), "Size must be below 20");
            if (sizey > 20)
                throw new ArgumentOutOfRangeException(nameof(sizey), "Size must be below 20");


        }

        public override Point Next(Point p, Direction d)
        {
            int x = p.X;
            int y = p.Y;

            switch (d)
            {
                case Direction.Up:
                    y = (y + 1) % Sizey;       // Y rośnie do góry w teście
                    break;
                case Direction.Down:
                    y = (y - 1 + Sizey) % Sizey; // Y maleje w dół
                    break;
                case Direction.Left:
                    x = (x - 1 + Sizex) % Sizex;
                    break;
                case Direction.Right:
                    x = (x + 1) % Sizex;
                    break;
            }

            return new Point(x, y);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            int x = p.X;
            int y = p.Y;

            switch (d)
            {
                case Direction.Up:
                    x = (x + 1) % Sizex;
                    y = (y + 1) % Sizey;
                    break;
                case Direction.Right:
                    x = (x + 1) % Sizex;
                    y = (y - 1 + Sizey) % Sizey;
                    break;
                case Direction.Down:
                    x = (x - 1 + Sizex) % Sizex;
                    y = (y - 1 + Sizey) % Sizey;
                    break;
                case Direction.Left:
                    x = (x - 1 + Sizex) % Sizex;
                    y = (y + 1) % Sizey;
                    break;
            }

            return new Point(x, y);
        }
    }
}
