using Roomex.Distance.Calculator.Converters;
using Roomex.Distance.Calculator.ExtensionMethods;
using Roomex.Distance.Calculator.Models;

namespace Roomex.Distance.Calculator.Calculators;

public class PolarCoordinateFlatEarthCalculator : ICoordinateDistanceCalculator
{
    public double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, IMetreConverter? converter = null)
    {
        const double radius = 6371008.7714d;
        var a = (90 - coordinateB.Latitude).ToRadians();
        var b = (90 - coordinateA.Latitude).ToRadians();
        var phi = (coordinateA.Longitude - coordinateB.Longitude).ToRadians();
        var fe = Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(phi);
        var distance = radius * Math.Sqrt(fe);
        return converter?.ConvertFromMetres(distance) ?? distance;
    }
}