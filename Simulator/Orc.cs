namespace Simulator;

public class Orc : Creature
{
    //public int Rage { get; set; } = 1;
    private int rage;
    private int huntCount = 0;

    // Implementacja symbolu
    public override char MapSymbol => 'O';

    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level) => Rage = rage;

    public void Hunt()
    {
        //Console.WriteLine($"{Name} is hunting!");
        huntCount++;

        if ( huntCount % 2 == 0)
            rage = Validator.Limiter(Rage + 1,0,10);

    }

    

    public Orc(){}

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, and my rage is {Rage}.";
    }


    /*public override void SayHi()
    {
        Console.WriteLine($"Hi, My name is {Name}, my level is {Level}, and my rage is {Rage}.");
    }*/

    public override int Power => 7 * Level + 3 * Rage;
    public override string Info => $"{Name}| Level: {Level}, Rage: {Rage} |";

}
