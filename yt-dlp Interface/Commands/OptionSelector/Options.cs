namespace yt_dlp_Interface.Commands.OptionSelector
{
    internal static class Options
    {
        internal enum AudioOptions
        {
            Format,
            Thumbnail,
            Metadata,
        }

        internal enum VideoOptions
        {
            VideoFormat,
            AudioFormat,
            Codec,
            Quality,
        }

        internal enum GeneratedOptions
        {
            Format,
            Codec,
            Quality,
            Thumbnail,
            Metadata,
        }

        internal static readonly Dictionary<AudioOptions, string> audioOptionsTable = new()
        {
            { AudioOptions.Format, "--audio-format {0}" },
            { AudioOptions.Thumbnail, "--embed-thumbnail" },
            { AudioOptions.Metadata, "--embed-metadata" }c
        };

        internal static readonly Dictionary<VideoOptions, string> videoOptionsTable = new()
        {
            { VideoOptions.VideoFormat, "ext={0}" },
            { VideoOptions.AudioFormat, "ext={0}" },
            { VideoOptions.Codec, "-S vcodec:{0}" },
            { VideoOptions.Quality, "-f {0}video[{2}]+{1}audio[{3}]" },
        };

        internal static List<string> Parse<TOptionType>(Dictionary<string, List<string>> data) where TOptionType : Enum
        {
        }
    }
}