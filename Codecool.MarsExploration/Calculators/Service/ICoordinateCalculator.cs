using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.Calculators.Service;

public interface ICoordinateCalculator
{
    Coordinate GetRandomCoordinate(int dimension);
    IEnumerable<Coordinate> GetNeighbouringCoordinates(Coordinate coordinate, int dimension);
    public IEnumerable<Coordinate> GetAdjacentCoordinates(IEnumerable<Coordinate> coordinates,
        int dimension);
}
