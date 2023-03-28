using System.Text;

namespace Codecool.MarsExploration.MapElements.Model;

public record Map(string?[,] Representation, bool SuccessfullyGenerated = false)
{
    protected static string CreateStringRepresentation(string?[,] arr)
    {
        StringBuilder sb = new StringBuilder(string.Empty);
        int maxI = arr.GetLength(0);
        int maxJ = arr.GetLength(1);
        for (int i = 0; i < maxI; i++)
        {
            sb.Append(",{");
            for (var j = 0; j < maxJ; j++)
            {
                sb.Append($"{arr[i, j]},");
            }

            sb.Append("}");
        }

        sb.Replace(",}", "}").Remove(0, 1);
        string result = sb.ToString();
        return result;
    }

    public override string ToString()
    {
        return CreateStringRepresentation(Representation);
    }
}
