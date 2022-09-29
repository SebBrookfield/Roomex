namespace Roomex.Distance.Api.Converters;

public class KilometreConverter : IMetreConverter
{
    public double ConvertFromMetres(double metres)
    {
        return metres * 0.001;
    }
}