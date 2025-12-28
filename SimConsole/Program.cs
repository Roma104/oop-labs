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
        while (true)
        {
            Console.WriteLine("SIMULATION MENU");
            Console.WriteLine("0.EXIT");
            Console.WriteLine("1.Old Simulation (Creatures)");
            Console.WriteLine("2.New Simulation (Animals & Birds)");
            Console.WriteLine("3.NEWER New Simulation (History)");


            char choice = Console.ReadKey(true).KeyChar;
            if (choice == '1') Sim1();
            else if (choice == '2') Sim2();
            else if (choice == '3') Sim3();
            else if (choice == '0') break;

        }
        
    }

    public static void Sim1()
    {
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
        Simulation simulation = new(map, creatures.Cast<IMapable>().ToList(), points, moves); MapVisualizer mapVisualizer = new(simulation.Map);
        int turnCount = 0;
        while (!simulation.Finished)
        {
            turnCount++;
            //drawing the map 
            mapVisualizer.Draw();
            // informations on the turn
            Console.WriteLine($"\n--- Turn {turnCount} ---");
            Console.WriteLine($"Creature: {simulation.CurrentImapable.Name} ({simulation.CurrentImapable.MapSymbol})"); //zaimplementować Imapable zamiast creater'ów
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
        foreach (var item in creatures)
        {
            Console.WriteLine($"- {item.Info}"); 
        }
        Console.ReadKey();
    }

    public static void Sim2()
    {
        SmallTorusMap map = new(8,6);
        List<IMapable> imapables = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 6 },
            new Birds { Description = "Eagles", Size = 4, CanFly = true },
            new Birds { Description = "Ostrich", Size = 5, CanFly = false }
        };
        List<Point> points = new()
        {
            new Point(1,1),
            new Point(2,2),
            new Point(3,3),
            new Point(4,4),
            new Point(5,5)
        };
        string moves = "luldruldruldruldruld";

        Simulation simulation = new(map, imapables, points, moves);

        MapVisualizer mapVisualizer = new(simulation.Map);

        int turnCount = 0;

        while (!simulation.Finished)
        {
            turnCount++;

            //drawing the map 
            mapVisualizer.Draw();

            // informations on the turn
            Console.WriteLine($"\n--- Turn {turnCount} ---");
            Console.WriteLine($"Creature: {simulation.CurrentImapable.Name} ({simulation.CurrentImapable.MapSymbol})"); //zaimplementować Imapable zamiast creater'ów
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
        foreach (var creature in imapables)
        {
            Console.WriteLine($"- {creature.ToString()}");
        }

        Console.ReadKey();
    }

    public static void Sim3()
    {
        // Te same dane co w Sim2
        SmallTorusMap map = new(8, 6);
        List<IMapable> imapables = new()
    {
        new Elf("Elandor"),
        new Orc("Gorbag"),
        new Animals { Description = "Rabbits", Size = 6 },
        new Birds { Description = "Eagles", Size = 4, CanFly = true },
        new Birds { Description = "Ostrich", Size = 5, CanFly = false }
    };
        List<Point> points = new()
    {
        new Point(1,1), new Point(2,2), new Point(3,3), new Point(4,4), new Point(5,5)
    };
        string moves = "luldruldruldruldruld"; // 20 ruchów

        // 1. Inicjalizacja symulacji
        Simulation simulation = new(map, imapables, points, moves);

        // 2. Wykonanie i zalogowanie (tu się wszystko dzieje i zapisuje)   
        SimulationLog log = new SimulationLog(simulation);

        // 3. Wizualizacja historii
        LogVisualizer visualizer = new LogVisualizer(log);

        int[] turnsToShow = { 5, 10, 15, 20 };

        foreach (int t in turnsToShow)
        {
            Console.Clear();
            Console.WriteLine("--- SIMULATION HISTORY (TURNS 5, 10, 15, 20) ---");
            visualizer.Draw(t);
            Console.WriteLine("\nPress any key to see next required turn...");
            Console.ReadKey();
        }

        Console.WriteLine("End of history preview.");
        Console.ReadKey();
    }

}


