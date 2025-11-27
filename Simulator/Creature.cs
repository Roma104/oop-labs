using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;
public abstract class Creature
{
    //pola są prywatne
    private string name = "Unknown";
    private int level = 1;

  //  private bool nameSet = false;
  //  private bool levelSet = false;

    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
        /*{
            if (nameSet) return; // można go ustawić ylko raz
            nameSet = true;

            if (string.IsNullOrWhiteSpace(value))
            {
                name = "Unknown";
                return;
            }

            string temp = value.Trim();

            //jeśli za długie to obetnie po 25 znakach
            if (temp.Length > 25)
                temp = temp.Substring(0, 25).TrimEnd();

            // tam gdzie za krótkie to dopisze #
            if (temp.Length < 3)
                temp = temp.PadRight(3, '#');

            // zapewnienie że pierwsza litera jest zawsze wielka
            if (char.IsLower(temp[0]))
                temp = char.ToUpper(temp[0]) + temp.Substring(1);

            name = temp;
        }*/
    }

    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
        /*{
            if (levelSet) return; // można go ustawić tylko raz
            levelSet = true;

            int temp = value;
            if (temp < 1) temp = 1;
            if (temp > 10) temp = 10;

            level = temp;
        }*/



    }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }
    public abstract void SayHi();
    
        //Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
    public abstract int Power { get; }

    public void Upgrade()
    {
        if (level < 10)
            level++;
    }

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }



    public void Go(Direction direction)
    {
        string dir = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {dir}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var d in directions)
            Go(d);
    }

    public void Go(string input)
    {
        var dirs = DirectionParser.Parse(input);
        Go(dirs);
    }


}