namespace Roomex.Distance.Calculator.Models;

public class DecimalDegreeCoordinate
{
    public double Latitude { get; }
    public double Longitude { get; }

    public DecimalDegreeCoordinate(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}