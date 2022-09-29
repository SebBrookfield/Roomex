using Roomex.Distance.Api.Converters;
using Roomex.Distance.Api.Models;

namespace Roomex.Distance.Api.Calculators;

public interface ICoordinateDistanceCalculator
{
    /// <summary>
    /// Takes two co-ordinates and returns the distance in metres, unless a converter is used to change the units.
    /// </summary>
    double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, IMetreConverter? converter = null);
}