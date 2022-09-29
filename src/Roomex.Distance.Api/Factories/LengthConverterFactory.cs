using Roomex.Distance.Api.Converters;
using Roomex.Distance.Api.Enums;

namespace Roomex.Distance.Api.Factories;

public interface ILengthConverterFactory
{
    IMetreConverter GetMetreConverter(LengthConverters length);
}

public class LengthConverterFactory : ILengthConverterFactory
{
    public IMetreConverter GetMetreConverter(LengthConverters length)
    {
        return length switch
        {
            LengthConverters.Kilometres => new KilometreConverter(),
            LengthConverters.Miles => new MilesConverter(),
            LengthConverters.Parsecs => new ParsecConverter(),
            _ => throw new ArgumentOutOfRangeException(nameof(length), length, null)
        };
    }
}