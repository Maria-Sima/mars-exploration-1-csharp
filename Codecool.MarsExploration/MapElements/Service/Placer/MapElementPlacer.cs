using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlacer : IMapElementPlacer
{
	public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
	{
		if (map[coordinate.X, coordinate.Y] != " ") return false;
		Map map2 = new Map(map);
		Console.WriteLine(map2);
		for (int i = coordinate.X; i < element.Dimension; i++)
		{
			for (int j = coordinate.Y; j < element.Dimension; j++)
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

		for (int i = coordinate.X; i < element.Dimension; i++)
		{
			int elementJ = 0;
			for (int j = coordinate.Y; j < element.Dimension; j++)
			{
				map[i, j] = element.Representation[elementI, elementJ];
				elementJ++;
			}

			elementI++;
		}

		return map;
	}
}