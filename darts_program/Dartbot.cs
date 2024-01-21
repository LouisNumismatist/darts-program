using darts_program.Coords;
using System;

namespace darts_program;

internal class Dartbot(double accuracy) : Player
{
  private readonly double Accuracy = accuracy;

  private readonly Random random = new();

  public CartesianCoord GetOffset()
  {
    double angle = random.NextDouble() * 2 * Math.PI;

    double distance = Math.Acos(2 * random.NextDouble() - 1) * Accuracy / Math.PI;

    return new PolarCoord(distance, angle).ToCartesian();
  }
}
