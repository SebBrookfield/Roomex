using Roomex.Distance.Api.Enums;
using Roomex.Distance.Api.Factories;
using Roomex.Distance.Api.Models;

namespace Roomex.Distance.Api.Services;

public interface IDistanceCalculatorService
{
    /// <summary>
    /// Calculates the distance between two points using the specified calculation method, and returns the distance in metres unless specified.
    /// </summary>
    double CalculateDistance(DecimalDegreeCoordinate coordinateA, DecimalDegreeCoordinate coordinateB,
        DistanceCalculators calculationMethod, Lengths? lengthOutput = null);
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
        DistanceCalculators calculationMethod, Lengths? lengthOutput = null)
    {
        var lengthConverter = lengthOutput == null
            ? null 
            : _lengthConverterFactory.GetMetreConverter(lengthOutput.Value);

        return _distanceCalculatorFactory
            .GetDistanceCalculator(calculationMethod)
            .CalculateDistance(coordinateA, coordinateB, lengthConverter);
    }
}