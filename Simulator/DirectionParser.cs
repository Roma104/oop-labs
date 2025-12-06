using System;

public static class DirectionParser
{
	public static List<Direction> Parse(string input)
	{
		List<Direction> directions = new();

        foreach (char c in input.ToUpper())
        {
            switch (c)
            {
                case 'U':
                    directions.Add(Direction.Up);
                    break;
                case 'R':
                    directions.Add(Direction.Right);
                    break;
                case 'D':
                    directions.Add(Direction.Down);
                    break;
                case 'L':
                    directions.Add(Direction.Left);
                    break;

            }
        }
        return directions;

    }
}
