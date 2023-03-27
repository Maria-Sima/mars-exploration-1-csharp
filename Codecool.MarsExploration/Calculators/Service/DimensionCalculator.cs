namespace Codecool.MarsExploration.Calculators.Service;

public class DimensionCalculator : IDimensionCalculator
{
	public int CalculateDimension(int size, int dimensionGrowth)
	{
		double squareRoot = Math.Sqrt(size);

		if (squareRoot != (int)squareRoot)
		{
			squareRoot++;
		}
		
		return (int)squareRoot + dimensionGrowth;
	}
}