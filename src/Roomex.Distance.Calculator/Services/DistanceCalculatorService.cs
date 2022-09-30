using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Factories;
using Roomex.Distance.Calculator.Models;

namespace Roomex.Distance.Calculator.Services;

public interface IDistanceCalculatorService
{
    /// <summary>
    /// Calculates the distance between two points using the specified calculation method, and returns the distance in metres unless specified.
    /// </summary>
    double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB,
        DistanceCalculators calculationMethod, Lengths? unitOutput = null);
}

public class DistanceCalculatorService : IDistanceCalculatorService
{
    private readonly IDistanceCalculatorFactory _distanceCalculatorFactory;
    private readonly ILengthConverterFactory _lengthConverterFactory;

    public DistanceCalculatorService(IDistanceCalculatorFactory distanceCalculatorFactory, ILengthConverterFactory lengthConverterFactory)
    {
        _distanceCalculatorFactory = distanceCalculatorFactory;
        _lengthConverterFactory = lengthConverterFactory;
    }

    public double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB,
        DistanceCalculators calculationMethod, Lengths? unitOutput = null)
    {
        var lengthConverter = unitOutput == null
            ? null 
            : _lengthConverterFactory.GetMetreConverter(unitOutput.Value);

        return _distanceCalculatorFactory
            .GetDistanceCalculator(calculationMethod)
            .CalculateDistance(coordinateA, coordinateB, lengthConverter);
    }
}