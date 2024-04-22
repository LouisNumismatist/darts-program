using System;

namespace darts_program;

internal class Program
{
  static Dartbot dartbot;

  const int games = 10;
  const int increments = 2;

  static void Main(string[] args)
  {
    foreach (Score score in Score.GetValidScores(60))
    {
      Console.Write($"{score}, ");
    }

    return;

    double totalDarts;

    for (int i = increments; i <= 100; i += increments)
    {
      totalDarts = 0;

      dartbot = new Dartbot(i);

      for (int j = 0; j < games; j++)
      {
        //totalDarts += dartbot.PlayLeg();
      }

      Console.WriteLine($"Accuracy: {i}, Average: {3 * 501 / (totalDarts / games):#.##}");
    }
  }
}
