using Simulator;
using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimConsole;

public class Program
{
    public static void Main(string[] args)
    {
        //UTF-8
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(6);

        List<Creature> creatures = new List<Creature>
        {
            new Orc("Gorbag"),
            new Elf("Elandor")
        };

        List<Point> points = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1)
        };

        string moves = "dlrludllurdrru"; 

        Simulation simulation = new(map, creatures, points, moves);

        MapVisualizer mapVisualizer = new(simulation.Map);

        int turnCount = 0;

        while (!simulation.Finished)
        {
            turnCount++;

            //drawing the map 
            mapVisualizer.Draw();

            // informations on the turn
            Console.WriteLine($"\n--- Turn {turnCount} ---");
            Console.WriteLine($"Creature: {simulation.CurrentCreature.Name} ({simulation.CurrentCreature.Symbol})");
            Console.WriteLine($"Action: Move {simulation.CurrentMoveName.ToUpper()}");
            Console.WriteLine("Press ENTER to continue, or Q/ESC to quit...");

            // waiting for user input
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Q || key.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("\nSimulation interrupted by user.");
                return;
            }

            // turn execution
            simulation.Turn();
        }

        // --- finsih state ---
        mapVisualizer.Draw();
        Console.WriteLine("\n*** SIMULATION FINISHED ***");
        Console.WriteLine($"Total turns: {turnCount}");

        // final status of creatures
        Console.WriteLine("\nFinal Creature Status:");
        foreach (var creature in creatures)
        {
            // last info about each creature
            Console.WriteLine($"- {creature.Info}");
        }

        Console.ReadKey();
    }
}