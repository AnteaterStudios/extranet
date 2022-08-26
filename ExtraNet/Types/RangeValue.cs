using System.Globalization;

namespace AnteaterStudios.ExtraNet;
public class ConstrainedValue<T> where T : IComparable<T>
{
    public Range<T> Range { get; }
    public T Value { get; private set; }

    public ConstrainedValue(Range<T> range, T value)
    {
        CheckMinGreaterThanMax(range.Min, range.Max);

        Range = range;
        Value = range.Min;
    }

    public ConstrainedValue(T min, T max, T value)
    {
        CheckMinGreaterThanMax(min, max);

        Value = value.ConstrainToRange(min, max);
        Range = new Range<T>(min, max);
    }

    public void Set(T value)
    {
        Value = value.ConstrainToRange(Range.Min, Range.Max);
    }

    private void CheckMinGreaterThanMax(T min, T max)
    {
        if (min.CompareTo(max) > 0) {
            var minString = Convert.ToString(min, CultureInfo.InvariantCulture);
            var maxString = Convert.ToString(max, CultureInfo.InvariantCulture);
            throw new ArgumentOutOfRangeException(nameof(min), $"The argument {nameof(min)} ({minString}) must not be greater than the argument {nameof(max)} ({maxString}).");
        }
    }
}
