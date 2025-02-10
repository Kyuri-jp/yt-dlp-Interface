using yt_dlp_Interface.Commands.OptionSelector.Interface;

namespace yt_dlp_Interface.Commands.OptionSelector.Formatter.Audio
{
    internal class Format : IOptionFormatter
    {
        string IOptionFormatter.Format(Dictionary<string, string> data) => $"--audio-format {data[$"{Options.AudioOptions.Format}"]}";

        Options.GeneratedOptions IOptionFormatter.GetGeneratedOption() => Options.GeneratedOptions.Format;
    }
}