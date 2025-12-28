namespace Simulator;

public class SimulationLog
{
    private Simulation _simulation { get; }
    public int Sizex { get; }
    public int Sizey { get; }
    public List<TurnLog> TurnLogs { get; } = [];

    public SimulationLog(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        Sizex = _simulation.Map.Sizex;
        Sizey = _simulation.Map.Sizey;
        Run();
    }

    private void Run()
    {
        // KROK 0: Zapisujemy stan początkowy symulacji
        TurnLogs.Add(new TurnLog
        {
            Mappable = "Starting Position",
            Move = "None",
            Symbols = GetCurrentSymbols()
        });

        // Wykonujemy wszystkie ruchy w symulacji
        while (!_simulation.Finished)
        {
            string currentMappableName = _simulation.CurrentImapable.ToString();
            string currentMove = _simulation.CurrentMoveName;

            _simulation.Turn();

            TurnLogs.Add(new TurnLog
            {
                Mappable = currentMappableName,
                Move = currentMove,
                Symbols = GetCurrentSymbols()
            });
        }
    }

    private Dictionary<Point, char> GetCurrentSymbols()
    {
        var symbols = new Dictionary<Point, char>();
        for (int y = 0; y < Sizey; y++)
        {
            for (int x = 0; x < Sizex; x++)
            {
                var p = new Point(x, y);
                var items = _simulation.Map.At(p);
                if (items != null && items.Count > 0)
                {
                    // Jeśli jeden obiekt to -> jego symbol, jeśli więcej obiektów to -> 'X'
                    symbols[p] = items.Count > 1 ? 'X' : items[0].MapSymbol;
                }
            }
        }
        return symbols;
    }
}

public class TurnLog
{
    public required string Mappable { get; init; }
    public required string Move { get; init; }
    public required Dictionary<Point, char> Symbols { get; init; }
}