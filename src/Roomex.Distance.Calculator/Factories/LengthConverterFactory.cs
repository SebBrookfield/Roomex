using Roomex.Distance.Calculator.Converters;
using Roomex.Distance.Calculator.Enums;

namespace Roomex.Distance.Calculator.Factories;

public interface ILengthConverterFactory
{
    IMetreConverter GetMetreConverter(Lengths length);
}

public class LengthConverterFactory : ILengthConverterFactory
{
    public IMetreConverter GetMetreConverter(Lengths length)
    {
        return length switch
        {
            Lengths.Kilometres => new KilometreConverter(),
            Lengths.Miles => new MilesConverter(),
            Lengths.Parsecs => new ParsecConverter(),
            _ => throw new ArgumentOutOfRangeException(nameof(length), length, null)
        };
    }
}