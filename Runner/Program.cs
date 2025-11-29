using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
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

}
