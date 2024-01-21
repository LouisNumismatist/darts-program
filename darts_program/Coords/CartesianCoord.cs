using System;

namespace darts_program.Coords;

internal class CartesianCoord(double x, double y)
{
  public double X { get; private set; } = x;
  public double Y { get; private set; } = y;

  public PolarCoord ToPolar()
  {
    double distance = Math.Sqrt(X * X + Y * Y);
    double angle = Math.Atan(Y / X);

    return new PolarCoord(distance, angle);
  }

  public void AddCoord(CartesianCoord coord)
  {
    X += coord.X;
    Y += coord.Y;
  }
}
