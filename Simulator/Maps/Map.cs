using Simulator;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{

    private Dictionary<Point, List<Creature>> _points;


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


    /// <summary>
    /// Add creature to the map at point p.
    /// </summary>
    /// <param name="creature"> Creature to place on the map </param>
    /// <param name="p">Point where creature apeares</param>
    public abstract void Add(Creature creature, Point p);


    /// <summary>
    /// Removing creature from the map.
    /// </summary>
    /// <param name="creature">Vreature we are removing from the map (maybe it died :(((( )</param>
    public  abstract void Remove(Creature creature);



    public void Move(Creature creature, Point p)
    {
        Remove(creature);
        Add(creature, p);
    }
    

    /// <summary>
    /// Get list of creatures
    /// </summary>
    /// <param name="p"> point to check</param>
    /// <returns></returns>
    public abstract List<Creature>? At(Point p);



    /// <summary>
    /// Get list of creatures at given coordinates
    /// </summary>
    /// <param name="x">point to check x coordinates</param>
    /// <param name="y">point to check y coordinates</param>
    /// <returns></returns>
    public List<Creature>? At(int x, int y)
    {
        return At( new Point(x,y));
    }






}