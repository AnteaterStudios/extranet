using System.Globalization;

namespace AnteaterStudios.ExtraNet;
public static class ExtensionMethods
{
    public static T[] Set<T>(this T[] self, int index, params T[] values)
    {
        Array.Copy(values, 0, self, index, values.Length);
        return self;
    }

    /// <summary>
    /// Constraints <paramref name="value" /> to the lower bound <paramref name="min" /> and the upper bound <paramref name="max" />.
    /// If <paramref name="value" /> is less than <paramref name="min" />, <paramref name="min" /> is returned.
    /// If <paramref name="value" /> is greater than <paramref name="max" />, <paramref name="max" /> is returned.
    /// Otherwise, <paramref name="value"/> is returned.
    /// </summary>
    /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
    /// <param name="value">The value to constrain.</param>
    /// <param name="min">The lower bound to constrain <paramref name="value" /> to.</param>
    /// <param name="max">The upper bound to constrain <paramref name="value" /> to.</param>
    /// <returns><paramref name="value" /> constraint to the specified bounds.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="min"/> is greater than <paramref name="max"/>.</exception>
    public static T ConstrainToRange<T>(this T value, T min, T max)
        where T : notnull, IComparable<T>
    {
        if (min.CompareTo(max) > 0)
        {
            var minString = Convert.ToString(min, CultureInfo.InvariantCulture);
            var maxString = Convert.ToString(max, CultureInfo.InvariantCulture);
            throw new ArgumentOutOfRangeException(nameof(min), $"The argument {nameof(min)} ({minString}) must not be greater than the argument {nameof(max)} ({maxString}).");
        }
 
        return value.CompareTo(min) < 0 ? min : value.CompareTo(max) > 0 ? max : value;
    }

    public static bool AreAllEqual<T>(this IEnumerable<T> source)
    {
        return source.Distinct().Count() <= 1;
    }

    public static bool HasDefaultConstructor(this Type t)
    {
        return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
    }
}
