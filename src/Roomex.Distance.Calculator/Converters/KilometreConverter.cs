namespace Roomex.Distance.Calculator.Converters;

internal class KilometreConverter : ILengthConverter
{
    public double ConvertFromMetres(double metres)
    {
        return metres * 0.001;
    }
}