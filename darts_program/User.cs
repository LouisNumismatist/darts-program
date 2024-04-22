using System;

namespace darts_program;

internal class User : Player
{
  protected override Score ThrowDart(int currentScore, int dartIndex)
  {
    string scoreStr;

    while (true)
    {
      Console.Write($"Enter Dart {dartIndex + 1}: ");
      scoreStr = Console.ReadLine();

      try
      {
        return new(scoreStr);
      }
      catch (ArgumentException e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }
}
