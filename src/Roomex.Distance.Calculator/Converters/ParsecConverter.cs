namespace Roomex.Distance.Calculator.Converters;

internal class ParsecConverter : ILengthConverter
{
    public double ConvertFromMetres(double metres)
    {
        return metres * 3.24078e-17;
    }
}