using yt_dlp_Interface.Commands.OptionSelector.Interface;

namespace yt_dlp_Interface.Commands.OptionSelector.Formatter.Audio
{
    internal class Metadata : IOptionFormatter
    {
        string IOptionFormatter.Format(Dictionary<string, string> data) => $"{Options.AudioOptions.Metadata}";

        Options.GeneratedOptions IOptionFormatter.GetGeneratedOption() => Options.GeneratedOptions.Metadata;
    }
}