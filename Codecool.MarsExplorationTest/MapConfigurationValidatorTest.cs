using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.Configuration.Service;

namespace Codecool.MarsExplorationTest;

public class Tests
{
	public string mountainSymbol;
	public string pitSymbol;
	public string mineralSymbol;
	public string waterSymbol;
	public IMapConfigurationValidator _mapConfigurationValidator;
	
	[SetUp]
	public void Setup()
	{
		mountainSymbol = "#";
		pitSymbol = "&";
		mineralSymbol = "%";
		waterSymbol = "*";
		
		_mapConfigurationValidator = new MapConfigurationValidator();
	}

	[Test]
	public void MountainDimensionGrowthTest()
	{
		var mountainsCfg = new MapElementConfiguration(mountainSymbol, "mountain", new[]
		{
			new ElementToDimension(2, 20),
			new ElementToDimension(1, 30),
		}, 4);
		
		List<MapElementConfiguration> elementsCfg = new() { mountainsCfg };
		var cfg = new MapConfiguration(1000, 0.5, elementsCfg);

		bool validation = _mapConfigurationValidator.Validate(cfg);
		
		Assert.That(validation, Is.EqualTo(false));
	}
	
	[Test]
	public void WaterDimensionTest()
	{
		var watersCfg = new MapElementConfiguration(waterSymbol, "water", new[]
		{
			new ElementToDimension(6, 2),
		}, 0);
		
		List<MapElementConfiguration> elementsCfg = new() { watersCfg };
		var cfg = new MapConfiguration(1000, 0.5, elementsCfg);

		bool validation = _mapConfigurationValidator.Validate(cfg);
		
		Assert.That(validation, Is.EqualTo(false));
	}
}