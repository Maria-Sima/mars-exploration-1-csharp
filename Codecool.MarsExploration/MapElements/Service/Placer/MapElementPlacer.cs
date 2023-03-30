using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlacer : IMapElementPlacer
{
	public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
	{
		int maxX = coordinate.X + element.Dimension;
		int maxY = coordinate.Y + element.Dimension;
		
		if (maxX > map.GetLength(0) || maxY > map.GetLength(1)) return false;
		for (int i = coordinate.X; i < maxX; i++)
		{
			for (int j = coordinate.Y; j < maxY; j++)
			{
				if (map[i, j] != " ")
				{
					//Console.WriteLine("over");
					return false;
				}
			}
		}

		return true;
	}

	public void PlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
	{
		//Console.WriteLine(coordinate.X + " " + element.Dimension);
		int elementI = 0;
		for (int i = coordinate.X; i < element.Dimension+coordinate.X; i++)
		{
			
			int elementJ = 0;
			for (int j = coordinate.Y; j < element.Dimension+coordinate.Y; j++)
			{
				map[i, j] = element.Representation[elementI, elementJ];
				elementJ++;
			}

			elementI++;
		}
	}
}

