namespace darts_program;

internal class Score(Score.Multiplier mult, int value)
{
  public enum Multiplier { NONE, SINGLE, DOUBLE, TRIPLE };

  public readonly Multiplier Mult = mult;
  public readonly int Value = value;

  public int GetScore() => (int)Mult * Value;

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
}
