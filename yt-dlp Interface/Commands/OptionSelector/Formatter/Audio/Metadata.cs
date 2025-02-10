using yt_dlp_Interface.Commands.OptionSelector.Interface;

namespace yt_dlp_Interface.Commands.OptionSelector.Formatter.Audio
{
    internal class Metadata : IOptionFormatter
    {
        string IOptionFormatter.Format(Dictionary<string, string> data) => "--embed-metadata";

        Options.GeneratedOptions IOptionFormatter.GetGeneratedOption() => Options.GeneratedOptions.Metadata;
    }
}