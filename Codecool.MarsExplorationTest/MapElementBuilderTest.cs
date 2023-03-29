using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Builder;


public class MapElementBuilderTests
{
    [Test]
    public void BuildTest()
    {
        
        var size = 3;
        var symbol = "X";
        var name = "Test Element";
        var dimensionGrowth = 1;
        var elementSize = 4;
        var preferredLocationSymbol = "P";
        var dimensionCalculator = new DimensionCalculator();

       
        var mapElementBuilder = new MapElementBuilder();
        var mapElement = mapElementBuilder.Build(size, symbol, name, dimensionGrowth, preferredLocationSymbol);

        
        Assert.AreEqual(name, mapElement.Name);
        Assert.AreEqual(elementSize, mapElement.Dimension);
        Assert.AreEqual(symbol, mapElement.Representation);
    }
}