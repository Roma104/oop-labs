using Simulator;

namespace SimConsole;

internal class LogVisualizer
{
    SimulationLog Log { get; }

    public LogVisualizer(SimulationLog log)
    {
        Log = log;
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
        {
            Console.WriteLine("Invalid turn index!");
            return;
        }

        var turn = Log.TurnLogs[turnIndex];

       
        Console.WriteLine($"Turn: {turnIndex}");
        Console.WriteLine($"Movable: {turn.Mappable}");
        Console.WriteLine($"Move: {turn.Move}");


        // Rysowanie mapy (kod uproszczony z MapVisualizer)
        DrawBoundary(Box.TopLeft, Box.TopMid, Box.TopRight);

        for (int y = Log.Sizey - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < Log.Sizex; x++)
            {
                char symbol = turn.Symbols.GetValueOrDefault(new Point(x, y), ' ');
                Console.Write($" {symbol} {Box.Vertical}");
            }
            Console.WriteLine();
            if (y > 0) DrawBoundary(Box.MidLeft, Box.Cross, Box.MidRight);
        }

        DrawBoundary(Box.BottomLeft, Box.BottomMid, Box.BottomRight);
    }

    private void DrawBoundary(char left, char mid, char right)
    {
        Console.Write(left);
        for (int x = 0; x < Log.Sizex; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.Horizontal}{Box.Horizontal}");
            if (x < Log.Sizex - 1) Console.Write(mid);
        }
        Console.WriteLine(right);
    }
}