using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Builder;

namespace Codecool.MarsExploration.MapElements.Service.Generator;

public class MapElementGenerator:IMapElementsGenerator
{
   
        private readonly IMapElementBuilder _mapElementBuilder;

        public MapElementGenerator(IMapElementBuilder mapElementBuilder)
        {
            _mapElementBuilder = mapElementBuilder;
        }

        public IEnumerable<MapElement> CreateAll(MapConfiguration mapConfig)
        {
            foreach (var elementConfig in mapConfig.MapElementConfigurations)
            {
                foreach (var elemToDim in elementConfig.ElementsToDimensions)
                {
                      var mapElement = _mapElementBuilder.Build(
                                        elemToDim.Dimension,
                                        elementConfig.Symbol,
                                        elementConfig.Name,
                                        elementConfig.DimensionGrowth,
                                        elementConfig.PreferredLocationSymbol
                                    );
                      
                      yield return mapElement;
                }
              
                
            }
        }
}