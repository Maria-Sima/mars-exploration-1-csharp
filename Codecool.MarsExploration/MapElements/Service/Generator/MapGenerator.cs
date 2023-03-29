using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Builder;
using Codecool.MarsExploration.MapElements.Service.Placer;

namespace Codecool.MarsExploration.MapElements.Service.Generator;

public class MapGenerator : IMapGenerator
{
	public Map Generate(MapConfiguration mapConfig)
	{
		IMapElementBuilder mapElementBuilder = new MapElementBuilder();
		IMapElementPlacer mapElementPlacer = new MapElementPlacer();
		IMapElementsGenerator mapElementsGenerator = new MapElementGenerator(mapElementBuilder);
		CoordinateCalculator coordinateCalculator = new CoordinateCalculator();

		var elements = mapElementsGenerator.CreateAll(mapConfig);
		string[,] representation = new string[mapConfig.MapSize, mapConfig.MapSize];
		Console.WriteLine($"elements {elements.Count()}");

		for (int i = 0; i < mapConfig.MapSize; i++)
		{
			for (int j = 0; j < mapConfig.MapSize; j++)
			{
				representation[i, j] = " ";
			}
		}

		foreach (var element in elements)
		{
			for (int i = 0; i < 50; i++)
			{
				var coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
				if (!mapElementPlacer.CanPlaceElement(element, representation, coordinate))
				{
					Console.WriteLine(1);
					coordinate = coordinateCalculator.GetRandomCoordinate(mapConfig.MapSize);
				}
				else
				{
					Console.WriteLine($"x {coordinate.X}");
					Console.WriteLine($"y {coordinate.Y}");
					representation = mapElementPlacer.PlaceElement(element, representation, coordinate);
					break;
				}
			}
		}

		Map map = new Map(representation);
		return map;
	}
}