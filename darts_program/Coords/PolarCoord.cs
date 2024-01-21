using System;

namespace darts_program.Coords;

internal class PolarCoord(double distance, double angle)
{
  public readonly double Distance = distance;
  public readonly double Angle = angle;

  public static PolarCoord operator +(PolarCoord a, PolarCoord b)
  {
    return (PolarCoord)((CartesianCoord)a + (CartesianCoord)b);
  }

  public static explicit operator PolarCoord(CartesianCoord cartesian)
  {
    double distance = Math.Sqrt(cartesian.X * cartesian.X + cartesian.Y * cartesian.Y);
    double angle = Math.Atan(cartesian.Y / cartesian.X);

    if (cartesian.X < 0 && cartesian.Y > 0) angle += Math.PI;
    if (cartesian.X > 0 && cartesian.Y < 0) angle += Math.PI;

    if (cartesian.Y < 0) angle += Math.PI;

    return new PolarCoord(distance, angle);
  }
}
