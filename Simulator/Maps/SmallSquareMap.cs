using System;

namespace Simulator.Maps
{
    /// <summary>
    /// Small square map with points from (0,0) to (Size-1, Size-1).
    /// </summary>
    public class SmallSquareMap : Map
    {
        /// <summary>
        /// Size of the square map.
        /// </summary>
        public int Size { get; }

        private readonly Rectangle _bounds;

        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20");

            Size = size;
            _bounds = new Rectangle(0, 0, Size - 1, Size - 1);
        }

        /// <summary>
        /// Check if a point belongs to the map.
        /// </summary>
        public override bool Exist(Point p)
        {
            return _bounds.Contains(p);
        }

        /// <summary>
        /// Returns the next point in the given direction.
        /// If movement goes outside map, returns the same point.
        /// </summary>
        public override Point Next(Point p, Direction d)
        {
            Point next = p.Next(d);
            return Exist(next) ? next : p;
        }

        /// <summary>
        /// Returns the next diagonal point rotated 45 degrees clockwise.
        /// If movement goes outside map, returns the same point.
        /// </summary>
        public override Point NextDiagonal(Point p, Direction d)
        {
            Point next = p.NextDiagonal(d);
            return Exist(next) ? next : p;
        }
    }
}
