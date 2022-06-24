namespace AnteaterStudios.ExtraNet.ExtensionMethods;
public static class ExtensionMethods
{
    public static bool HasDefaultConstructor(this Type t)
    {
        return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
    }
}
