using Roomex.Distance.Calculator.Converters;
using Roomex.Distance.Calculator.ExtensionMethods;
using Roomex.Distance.Calculator.Models;
using static System.Math;

namespace Roomex.Distance.Calculator.Calculators;

internal class VincentyInverseDistanceCalculator : ICoordinateDistanceCalculator
{
    public double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB, IMetreConverter? converter = null)
    {
        const double semiMajorAxis = 6378137.0000d;
        const double semiMinorAxis = 6356752.314245d;
        const double flattening = (semiMajorAxis - semiMinorAxis) / semiMajorAxis;

        var longitudeDifference = coordinateA.Longitude.ToRadians() - coordinateB.Longitude.ToRadians();
        var latitudeA = coordinateA.Latitude.ToRadians();
        var latitudeB = coordinateB.Latitude.ToRadians();

        var λ = longitudeDifference;
        var p = Atan((1 - flattening) * Tan(latitudeA));
        var q = Atan((1 - flattening) * Tan(latitudeB));

        double λtick, sinσ, cosσ, σ, sinα, cosSquaredα, cos2σm;

        do
        {
            sinσ = Sqrt(PowOf2(Cos(q) * Sin(λ)) + PowOf2(Cos(p) * Sin(q) - Sin(p) * Cos(q) * Cos(λ)));
            cosσ = Sin(p) * Sin(q) + Cos(p) * Cos(q) * Cos(λ);
            σ = Atan(sinσ / cosσ);
            sinα = Cos(p) * Cos(q) * Sin(λ) / Sin(σ);
            cosSquaredα = 1 - PowOf2(sinα);
            cos2σm = cosσ - 2 * Sin(p) * Sin(q) / cosSquaredα;
            var c = flattening / 16 * cosSquaredα * (4 + flattening * (4 - 3 * cosSquaredα));
            λtick = λ;
            λ = longitudeDifference + (1 - c) * flattening * sinα * (σ + c * sinσ * (cos2σm + c * cosσ * (-1 + 2 * (cos2σm * cos2σm))));
        } while (Abs(λ - λtick) > 1e-12);
        var uSquared = cosSquaredα * (PowOf2(semiMajorAxis) - PowOf2(semiMinorAxis)) / PowOf2(semiMinorAxis);
        var a = 1 + uSquared / 16384 * (4096 + uSquared * (-768 + uSquared * (320 - 175 * uSquared)));
        var b = uSquared / 1024 * ( 256 + uSquared * (-128 + uSquared * (74 - 47 * uSquared)));
        var Δσ = b * sinσ * (cos2σm + b / 4 * (cosσ * (-1 + 2 * (cos2σm * cos2σm)) - b / 6 * cos2σm * (-3 + 4 * (sinα * sinα)) * (-3 + 4 * (cos2σm * cos2σm))));
        var distance = semiMinorAxis * a * (σ-Δσ);
        return converter?.ConvertFromMetres(distance) ?? distance;
    }

    private static double PowOf2(double d) => Pow(d, 2);
}