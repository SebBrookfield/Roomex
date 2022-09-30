using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Models;

namespace Roomex.Distance.Api.Models;

public class CalculateDistanceRequest
{
    public DecimalDegreeCoordinate CoordinateA { get; set; }
    public DecimalDegreeCoordinate CoordinateB { get; set; }
    public DistanceCalculators? CalculationMethod { get; set; }
    public Lengths? UnitOutput { get; set; }
}