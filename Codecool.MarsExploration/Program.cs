using System.Text.RegularExpressions;
using System.Threading.Channels;
using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.Configuration.Service;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Builder;
using Codecool.MarsExploration.MapElements.Service.Generator;
using Codecool.MarsExploration.MapElements.Service.Placer;
using Codecool.MarsExploration.Output.Service;

internal class Program
{
    //You can change this to any directory you like
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        Console.WriteLine("Mars Exploration Sprint 1");
        var mapConfig = GetConfiguration();

        IDimensionCalculator dimensionCalculator = new DimensionCalculator();
        ICoordinateCalculator coordinateCalculator = new CoordinateCalculator();

        IMapElementBuilder mapElementFactory = new MapElementBuilder();
        var mountain = mapElementFactory.Build(20, "#", "mountain", 3);
        // Console.WriteLine(String.Join("", mountain));
        IMapElementsGenerator mapElementsGenerator = new MapElementGenerator(mapElementFactory);
        var genmap = mapElementsGenerator.CreateAll(mapConfig);
        // foreach (var gen in genmap)
        // {
        //     Console.WriteLine(gen);
        // }
    
        IMapConfigurationValidator mapConfigValidator = new MapConfigurationValidator();
        IMapElementPlacer mapElementPlacer = new MapElementPlacer();

        IMapGenerator mapGenerator = new MapGenerator();
        var map = mapGenerator.Generate(mapConfig);

        for (int i = 0; i < mapConfig.MapSize; i++)
        {
            for (int j = 0; j < mapConfig.MapSize; j++)
            {
                Console.Write(map.Representation[i, j]);
            }
        
            Console.WriteLine();
        }
        

        CreateAndWriteMaps(3, mapGenerator, mapConfig);

        Console.WriteLine("Mars maps successfully generated.");
        Console.ReadKey();
    }

    private static void CreateAndWriteMaps(int count, IMapGenerator mapGenerator, MapConfiguration mapConfig)
    {
    }

    private static MapConfiguration GetConfiguration()
    {
        const string mountainSymbol = "#";
        const string pitSymbol = "&";
        const string mineralSymbol = "%";
        const string waterSymbol = "*";

        var mountainsCfg = new MapElementConfiguration(mountainSymbol, "mountain", new[]
        {
            new ElementToDimension(2, 20),
            new ElementToDimension(1, 30),
        }, 3);

        var pitsCfg = new MapElementConfiguration(pitSymbol, "pit", new[]
        {
            new ElementToDimension(3, 20),
            new ElementToDimension(1, 15),
        }, 10);

        var mineralsCfg = new MapElementConfiguration(mineralSymbol, "mineral", new[]
        {
            new ElementToDimension(11, 1),
        }, 0);

        var watersCfg = new MapElementConfiguration(waterSymbol, "water", new[]
        {
            new ElementToDimension(20, 1),
        }, 0);

        List<MapElementConfiguration> elementsCfg = new() { mountainsCfg, pitsCfg, mineralsCfg, watersCfg };
        return new MapConfiguration(30, 0.5, elementsCfg);
    }
}

  

