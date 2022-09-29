namespace Roomex.Distance.Api.Converters;

public class KilometreConverter : ILengthConverter
{
    public double ConvertFromMetres(double metres)
    {
        return metres * 0.001;
    }
}