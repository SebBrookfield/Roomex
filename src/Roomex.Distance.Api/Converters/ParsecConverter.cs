namespace Roomex.Distance.Api.Converters;

public class ParsecConverter : IMetreConverter
{
    public double ConvertFromMetres(double metres)
    {
        return metres * 3.24078e-17;
    }
}