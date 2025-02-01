using yt_dlp_Interface.Commands.OptionSelector;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;

namespace yt_dlp_Interface.Applications.OptionSelector
{
    internal static class OptionData
    {
        private static readonly Dictionary<string, string> Options = [];

        internal static void SetDefault(OptionModes optionMode)
        {
            Options.Clear();
            switch (optionMode)
            {
                case OptionModes.Video:
                    Commands.OptionSelector.Options.VideoOptionsDefault.ToList().ForEach(x => Add(x.Key.ToString(), x.Value));
                    break;

                case OptionModes.Audio:
                    Commands.OptionSelector.Options.AudioOptionsDefault.ToList().ForEach(x => Add(x.Key.ToString(), x.Value));
                    break;

                default:
                    break;
            }
        }

        internal static void Add(string key, string value)
        {
            if (!Options.TryAdd(key, value))
                Options[key] = value;
        }

        internal static void Remove(string key) => Options.Remove(key);

        internal static Dictionary<string, string> GetOptions() => Options;

        internal static void Clear() => Options.Clear();
    }
}