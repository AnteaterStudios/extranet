namespace AnteaterStudios.ExtraNet;
public static class ExtensionMethods
{
    public static T[] Set<T>(this T[] self, int index, params T[] values)
    {
        Array.Copy(values, 0, self, index, values.Length);
        return self;
    }

    public static bool HasDefaultConstructor(this Type t)
    {
        return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
    }
}
