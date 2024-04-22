using System;

namespace darts_program;

internal class Player
{
  public Turn GetTurn(int currentScore)
  {
    Score thrownScore;
    int dartsInThrow = 0;

    Turn turn = new Turn(currentScore);

    for (int i = 0; i < 3; i++)
    {
      dartsInThrow++;

      thrownScore = ThrowDart(currentScore, i);

      currentScore -= thrownScore;

      turn.AddScore(thrownScore);

      if (turn.TurnStatus != Turn.Status.INCOMPLETE) break;
    }

    return turn;
  }

  protected virtual Score ThrowDart(int currentScore, int dartIndex)
  {
    throw new NotImplementedException();
  }
}
