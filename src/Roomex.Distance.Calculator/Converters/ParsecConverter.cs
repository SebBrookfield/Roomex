namespace Roomex.Distance.Calculator.Converters;

public class ParsecConverter : ILengthConverter
{
    public double ConvertFromMetres(double metres)
    {
        return metres * 3.24078e-17;
    }
}