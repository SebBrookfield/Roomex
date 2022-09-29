using Microsoft.AspNetCore.Mvc;
using Roomex.Distance.Api.Models;
using Roomex.Distance.Calculator.Enums;
using Roomex.Distance.Calculator.Services;

namespace Roomex.Distance.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceCalculatorService _distanceCalculatorService;

        public DistanceController(IDistanceCalculatorService distanceCalculatorService)
        {
            _distanceCalculatorService = distanceCalculatorService;
        }

        [HttpPost(nameof(Calculate))]
        public double Calculate(CalculateDistanceRequest request)
        {
            return _distanceCalculatorService.CalculateDistance(request.CoordinateA, request.CoordinateB,
                request.CalculationMethod ?? DistanceCalculators.SphericalLawOfCosine, request.OutputLength ?? Lengths.Kilometres);
        }
    }
}