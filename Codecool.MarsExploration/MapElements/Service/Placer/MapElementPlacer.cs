using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlacer : IMapElementPlacer
{
	public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
	{
		if (map[coordinate.X, coordinate.Y] != " ") return false;
	
		
		for (int i = coordinate.X; i < element.Dimension+coordinate.X; i++)
		{
			for (int j = coordinate.Y; j < element.Dimension+coordinate.Y; j++)
			{
				if (map[i, j] != " ")
				{
					Console.WriteLine(1);
					return false;
				}
			}
		}

		return true;
	}

	public string[,] PlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
	{
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

		return map;
	}
}