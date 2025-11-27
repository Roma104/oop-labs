namespace Simulator;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Starting simulation!\n");
        Console.WriteLine("=====================\n");
        Console.WriteLine("\n---Testin_Elfs_and_Orcs---\n");
        TestElfsAndOrcs();
        Console.WriteLine("\n---Testing_String---\n");
        TestObjectsToString();
    }

    static void TestElfsAndOrcs()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
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

    static void TestObjectsToString()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
    }






    //Elf e = new() { Name = "Elandor", Level = 5 };
    //Elf e = new() { "Elandor", 5, 7 };
    //Elf e = new();

    /*Creature e = new Orc("Elandor", 5, 7);
    Console.WriteLine(e.GetType());
    e.SayHi();   
    e.Upgrade();
    Console.WriteLine(e.Info);
    //e.Sing();
    if (e is Elf elf) elf.Sing();
    else Console.WriteLine($"{e.Name} is not Elf");
    // Elandor [7]
    e.Go(Direction.Left); */

    //object o = 5;
    //Console.WriteLine(o.GetType());
    //o = e;
    //Console.WriteLine(o.GetType());

    //object s = "I am object";
    //int j = 5;
    //object i = j;
    //object e = new Elf() { Name = "Legolas", Agility = 3 };

    //object[] objects = { s, i, e };

    //foreach (var o in objects)
    //{
    //Console.WriteLine(o);
    //}



    /*
     int size = 1_000_000;
     int[] src = new int[size];
     int[] idst = new int[size];
     int[] odst = new int[size]; (PHOTO CHECK)
    */


    /*static void TestCreatures()
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
    }*/

    /*static void TestDirections()
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






    // wywołanie
    //TestCreatures();

    */

    /*TestDirections(); */



}



//Console.ReadKey(); //znikał mi terminal bez tego 