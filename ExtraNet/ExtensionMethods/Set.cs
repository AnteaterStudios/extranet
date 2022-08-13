namespace AnteaterStudios.ExtraNet;
public static partial class ExtensionMethods
{
    public static TSource[] Set<TSource>(this TSource[] self, int index, params TSource[] values)
    {
        Array.Copy(values, 0, self, index, values.Length);
        return self;
    }
}