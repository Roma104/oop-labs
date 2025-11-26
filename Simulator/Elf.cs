namespace Simulator;

public class Elf : Creature
{
    public int Agility { get; set; } = 1;

    private int singCount = 0;
    public void Sing()
    { Console.WriteLine($"{Name} is singing");
        singCount++;
        if (singCount % 3 == 0)
            Agility = Math.Min(10, Agility + 1);
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        this.Agility = Math.Clamp(agility, 0, 10);
    }

    public Elf() 
    {
        Agility = 1;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, my name is {Name}, my level is {Level}, and my agility is {Agility}.");
    }

    /*public override string ToString()
    {
        return $"Hi, I'm {Name}, my level is {Level}, and my agility is {Agility}.";
    }*/

    public override int Power => 8 * Level + 2 * Agility;

}
