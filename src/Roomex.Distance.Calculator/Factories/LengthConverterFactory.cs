using Roomex.Distance.Api.Converters;
using Roomex.Distance.Api.Enums;

namespace Roomex.Distance.Api.Factories;

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