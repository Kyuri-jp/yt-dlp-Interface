namespace yt_dlp_Interface.Commands.ArgumentSelector
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
            Format,//使わないほうが良い
            VideoFormat,
            AudioFormat,
            Codec,
            Quality,
        }

        internal static readonly Dictionary<AudioOptions, string> audioOptionsTable = new()
        {
            { AudioOptions.Format, "--audio-format {0}" },
            { AudioOptions.Thumbnail, "--embed-thumbnail" },
            { AudioOptions.Metadata, "--embed-metadata" }
        };

        internal static readonly Dictionary<VideoOptions, string> videoOptionsTable = new()
        {
            { VideoOptions.VideoFormat, "{0}" },
            { VideoOptions.AudioFormat, "{0}" },
            { VideoOptions.Codec, "-S vcodec:{0}" },
            { VideoOptions.Quality, "-f {0}video[ext={2}]+{1}audio[ext={3}]" },
        };
    }
}