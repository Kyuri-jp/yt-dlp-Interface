namespace yt_dlp_Interface.Applications.OptionSelector
{
    internal static class OptionData
    {
        private static readonly Dictionary<string, List<string>> Arguments = [];

        internal static void Add(Dictionary<string, List<string>> argument) => argument.ToList()
                                                                                       .ForEach(x => Arguments.Add(x.Key, x.Value));

        internal static void Remove(string key) => Arguments.Remove(key);

        internal static Dictionary<string, List<string>> GetArguments() => Arguments;

        internal static void Clear() => Arguments.Clear();
    }
}