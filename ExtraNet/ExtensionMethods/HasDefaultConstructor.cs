namespace AnteaterStudios.ExtraNet;
public static partial class ExtensionMethods
{
    public static bool HasDefaultConstructor(this Type t)
    {
        return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
    }
}