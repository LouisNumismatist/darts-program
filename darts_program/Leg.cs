using darts_program.Coords;
using System;
using System.Linq;

namespace darts_program;

internal class Leg
{
  #region Variables
  private readonly Player[] Players;
  private readonly int Off;
  private readonly int[] CurrentScores;
  #endregion

  #region Methods
  public Leg(Player[] players, int legLength, int off)
  {
    if (off > players.Length || off < 0) throw new ArgumentException("Off out of range.");

    if (players.Length == 0) throw new ArgumentException("No players in leg.");

    CurrentScores = Enumerable.Repeat(legLength, players.Length).ToArray();
  }

  public int Play()
  {
    Turn turn;

    int currentTurn = Off;

    while (true)
    {
      turn = Players[currentTurn].GetTurn(CurrentScores[currentTurn]);

      if (turn.TurnStatus == Turn.Status.WIN) return currentTurn;

      CurrentScores[currentTurn] -= turn.GetTotal();

      currentTurn = ++currentTurn % Players.Length;
    }
  }
  #endregion
}
