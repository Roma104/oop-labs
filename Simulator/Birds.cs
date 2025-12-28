using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override char MapSymbol => CanFly ? 'B':'b'; // 'B' dla latających ptaków, 'b' dla nielatających

    public override void Go(Direction direction)
    {
        if (_map == null) return;
        // Ptaki latające robią dwa kroki na raz
        if (CanFly)
        {
            base.Go(direction);
            base.Go(direction);
        }
        else
        {
            // Nielatające ptaki robią jeden krok na raz po skosie
            Point nextPoint = _map.NextDiagonal(_point, direction);
            _map.Move(this, nextPoint);   
            _point = nextPoint;
        }
    }



    public virtual string Info => $"{Description} <{Size}>";

    public override string ToString()
    {
        return $"BIRDS: {Info}";
    }

}
