namespace Simulator;

public class Orc : Creature
{
    public int Rage { get; set; } = 1;

    private int huntCount = 0;
    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        huntCount++;

        if ( huntCount % 2 == 0)
            Rage = Math.Min(10, Rage + 1);

    }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
        this.Rage = Math.Clamp(rage, 0, 10);
    }

    public Orc()
    {
        Rage = 1;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, My name is {Name}, my level is {Level}, and my rage is {Rage}.");
    }

    public override int Power => 7 * Level + 3 * Rage;

}
