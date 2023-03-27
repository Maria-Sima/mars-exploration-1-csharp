using Codecool.MarsExploration.Calculators.Service;

namespace Codecool.MarsExplorationTest;

public class DimensionCalculatorTest
{
	[Test]
	public void CalculateDimensionTest()
	{
		var DimentionCalculator = new DimensionCalculator();
		var Result = DimentionCalculator.CalculateDimension(20, 3);
		Assert.That(Result, Is.EqualTo(8));
	}
	
	[Test]
	public void CalculateDimensionTestEdge()
	{
		var DimentionCalculator = new DimensionCalculator();
		var Result = DimentionCalculator.CalculateDimension(25, 3);
		Assert.That(Result, Is.EqualTo(8));
	}

}