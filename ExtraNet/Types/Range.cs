using System.Globalization;

namespace AnteaterStudios.ExtraNet;
public class Range<T> where T : IComparable<T>
{
    public T Min { get; private set; }
    public T Max { get; private set; }
    public T Value { get; private set; }

    public Range(T min, T max)
    {
        CheckMinGreaterThanMax(min, max);

        Value = min;
        Min = min;
        Max = max;
    }

    public Range(T min, T max, T value)
    {
        CheckMinGreaterThanMax(min, max);

        Value = value.ConstrainToRange(min, max);
        Min = min;
        Max = max;
    }

    public void Set(T value)
    {
        Value = value.ConstrainToRange(Min, Max);
    }

    public bool InRange(T value)
    {
        return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
    }

    public bool InRange(Range<T> value)
    {
        return value.Min.CompareTo(Min) >= 0 && value.Max.CompareTo(Max) <= 0;
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
