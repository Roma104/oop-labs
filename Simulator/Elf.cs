namespace Simulator;

public class Elf : Creature
{
    //public int Agility { get; set; } = 1;

    private int agility;

    private int singCount = 0;

    // Implementacja symbolu
    public override char MapSymbol => 'E';

    public int Agility
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }


    public Elf(string name, int level = 1, int agility = 1) : base(name, level) 
    { 
        Agility = agility;
        CalculatePower = () => 8 * Level + 2 * Agility;
    }


    public void Sing()
    {
        //Console.WriteLine($"{Name} is singing");
        singCount++;
        if (singCount % 3 == 0)
            agility = Validator.Limiter(Agility + 1, 0, 10);
    }

    public Elf():this("Elf") { }
    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, and my agility is {Agility}.";
    }

    /*public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, and my agility is {Agility}.");
    }*/

    /*public override string ToString()
    {
        return $"Hi, I'm {Name}, my level is {Level}, and my agility is {Agility}.";
    }*/

    //public override int Power => 8 * Level + 2 * Agility;
    public override string Info => $"{Name}| Level: {Level}, Agility: {Agility} |";

}
