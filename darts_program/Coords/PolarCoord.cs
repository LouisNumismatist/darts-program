using System;

namespace darts_program.Coords;

internal class PolarCoord(double distance, double angle)
{
    public readonly double Distance = distance;
    public readonly double Angle = angle;

    public CartesianCoord ToCartesian()
    {
        double x = Distance * Math.Cos(Angle);
        double y = Distance * Math.Sin(Angle);

        return new CartesianCoord(x, y);
    }
}
