namespace Roomex.Distance.Calculator.Converters;

public interface ILengthConverter : IMetreConverter
{
}

public interface IMetreConverter
{
    double ConvertFromMetres(double metres);
}