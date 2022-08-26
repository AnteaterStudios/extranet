using System.Globalization;

namespace AnteaterStudios.ExtraNet;
public class ConstrainedValue<T> : ValueRange<T> where T : IComparable<T>
{
    public override Range<T> Range { get; }
    private T _value;
    public override T Value { get => _value; }

    public ConstrainedValue(Range<T> range, T value)
    {
        CheckMinGreaterThanMax(range.Min, range.Max);

        _value = range.Min;
        Range = range;
    }

    public ConstrainedValue(T min, T max, T value)
    {
        CheckMinGreaterThanMax(min, max);

        _value = value.ConstrainToRange(min, max);
        Range = new Range<T>(min, max);
    }

    public override T Set(T value)
    {
        _value = value.ConstrainToRange(Range.Min, Range.Max);
        return Value;
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
