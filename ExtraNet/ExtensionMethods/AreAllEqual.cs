namespace AnteaterStudios.ExtraNet;
public static partial class ExtensionMethods
{
    /// <summary>
    /// Determines if all elements in <paramref name="source" /> are equal.
    /// If all elements in <paramref name="source" /> are equal or it is an empty collection, <c>true</c> is returned. 
    /// Otherwise, <c>false</c> is returned.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">The <c>IEnumerable<T></c> to check for equality of all elements.</param>
    /// <returns><c>true</c> if all elements in <paramref name="source" /> are equal; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> is <c>null</c>.</exception>
    public static bool AreAllEqual<TSource>(this IEnumerable<TSource> source)
    {
        return source.Distinct().Count() <= 1;
    }
}