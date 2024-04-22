using darts_program.Coords;
using System;

namespace darts_program;

internal class Dartbot(double accuracy) : Player
{
  #region Variables
  private readonly double Accuracy = accuracy;

  private readonly Random random = new();
  #endregion

  #region Methods
  protected override Score ThrowDart(int currentScore, int dartIndex)
  {
    Score aimedScore;

    if (currentScore >= 62)
    {
      aimedScore = new Score(Score.Multiplier.TRIPLE, 20);
    }
    else if (currentScore == 61)
    {
      aimedScore = new Score(Score.Multiplier.SINGLE, 1);
    }
    else if (currentScore >= 42)
    {
      aimedScore = new Score(Score.Multiplier.SINGLE, currentScore - 40);
    }
    else if (currentScore == 41)
    {
      aimedScore = new Score(Score.Multiplier.SINGLE, 1);
    }
    else if (currentScore % 2 == 0)
    {
      aimedScore = new Score(Score.Multiplier.DOUBLE, currentScore / 2);
    }
    else
    {
      aimedScore = new Score(Score.Multiplier.SINGLE, 1);
    }

    PolarCoord singleThrow = Dartboard.GetCoordinate(aimedScore);

    singleThrow += GetOffset();

    return Dartboard.GetScore(singleThrow);
  }

  public PolarCoord GetOffset()
  {
    double angle = random.NextDouble() * 2 * Math.PI;

    double distance = Math.Acos(2 * random.NextDouble() - 1) * Accuracy / Math.PI;

    return new PolarCoord(distance, angle);
  }
  #endregion
}
