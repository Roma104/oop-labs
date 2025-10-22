using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public class Creature
{
    public string Name { get; set; }
   

    private int level;
    public int Level
    {
        get => level;
        set => level = value > 0 ? value : 1;
    }


    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature()
    {
        Name = "Unknown";
        Level = 1;
    }


    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    }

    //public string GetName() { return Name; }
    //public int GetLevel() { return Level; }
    //public void SetLevel(int level) { this.Level = level > 0 ? level : 1; } //jeśli level większy od 1 to ustaw go, jak nie to daj 1
    public string Info
    {
        get { return $"{Name} [{Level}]"; }

    }


}