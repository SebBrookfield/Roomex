namespace Roomex.Distance.Api.Converters;

public interface ILengthConverter : IMetreConverter
{
}

public interface IMetreConverter
{
    double ConvertFromMetres(double metres);
}