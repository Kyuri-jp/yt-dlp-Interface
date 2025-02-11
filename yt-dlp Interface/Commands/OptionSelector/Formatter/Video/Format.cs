using yt_dlp_Interface.Commands.OptionSelector.Interface;

namespace yt_dlp_Interface.Commands.OptionSelector.Formatter.Video
{
    internal class Format : IOptionFormatter
    {
        string IOptionFormatter.Format(Dictionary<string, string> data) =>
            $"-f {data[$"{Options.VideoOptions.Quality}"]}video[ext={data[$"{Options.VideoOptions.VideoFormat}"]}]+" +
            $"{data[$"{Options.VideoOptions.Quality}"]}audio[ext={data[$"{Options.VideoOptions.AudioFormat}"]}]";

        Options.GeneratedOptions IOptionFormatter.GetGeneratedOption() => Options.GeneratedOptions.Format;
    }
}