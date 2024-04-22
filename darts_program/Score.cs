using System;
using System.Collections.Generic;

namespace darts_program;

internal class Score
{
  public enum Multiplier { NONE, SINGLE, DOUBLE, TRIPLE };

  public readonly Multiplier Mult;
  public readonly int Value;

  public Score(Multiplier mult, int value)
  {
    Mult = mult;
    Value = value;
  }

  public Score(string scoreStr)
  {
    if (!(scoreStr.Length > 0 && scoreStr.Length <= 3)) throw new ArgumentException("Invalid score.");
    
    switch (scoreStr[0])
    {
      case 'S': Mult = Multiplier.SINGLE; break;
      case 'T': Mult = Multiplier.TRIPLE; break;
      case 'D': Mult = Multiplier.DOUBLE; break;
      default:  Mult = Multiplier.NONE;   break;
    }

    if (Mult != Multiplier.NONE) scoreStr = scoreStr[1..];

    if (!int.TryParse(scoreStr, out int value)) throw new ArgumentException("Invalid score.");

    Value = value;
  }

  public override string ToString()
  {
    string str;

    switch(Mult)
    {
      case Multiplier.SINGLE: str = "S"; break;
      case Multiplier.TRIPLE: str = "T"; break;
      case Multiplier.DOUBLE: str = "D"; break;
      case Multiplier.NONE:
      default:
        str = "-"; break;
    }

    if (Value < 10) str += "0";

    return str += Value;
  }

  public static implicit operator int(Score score)
  {
    return (int)score.Mult * score.Value;
  }

  public static IEnumerable<Score> GetValidScores(int currentScore)
  {
    for (int i = 1; i < 4; i++)
    {
      for (int j = 1; j <= 20; j++)
      {
        if (((i * j) < (currentScore - 1)) || (i == 2 && ((i * j) == (currentScore))))
        {
          yield return new Score((Multiplier)i, j);
        }
        else break;
      }

      if (i < 3 && (i * 25) < (currentScore - 1))
      {
        yield return new Score((Multiplier)i, 25);
      }
    }
  }
}
