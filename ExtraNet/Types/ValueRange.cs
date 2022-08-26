namespace AnteaterStudios.ExtraNet;
public abstract class ValueRange<T> where T : IComparable<T>
{
    public abstract Range<T> Range { get; }
    public abstract T Value { get; }

    public abstract T Set(T value);
}