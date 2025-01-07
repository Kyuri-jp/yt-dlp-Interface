namespace yt_dlp_Interface.Libs.Object
{
    internal class Enum<T>
    {
        internal static List<string> GetNames() => Enum.GetValues(typeof(T))
                                            .Cast<T>()
                                            .Select(static value => Enum.GetName(typeof(T), value!)!)
                                            .ToList();
    }
}