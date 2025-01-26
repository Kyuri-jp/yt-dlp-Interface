using yt_dlp_Interface.Commands.OptionSelector;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;

namespace yt_dlp_Interface.Applications.OptionSelector
{
    internal static class OptionData
    {
        private static readonly Dictionary<string, string> Arguments = [];

        internal static void SetDefault(OptionModes optionMode)
        {
            Arguments.Clear();
            switch (optionMode)
            {
                case OptionModes.Video:
                    Options.VideoOptionsDefault.ToList().ForEach(x => Add(x.Key.ToString(), x.Value));
                    break;

                case OptionModes.Audio:
                    Options.AudioOptionsDefault.ToList().ForEach(x => Add(x.Key.ToString(), x.Value));
                    break;

                default:
                    break;
            }
        }

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