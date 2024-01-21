using darts_program.Coords;
using System;
using System.Runtime;

namespace darts_program;

internal class Program
{
  static Dartbot dartbot;

  const int throws = 50;
  const int increments = 5;

  static readonly Score target = new Score(Score.Multiplier.T, 20);
  static void Main(string[] args)
  {
    double score;
    CartesianCoord offset;

    CartesianCoord tripleTwenty = Dartboard.GetCoordinate(target);

    for (int i = increments; i <= 500; i += increments)
    {
      score = 0;
      dartbot = new Dartbot(i);

      for (int j = 0; j < throws * 3; j++)
      {
        offset = dartbot.GetOffset();
        offset.AddCoord(tripleTwenty);
        score += Dartboard.GetScore(offset).GetScore();
      }

      Console.WriteLine($"Accuracy: {i}, Average: {score / throws}");
    }
  }
}
