using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;
using NUnit.Framework.Internal;

namespace Codecool.MarsExplorationTest;

public class CoordinateCalculatorTest
{
    [Test]
    public void TheCoordinateCalculatorTest()
    {

        var coordinateCalculator = new CoordinateCalculator();

       var result= coordinateCalculator.GetAdjacentCoordinates(new Coordinate(3, 3), 5);
       TestContext.Out.WriteLine(result.First().X);
       TestContext.Out.WriteLine(result.First().Y);
        Assert.That(result.First().X.Equals(2));
        Assert.That(result.First().Y.Equals(2));

    }
    [Test]
    public void TheCoordinateCalculatorTestforEdge()
    {

        var coordinateCalculator = new CoordinateCalculator();

        var result= coordinateCalculator.GetAdjacentCoordinates(new Coordinate(0, 0), 5);
        TestContext.Out.WriteLine(result.First().X);
        TestContext.Out.WriteLine(result.First().Y);
        Assert.That(result.Count().Equals(3));
       

    }
    [Test]
    public void TheCoordinateCalculatorTestfor24Edge()
    {

        var coordinateCalculator = new CoordinateCalculator();

        var result= coordinateCalculator.GetAdjacentCoordinates(new Coordinate(4, 4), 5);
        TestContext.Out.WriteLine(result.First().X);
        TestContext.Out.WriteLine(result.First().Y);
        Assert.That(result.Count().Equals(3));
       

    }
    
    
}