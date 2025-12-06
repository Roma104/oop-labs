using Simulator;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{

    public readonly int Sizex;
    public readonly int Sizey;
    private readonly Rectangle area;
    protected Map(int sizex, int sizey)
    {
        if (sizex < 5)
            throw new ArgumentOutOfRangeException(nameof(sizex), "Size must be greater than 5");
        if (sizey < 5)
            throw new ArgumentOutOfRangeException(nameof(sizey), "Size must be greater than 5");
        Sizex = sizex;
        Sizey = sizey;
        area = new Rectangle(0, 0, Sizex - 1, Sizey - 1);


    }


    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return area.Contains(p);
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}