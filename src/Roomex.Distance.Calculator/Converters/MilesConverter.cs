﻿namespace Roomex.Distance.Calculator.Converters;

public class MilesConverter : ILengthConverter
{
    public double ConvertFromMetres(double metres)
    {
        return metres * 0.0006213712;
    }
}