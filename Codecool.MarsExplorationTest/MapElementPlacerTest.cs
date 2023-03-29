using System.Xml.Linq;
using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Placer;

namespace Codecool.MarsExplorationTest;

public class MapElementPlacerTest
{
	private string[,] representation;
	private string[,] elementRepresentation;
	private Map map;
	private MapElement mapElement;
	private MapElementPlacer mapElementPlacer;
	
	[SetUp]
	public void Setup()
	{
		representation = new string[10,10];
		for (int i = 0; i < 10; i++)
		{
			for (int j = 0; j < 10; j++) representation[i, j] = " ";
		}
		representation[0, 0] = "#";
		map = new Map(representation);
		mapElementPlacer = new MapElementPlacer();
		elementRepresentation = new string[1, 1] { { "%" } };
		mapElement = new MapElement(elementRepresentation, "mineral", 1, "#");
	}

	[TestCase(0,1)]
	[TestCase(1,1)]
	[TestCase(1,0)]
	public void CanPlaceElementTest(int x, int y)
	{
		bool verification = mapElementPlacer.CanPlaceElement(mapElement, map.Representation, new Coordinate(x, y));
		
		Assert.True(verification);
	}
}