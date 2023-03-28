using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;
using NUnit.Framework.Internal;

namespace Codecool.MarsExplorationTest;

public class CoordinateCalculatorTest
{
    [TestFixture]
    public class CoordinateTests
    {
        [Test]
        public void GetNeighbouringCoordinates_ReturnsCorrectCoordinates()
        {
            
            Coordinate coordinate = new Coordinate(1, 1);
            int dimension = 3;
            Coordinate[] expected = new Coordinate[]
            {
                new Coordinate(0, 0),
                new Coordinate(0, 1),
                new Coordinate(0, 2),
                new Coordinate(1, 0),
                new Coordinate(1, 2),
                new Coordinate(2, 0),
                new Coordinate(2, 1),
                new Coordinate(2, 2),
            };
            var coordinateCalculator = new CoordinateCalculator();
            
            IEnumerable<Coordinate> actual = coordinateCalculator.GetNeighbouringCoordinates(coordinate,dimension);

            
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void GetNeighbouringCoordinates_DoesNotReturnSameCoordinate()
        {
           
            Coordinate coordinate = new Coordinate(1, 1);
            int dimension = 3;
            var coordinateCalculator = new CoordinateCalculator();
            IEnumerable<Coordinate> actual = coordinateCalculator.GetNeighbouringCoordinates(coordinate,dimension);

            Assert.IsFalse(actual.Contains(coordinate));
        }

        [Test]
        public void GetNeighbouringCoordinates_DoesNotReturnCoordinatesOutsideTheDimension()
        {
            
            Coordinate coordinate = new Coordinate(0, 0);
            int dimension = 3;
            Coordinate[] expected = new Coordinate[]
            {
                new Coordinate(0, 1),
                new Coordinate(1, 0),
                new Coordinate(1, 1),
            };
            var coordinateCalculator = new CoordinateCalculator();
            
            IEnumerable<Coordinate> actual = coordinateCalculator.GetNeighbouringCoordinates(coordinate,dimension);

            
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void GetNeighbouringCoordinates_DoesNotReturnCoordinatesWithNegativeIndices()
        {
            
            Coordinate coordinate = new Coordinate(0, 0);
            int dimension = 3;
            Coordinate[] expected = new Coordinate[]
            {
                new Coordinate(0, 1),
                new Coordinate(1, 0),
                new Coordinate(1, 1),
            };
            var coordinateCalculator = new CoordinateCalculator();
            
            IEnumerable<Coordinate> actual = coordinateCalculator.GetNeighbouringCoordinates(coordinate,dimension);

            
            CollectionAssert.AreEquivalent(expected, actual);
        }
        
          [Test]
    public void GetAdjacentCoordinates_ReturnsEmptyList_WhenInputListIsEmpty()
    {
        
        var coordinates = Enumerable.Empty<Coordinate>();
        var dimension = 10;

        var coordinateCalculator = new CoordinateCalculator();
        var adjacentCoordinates = coordinateCalculator.GetAdjacentCoordinates(coordinates,dimension);

        
        CollectionAssert.IsEmpty(adjacentCoordinates);
    }

    [Test]
    public void GetAdjacentCoordinates_ReturnsAdjacentCoordinates_WhenInputListHasOneCoordinate()
    {
        
        var coordinates = new[] { new Coordinate(2, 2) };
        var dimension = 10;

        var coordinatesCalculator = new CoordinateCalculator();
       
        var adjacentCoordinates = coordinatesCalculator.GetAdjacentCoordinates(coordinates,dimension);

        
        CollectionAssert.AreEquivalent(
            new[]
            {
                new Coordinate(1, 1),
                new Coordinate(1, 2),
                new Coordinate(1, 3),
                new Coordinate(2, 1),
                new Coordinate(2, 3),
                new Coordinate(3, 1),
                new Coordinate(3, 2),
                new Coordinate(3, 3)
            },
            adjacentCoordinates);
    }

    [Test]
    public void GetAdjacentCoordinates_ReturnsAdjacentCoordinates_WhenInputListHasMultipleCoordinates()
    {
        var coordinates = new[] { new Coordinate(1, 1), new Coordinate(4, 4), new Coordinate(7, 7) };
        var dimension = 10;
        var coordinatesCalculator = new CoordinateCalculator();
       
        var adjacentCoordinates = coordinatesCalculator.GetAdjacentCoordinates(coordinates,dimension);

        
        CollectionAssert.AreEquivalent(
            new[]
            {
                new Coordinate(0, 0),
                new Coordinate(0, 1),
                new Coordinate(0, 2),
                new Coordinate(1, 0),
                new Coordinate(1, 2),
                new Coordinate(2, 0),
                new Coordinate(2, 1),
                new Coordinate(2, 2),
                new Coordinate(3, 3),
                new Coordinate(3, 4),
                new Coordinate(3, 5),
                new Coordinate(4, 3),
                new Coordinate(4, 5),
                new Coordinate(5, 3),
                new Coordinate(5, 4),
                new Coordinate(5, 5),
                new Coordinate(6, 6),
                new Coordinate(6, 7),
                new Coordinate(6, 8),
                new Coordinate(7, 6),
                new Coordinate(7, 8),
                new Coordinate(8, 6),
                new Coordinate(8, 7),
                new Coordinate(8, 8)
            },
            adjacentCoordinates);
    }

    [Test]
    public void GetAdjacentCoordinates_ReturnsEmptyList_WhenInputCoordinatesAreAtTheEdgeOfTheDimension()
    {
        
        var coordinates = new[] { new Coordinate(0, 0), new Coordinate(0, 9), new Coordinate(9, 0), new Coordinate(9, 9) };
        var dimension = 10;

        
        var coordinatesCalculator = new CoordinateCalculator();
       
        List<Coordinate> adjacentCoordinates = coordinatesCalculator.GetAdjacentCoordinates(coordinates,dimension).ToList();

        
        Assert.That(adjacentCoordinates.Count(), Is.EqualTo(12));
    }
}
    }
