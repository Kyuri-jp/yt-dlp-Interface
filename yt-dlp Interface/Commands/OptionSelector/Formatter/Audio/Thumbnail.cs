using yt_dlp_Interface.Commands.OptionSelector.Interface;

namespace yt_dlp_Interface.Commands.OptionSelector.Formatter.Audio
{
    internal class Thumbnail : IOptionFormatter
    {
        string IOptionFormatter.Format(Dictionary<string, string> data) => "--embed-thumbnail";

        Options.GeneratedOptions IOptionFormatter.GetGeneratedOption() => Options.GeneratedOptions.Thumbnail;
    }
}