using Simulator;
using Simulator.Maps;

namespace Simulator;

public class Simulation
{

    //private fields for tracking current creature and move
    private int _creatureIndex = 0;  
    private int _moveIndex = 0;
    private readonly List<Direction> _parsedMoves;

    //for finished property
    private readonly int _totalMovesCount;


    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMapable> IMapables { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves.
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves,
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public IMapable CurrentImapable => IMapables[_creatureIndex];
        

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName 
    {
        get
        {
            if(Finished || _parsedMoves.Count == 0) return string.Empty;
            

            Direction dir = _parsedMoves[_moveIndex];
            return dir.ToString().ToLower();
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMapable> imapables,
        List<Point> positions, string moves)
    {
        IMapables = imapables;

        if (imapables == null || imapables.Count == 0) 
        { 
            throw new ArgumentException("Creatures list cannot be empty", nameof(imapables));
        }
        if (imapables.Count != positions.Count) 
        { 
            throw new ArgumentException("Number of creatures must match number of positions", nameof(positions));
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Positions = positions;
        Moves = moves;

        _parsedMoves = DirectionParser.Parse(moves);

        _totalMovesCount = _parsedMoves.Count;

        for(int i = 0; i < IMapables.Count; i++)
        {
            IMapables[i].InitMapAndPositon(Map, Positions[i]);
        }

    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation is already finished");
        }

        // Pobieramy dane dla bieżącego ruchu
        Direction currentDirection = _parsedMoves[_moveIndex];
        IMapable itemToMove = CurrentImapable;

        // Wykonujemy ruch (opakowany w try-catch dla bezpieczeństwa)
        try
        {
            itemToMove.Go(currentDirection);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error during move for {itemToMove.Name}: {e.Message}");
        }

        // Zwiększamy indeksy o JEDEN
        _moveIndex++;
        _creatureIndex = (_creatureIndex + 1) % IMapables.Count;

        // Sprawdzamy, czy to był ostatni ruch
        if (_moveIndex >= _totalMovesCount)
        {
            Finished = true;
        }
    }
}