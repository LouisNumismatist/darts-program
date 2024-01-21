using System;

namespace darts_program.Coords;

internal class CartesianCoord(double x, double y)
{
    public readonly double X = x;
    public readonly double Y = y;

    public PolarCoord ToPolar()
    {
        double distance = Math.Sqrt(X * X + Y * Y);
        double angle = Math.Atan(Y / X);

        return new PolarCoord(distance, angle);
    }
}
