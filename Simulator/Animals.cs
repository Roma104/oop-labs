using Simulator.Maps;
using System;


namespace Simulator;
// plural name because represents group of animals :v
public class Animals :IMapable
{

    protected Map? _map;
    protected Point _point;

    private string description = "Unknown";
    //private bool descriptionSet = false;
    public required string Description { get; init; }
    //public required string Description
    //{
      //  get => description;
        //init => description = Validator.Shortener(value, 3, 15, '#');
        /*init
        {
            if (descriptionSet) return;
            descriptionSet = true;

            if (string.IsNullOrWhiteSpace(value))
            {
                description = "Unknown";
                return;
            }

            string temp = value.Trim();

            // przycina do 15 znaków
            if (temp.Length > 15)
                temp = temp.Substring(0, 15).TrimEnd();

            // jeśli jest za krótkie to dopełnij #
            if (temp.Length < 3)
                temp = temp.PadRight(3, '#');

            // pierwsza litera zmienia się na wielką w razi w 
            if (char.IsLower(temp[0]))
                temp = char.ToUpper(temp[0]) + temp.Substring(1);

            description = temp;
        }*/
    //}
    //WYPEŁNIĆ TE NOTIMPLEMENTED LOOOOOL : DONE
    public uint Size { get; set; } = 3;
    public string Name => Description;
    public Map? CurrentMap => _map;
    public virtual char MapSymbol => 'A';//Domyślny symbol dla zwierząt

    public virtual void Go(Direction direction)
    {
        //dla zwierząt a potem dla ptaków override, one mają robić dwa razy po kroku a nie dwa kroki raz
        if (_map == null) return;
        Point nextPoint = _map.Next(_point, direction);
        _map.Move(this, nextPoint);
        _point = nextPoint;

    }

    public void InitMapAndPositon(Map map, Point startingPosition)
    {
        _map = map;
        _point = startingPosition;
        _map.Add(this, startingPosition);
    }

    
    public override string ToString() => $"{GetType().Name.ToUpper()}: {Name} <{Size}>";

}
