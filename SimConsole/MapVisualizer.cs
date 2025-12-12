using System;
using System.Text;
using Simulator.Maps;
using Simulator;


namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;
    private readonly int _width;
    private readonly int _height;

    public MapVisualizer(Map map)
    {
        _map = map;
        _width = map.Sizex;
        _height = map.Sizey;
    }

    private Map Get_map()
    {
        return _map;
    }

    /// <summary>
    /// Symbol for point on the map.
    /// </summary>
    /// <param name="p">point on the map.</param>
    /// <returns>Symbol: 'O', 'E', 'X' or ' '</returns>
    private char GetCellSymbol(Point p, Map _map)
    {
        // testing if the point is on the map
        if (!_map.Exist(p))
            return ' ';

        List<IMapable>? creatures = _map.At(p);

        if (creatures == null || creatures.Count == 0)
        {
            return ' '; // no creatures on the cell
        }
        else if (creatures.Count == 1)
        {
            // one creature; use acording symbol ('O', 'E')
            return creatures[0].MapSymbol;
        }
        else
        {
            // more than one creature; use 'X' to indicate conflict
            return 'X';
        }
    }

    /// <summary>
    /// draw the map to the console
    /// </summary>
    public void Draw()
    {
        Console.Clear();
        Console.WriteLine("--- SIMULATION MAP ---");
        Console.WriteLine($"Map Size: {_width}x{_height}");

        // console draws from top to bottom, so we need to iterate Y from top to bottom.
        //where Y= _height - 1 is the top row and Y=0 is the bottom row.
        // bc we started from 0,0 at bottom left.

        // drawing top border
        DrawBoundaryRow(0, Box.TopLeft, Box.TopMid, Box.TopRight, Box.Horizontal);

        // drawing rows
        for (int y = _height - 1; y >= 0; y--) // Iteracja od góry mapy w dół
        {
            // drawing content row
            DrawContentRow(y, Box.Vertical);

            // drawing middle boundary row if not the last row
            if (y > 0)
            {
                DrawBoundaryRow(y, Box.MidLeft, Box.Cross, Box.MidRight, Box.Horizontal);
            }
        }

        // drawing bottom border
        DrawBoundaryRow(_height, Box.BottomLeft, Box.BottomMid, Box.BottomRight, Box.Horizontal);
    }

    // method to draw boundary rows (top, middle, bottom)
    private void DrawBoundaryRow(int rowIndex, char left, char mid, char right, char horizontal)
    {
        StringBuilder line = new StringBuilder();

        // top left corner/granica
        line.Append(left);

        for (int x = 0; x < _width; x++)
        {
            //drawing horizontal lines
            line.Append(horizontal);
            line.Append(horizontal);
            line.Append(horizontal);

            // drawing mid separator for all but last column
            if (x < _width - 1)
            {
                line.Append(mid);
            }
        }

        // right corner/granica
        line.Append(right);
        Console.WriteLine(line.ToString());
    }

    // method to help draw content rows (with symbols)
    private void DrawContentRow(int y, char vertical)
    {
        StringBuilder line = new StringBuilder();

        // left vertical border
        line.Append(vertical);

        for (int x = 0; x < _width; x++)
        {
            Point p = new Point(x, y);

            // dowlanding symbols (X, O, E lub ' ')
            char symbol = GetCellSymbol(p, Get_map());

            // writinf symbol with spaces
            line.Append(' ');
            line.Append(symbol);
            line.Append(' ');

            // drawing vertical separator
            line.Append(vertical);
        }

        Console.WriteLine(line.ToString());
    }
}