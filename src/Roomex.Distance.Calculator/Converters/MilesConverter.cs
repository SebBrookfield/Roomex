namespace Roomex.Distance.Calculator.Converters;

internal class MilesConverter : ILengthConverter
{
    public double ConvertFromMetres(double metres)
    {
        return metres * 0.0006213712;
    }
}