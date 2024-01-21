using darts_program.Coords;
using System;

namespace darts_program;

internal class Dartbot(double accuracy) : Player
{
  private readonly double Accuracy = accuracy;

  private readonly Random random = new();

  public PolarCoord GetOffset()
  {
    double angle = random.NextDouble() * 2 * Math.PI;

    double distance = Math.Acos(2 * random.NextDouble() - 1) * Accuracy / Math.PI;

    return new PolarCoord(distance, angle);
  }

  public int PlayLeg()
  {
    int score = 501;

    int tempScore;

    int dartsInThrow;

    int totalDarts = 0;

    PolarCoord singleThrow;

    Score thrownScore;

    Score aimedScore;

    while (score > 0)
    {
      dartsInThrow = 0;
      tempScore = score;

      for (int i = 0; i < 3; i++)
      {
        dartsInThrow++;

        if (tempScore >= 62)
        {
          aimedScore = new Score(Score.Multiplier.T, 20);
        }
        else if (tempScore == 61)
        {
          aimedScore = new Score(Score.Multiplier.S, 1);
        }
        else if (tempScore >= 42)
        {
          aimedScore = new Score(Score.Multiplier.S, tempScore - 40);
        }
        else if (tempScore == 41)
        {
          aimedScore = new Score(Score.Multiplier.S, 1);
        }
        else if (tempScore % 2 == 0)
        {
          aimedScore = new Score(Score.Multiplier.D, tempScore / 2);
        }
        else
        {
          aimedScore = new Score(Score.Multiplier.S, 1);
        }

        singleThrow = Dartboard.GetCoordinate(aimedScore);

        singleThrow += GetOffset();

        thrownScore = Dartboard.GetScore(singleThrow);

        tempScore -= thrownScore.GetScore();

        if (tempScore == 0)
        {
          if (thrownScore.Mult == Score.Multiplier.D)
          {
            break;
          }
          else
          {
            dartsInThrow = 3;
            tempScore = score;
            break;
          }
        }
        else if (tempScore == 1 || tempScore < 0)
        {
          dartsInThrow = 3;
          tempScore = score;
          break;
        }
      }

      score = tempScore;
      totalDarts += dartsInThrow;
    }

    return totalDarts;
  }
}
