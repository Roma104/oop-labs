namespace Simulator.Maps;

public interface IMapable
{
    object Name { get; set; }
    Map? _map {get;}
    char MapSymbol { get; }
    void Go(Direction direction);
    void InitMapAndPositon(Map map, Point startingPosition);
}
