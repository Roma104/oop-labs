using Simulator;
using Simulator.Maps;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {


        //TestingSmallSquareMap();

        /*Console.Write("Starting simulation!\n");
        Console.WriteLine("=====================\n");
        Console.WriteLine("\n---Testin_Elfs_and_Orcs---\n");
        TestElfsAndOrcs();
        Console.WriteLine("\n---Testing_String---\n");
        TestObjectsToString();*/

        //Console.WriteLine("\n---Testing_Directions_and_Points---\n");
        //Console.WriteLine("====================================");
        //Point p = new(10, 25);
        //Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        //Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)

        //Console.WriteLine("\n---Testing_Rectangle---\n");
        //TestingRectangle();

        //Console.WriteLine("\n---Testing_Validators---\n");
        //TestValidators();
        /*
        Console.WriteLine("--- Testing Creatures ---");
        TestCreatures();
        Console.WriteLine("\n--- Testing Directions ---");
        TestDirections(); */
    }



    /*static void TestingSmallSquareMap()
    {
        Console.WriteLine("\n--- Testing SmallSquareMap ---");

        // Tworzymy mapę 10x10
        SmallSquareMap map = new SmallSquareMap(10);
        Console.WriteLine($"Map size: {map.Size}x{map.Size}");

        Point p = new Point(5, 5);
        Console.WriteLine($"Current point: {p}");

        // Próba ruchu wprost w każdym kierunku
        foreach (Direction d in Enum.GetValues(typeof(Direction)))
        {
            Point next = map.Next(p, d);
            Console.WriteLine($"Next {d}: {next}");
        }

        // Próba ruchu po skosie w każdym kierunku
        foreach (Direction d in Enum.GetValues(typeof(Direction)))
        {
            Point nextDiag = map.NextDiagonal(p, d);
            Console.WriteLine($"NextDiagonal {d}: {nextDiag}");
        }

        // Test punktów na krawędzi mapy
        Point edge = new Point(9, 9);
        Console.WriteLine($"\nEdge point: {edge}");
        Console.WriteLine($"Next Right: {map.Next(edge, Direction.Right)}"); // powinno pozostać (9,9)
        Console.WriteLine($"NextDiagonal Up: {map.NextDiagonal(edge, Direction.Up)}"); // powinno pozostać (9,9)

        // Test metody Exist()
        Point inside = new Point(0, 0);
        Point outside = new Point(10, 10);
        Console.WriteLine($"\nExist {inside}: {map.Exist(inside)}");   // True
        Console.WriteLine($"Exist {outside}: {map.Exist(outside)}");   // False
    }




    /*static void TestingRectangle()
    {
        Rectangle rect = new Rectangle(2, 3, 5, 7);
        Console.WriteLine(rect); // (2, 3):(5, 7)
        Point insidePoint = new Point(3, 4);
        Point outsidePoint = new Point(6, 8);
        Point OnLine = new Point(3, 3);
        Point Trick = new Point(2, 9);
        Console.WriteLine($"Contains {insidePoint}: {rect.Contains(insidePoint)}");   // True
        Console.WriteLine($"Contains {outsidePoint}: {rect.Contains(outsidePoint)}"); // False
        Console.WriteLine($"Contains {OnLine}: {rect.Contains(OnLine)}");             // True
        Console.WriteLine($"Contains {Trick}: {rect.Contains(Trick)}");             // False
    }

    /*static void TestElfsAndOrcs()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.Greeting();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.Greeting();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.Greeting();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.Greeting();
        } 

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }

    /*static void TestObjectsToString()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
    }*/

    /*static void TestValidators()
    {
        Console.WriteLine("\nVALIDATORS TEST\n");

        Creature c = new Orc() { Name = "    Shrek    ", Level = 20 };
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("  ", -5);
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Orc("  donkey ") { Level = 7 };
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Elf("Puss in Boots – a clever and brave cat.");
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new Orc("a                          troll name", 5);
        c.Upgrade();
        Console.WriteLine(c.Info);

        var a = new Animals() { Description = "    Cats " };
        Console.WriteLine(a.Info);

        a = new Animals() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);
    }*/

}



        
  
    /*
    static void TestCreatures()
    {
        Creature c = new() { Name = "   Shrek    ", Level = 20 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  ", -5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("  donkey ") { Level = 7 };
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("Puss in Boots – a clever and brave cat.");
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        c = new("a                            troll name", 5);
        c.SayHi();
        c.Upgrade();
        Console.WriteLine(c.Info);

        var a = new Animals() { Description = "   Cats " };
        Console.WriteLine(a.Info);

        a = new() { Description = "Mice           are great", Size = 40 };
        Console.WriteLine(a.Info);
    }

    static void TestDirections()
    {
        Creature c = new("Shrek", 7);
        c.SayHi();
        Console.WriteLine("\n* Up");
        c.Go(Direction.Up);

        Console.WriteLine("\n* Right, Left, Left, Down");
        Direction[] directions = {
            Direction.Right, Direction.Left, Direction.Left, Direction.Down
        };
        c.Go(directions);

        Console.WriteLine("\n* LRL");
        c.Go("LRL");

        Console.WriteLine("\n* xxxdR lyyLTyu");
        c.Go("xxxdR lyyLTyu");
    }
    */

 