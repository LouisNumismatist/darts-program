using System;
using System.Linq;

namespace darts_program;

internal class Turn(int currentScore)
{
  public enum Status { INCOMPLETE, NORMAL, BUST, WIN }

  public Status TurnStatus { get; private set; } = Status.INCOMPLETE;
  private readonly int CurrentScore = currentScore;
  public Score[] Scores { get; private set; } = new Score[3];
  public int DartsThrown { get; private set; } = 0;

  public Status AddScore(Score score)
  {
    if (TurnStatus != Status.INCOMPLETE) throw new Exception("Turn is already finished.");

    DartsThrown++;

    if (IsBust(score))
    {
      TurnStatus = Status.BUST;
      DartsThrown = 3;
    }
    else if (IsWin(score))
    {
      TurnStatus = Status.WIN;
    }
    else if (DartsThrown == 3)
    {
      TurnStatus = Status.NORMAL;
    }

    return TurnStatus;
  }

  private bool IsBust(Score score)
  {
    return !IsWin(score) && (CurrentScore - (GetTotal() + score)) < 2;
  }

  private bool IsWin(Score score)
  {
    return score.Mult == Score.Multiplier.DOUBLE && (CurrentScore == GetTotal() + score);
  }

  public int GetTotal()
  {
    int total = 0;

    for (int i = 0; i < 3; i++) total += Scores?[i];

    return total;
  }
}
