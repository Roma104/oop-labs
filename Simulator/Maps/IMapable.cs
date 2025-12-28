namespace Simulator.Maps;

public interface IMapable
{
    string Name { get; }
    char MapSymbol { get; }
    void Go(Direction direction);
    void InitMapAndPositon(Map map, Point startingPosition);
    string ToString();
}
