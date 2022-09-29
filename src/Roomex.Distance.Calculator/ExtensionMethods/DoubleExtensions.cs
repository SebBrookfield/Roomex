namespace Roomex.Distance.Calculator.ExtensionMethods;

internal static class DoubleExtensions
{
    internal static double ToRadians(this double degrees) => degrees * (Math.PI / 180);
}