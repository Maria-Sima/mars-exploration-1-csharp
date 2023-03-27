using Codecool.MarsExploration.Configuration.Model;

namespace Codecool.MarsExploration.Configuration.Service;

public class MapConfigurationValidator : IMapConfigurationValidator
{
	public bool Validate(MapConfiguration mapConfig)
	{
		if (!ValidateMapConfiguration()) return false;

		return true;

		bool ValidationCases(MapElementConfiguration elem, ElementToDimension item)
		{
			switch (elem.Name)
			{
				case "mountain":
					if (elem.DimensionGrowth != 3)
					{
						Console.WriteLine($"Mountain dimension growth is {elem.DimensionGrowth} and not 3!");
						return false;
					}

					break;
				case "pit":
					if (elem.DimensionGrowth != 10)
					{
						return false;
					}

					break;
				case "mineral":
					if (elem.DimensionGrowth != 0 || item.Dimension != 1)
					{
						return false;
					}

					break;
				case "water":
					if (elem.DimensionGrowth != 0 || item.Dimension != 1)
					{
						return false;
					}

					break;
			}

			return true;
		}

		bool ValidateElementsToDimensions(MapElementConfiguration elem)
		{
			foreach (var item in elem.ElementsToDimensions)
			{
				if (!ValidationCases(elem, item)) return false;
			}

			return true;
		}

		bool ValidateMapConfiguration()
		{
			foreach (var elem in mapConfig.MapElementConfigurations)
			{
				if (!ValidateElementsToDimensions(elem)) return false;
			}

			return true;
		}
	}
}