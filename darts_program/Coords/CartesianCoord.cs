using System;
using System.Reflection.Metadata;

namespace darts_program.Coords;

internal class CartesianCoord(double x, double y)
{
  public double X { get; private set; } = x;
  public double Y { get; private set; } = y;

  public static CartesianCoord operator +(CartesianCoord a, CartesianCoord b)
  {
    return new CartesianCoord(a.X + b.X, a.Y + b.Y);
  }

  public static explicit operator CartesianCoord(PolarCoord polar)
  {
    double x = polar.Distance * Math.Cos(polar.Angle);
    double y = polar.Distance * Math.Sin(polar.Angle);

    return new CartesianCoord(x, y);
  }
}
