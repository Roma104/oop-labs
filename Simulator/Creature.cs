using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;
public abstract class Creature
{
    //pola są prywatne
    private string name = "Unknown";
    private int level = 1;

    private Map? _map = null;
    private Point _point = default;

    /// <summary>
    /// Symbol representing the creature on the map.
    /// </summary>
    public abstract char Symbol { get; }

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

    public void InitMapAndPositon(Map map, Point startingPosition)
    {
        if (map == null) return;

        //TODO: check if this is required
        if (!map.Exist(startingPosition)) 
            throw new ArgumentOutOfRangeException(nameof(startingPosition), "Starting position is outside the map.");

        try 
        { 
            map.Add(this, startingPosition);
        }
        catch
        {
            throw;
        }
        _map = map;
        _point = startingPosition;

    }




    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }
    public Creature() { }
    //public abstract void SayHi();

    public abstract string Greeting();

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

    public void  Go(Direction direction)
    {
        if (_map == null) return;

        Point nextPoint = _map!.Next(_point, direction);
        try
        {
            _map?.Move(this, nextPoint);
        }
        catch
        {
            throw;
        }

        _point = nextPoint;
    }



   /* public void Go(Direction direction)
    {
        string dir = direction.ToString().ToLower();
        Console.WriteLine($"{Name} goes {dir}.");
    }*/

    /*public string[] Go(List<Direction> directions)
    {
        var results = new string[directions.Count];   
        for (int i = 0; i < directions.Count; i++)
        {
            results[i] = Go(directions[i]);
        }
        return results;
    }

    public string[] Go(string input)
    {
        List<Direction> dirs = DirectionParser.Parse(input);
        return Go(dirs);
    }*/


}