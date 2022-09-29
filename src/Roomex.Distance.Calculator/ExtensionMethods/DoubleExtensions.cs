namespace Roomex.Distance.Api.ExtensionMethods;

public static class DoubleExtensions
{
    public static double ToRadians(this double degrees) => degrees * (Math.PI / 180);
}