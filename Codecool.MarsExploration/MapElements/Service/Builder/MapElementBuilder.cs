using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Builder;

public class MapElementBuilder : IMapElementBuilder
{
	public MapElement Build(int size, string symbol, string name, int dimensionGrowth,
		string? preferredLocationSymbol = null)
	{
		DimensionCalculator dimensionCalculator = new DimensionCalculator();
		CoordinateCalculator coordinateCalculator = new CoordinateCalculator();

		int elementSize = dimensionCalculator.CalculateDimension(size, dimensionGrowth);
		string[,] element = new string[elementSize, elementSize];
		
		for (int i = 0; i < elementSize; i++)
		{
			for (int j = 0; j < elementSize; j++)
			{
				element.SetValue(" ", i, j);
			}

		}
		
		for (int i = 0; i < size; i++)
		{
			var coordinate = coordinateCalculator.GetRandomCoordinate(elementSize);
			while (element[coordinate.X, coordinate.Y] !=  " ")
			{
				coordinate = coordinateCalculator.GetRandomCoordinate(elementSize);
			}

			element[coordinate.X, coordinate.Y] = symbol;
		}

		MapElement mapElement = new MapElement(element, name, elementSize);

		return mapElement;
	}
}