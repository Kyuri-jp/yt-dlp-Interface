using yt_dlp_Interface.Commands.OptionSelector.Interface;

namespace yt_dlp_Interface.Commands.OptionSelector.Formatter.Video
{
    internal class Codec : IOptionFormatter
    {
        string IOptionFormatter.Format(Dictionary<string, string> data) => $"-S vcodec:{data[$"{Options.VideoOptions.Codec}"]}";

        Options.GeneratedOptions IOptionFormatter.GetGeneratedOption() => Options.GeneratedOptions.Codec;
    }
}