namespace Roomex.Distance.Calculator.Converters;

public class KilometreConverter : ILengthConverter
{
    public double ConvertFromMetres(double metres)
    {
        return metres * 0.001;
    }
}