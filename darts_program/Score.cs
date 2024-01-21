namespace darts_program;

internal class Score(Score.Multiplier mult, int value)
{
  public enum Multiplier { NONE, S, D, T };

  public readonly Multiplier Mult = mult;
  public readonly int Value = value;

  public int GetScore() => (int)Mult * Value;
}
