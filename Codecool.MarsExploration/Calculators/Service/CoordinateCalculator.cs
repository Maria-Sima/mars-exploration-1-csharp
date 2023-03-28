using Codecool.MarsExploration.Calculators.Model;

namespace Codecool.MarsExploration.Calculators.Service;

public class CoordinateCalculator : ICoordinateCalculator
{
    public Coordinate GetRandomCoordinate(int dimension)
    {
        Random random = new Random();

        int xCoordinate = random.Next(0, dimension);
        int yCoordinate = random.Next(0, dimension);

        return new Coordinate(xCoordinate, yCoordinate);
    }
    


    public IEnumerable<Coordinate> GetNeighbouringCoordinates(Coordinate coordinate, int dimension)
    {
        int x = coordinate.X;
        int y = coordinate.Y;
        List<Coordinate> adjacentCoordinates = new List<Coordinate>();
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                Coordinate coord = new Coordinate(i, j);
                if (coord != coordinate && j < dimension && i < dimension && i >= 0 && j >= 0  )
                {
                    adjacentCoordinates.Add(new Coordinate(i, j));
                }
                
            }
        }

        return adjacentCoordinates;
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(IEnumerable<Coordinate> coordinates,
        int dimension)
    {
       
        return coordinates.SelectMany(coordinate => GetNeighbouringCoordinates(coordinate, dimension));

        
    }
}