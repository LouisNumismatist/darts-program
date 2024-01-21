using System;
using darts_program.Coords;

namespace darts_program;

internal class Dartboard
{
  private enum Segment
  {
    BULL_INNER,
    BULL_OUTER,
    SINGLE_INNER,
    TRIPLE,
    SINGLE_OUTER,
    DOUBLE,
    NO_SCORE
  }

  private static readonly int[] Scores = [20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8, 11, 14, 9, 12, 5];

  private const int NO_SEGMENTS = 20;

  private static readonly double SEGMENT_ANGLE = 2 * Math.PI / NO_SEGMENTS;

  const double INNER_BULL = 6.35;
  const double OUTER_BULL = 16;
  const double DOUBLE_TRIPLE_SIZE = 8;
  const double TRIPLE_RING = 99;
  const double DOUBLE_RING = 162;

  private static readonly Random random = new();

  public static Score GetScore(PolarCoord coord)
  {
    double calc = (coord.Angle + SEGMENT_ANGLE / 2) / SEGMENT_ANGLE;

    if (calc < 0) calc += 2 * Math.PI;

    int number = Scores[(int)calc % 20];

    switch (GetSegment(coord.Distance))
    {
      case Segment.BULL_OUTER:
      case Segment.SINGLE_INNER:
      case Segment.SINGLE_OUTER:
        return new Score(Score.Multiplier.SINGLE, number);
      case Segment.BULL_INNER:
      case Segment.DOUBLE:
        return new Score(Score.Multiplier.DOUBLE, number);
      case Segment.TRIPLE:
        return new Score(Score.Multiplier.TRIPLE, number);
      case Segment.NO_SCORE:
        return new Score(Score.Multiplier.NONE, number);
      default:
        throw new ArgumentException("Not an allowed segment.");
    }
  }

  public static PolarCoord GetCoordinate(Score score)
  {
    double distance;
    double angle;

    if (score.Value == 25)
    {
      if (score.Mult == Score.Multiplier.DOUBLE) return new PolarCoord(0, 0);

      distance = (OUTER_BULL - INNER_BULL) / 2 + INNER_BULL;

      angle = random.NextDouble() * 2 * Math.PI;
    }
    else
    {
      switch (score.Mult)
      {
        case Score.Multiplier.SINGLE:
          distance = DOUBLE_RING / 2 + TRIPLE_RING / 2 + DOUBLE_TRIPLE_SIZE;
          break;
        case Score.Multiplier.TRIPLE:
          distance = TRIPLE_RING;
          break;
        case Score.Multiplier.DOUBLE:
          distance = DOUBLE_RING;
          break;
        default:
          throw new ArgumentException("Not an acceptable score multiplier.");
      }

      distance += DOUBLE_TRIPLE_SIZE / 2;

      angle = Array.IndexOf(Scores, score.Value) * SEGMENT_ANGLE;
    }

    return new PolarCoord(distance, angle);
  }

  private static Segment GetSegment(double distance)
  {
    if (distance < INNER_BULL) return Segment.BULL_INNER;

    if (distance < OUTER_BULL) return Segment.BULL_OUTER;

    if (distance < TRIPLE_RING) return Segment.SINGLE_INNER;

    if (distance < (TRIPLE_RING + DOUBLE_TRIPLE_SIZE)) return Segment.TRIPLE;

    if (distance < DOUBLE_RING) return Segment.SINGLE_OUTER;

    if (distance < (DOUBLE_RING + DOUBLE_TRIPLE_SIZE)) return Segment.DOUBLE;

    return Segment.NO_SCORE;
  }
}
