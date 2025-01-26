namespace yt_dlp_Interface.Applications.OptionSelector
{
    internal static class OptionData
    {
        private static readonly Dictionary<string, string> Arguments = [];

        internal static void Add(string key, string value)
        {
            if (!Arguments.TryAdd(key, value))
                Arguments[key] = value;
        }

        internal static void Remove(string key) => Arguments.Remove(key);

        internal static Dictionary<string, string> GetArguments() => Arguments;

        internal static void Clear() => Arguments.Clear();
    }
}