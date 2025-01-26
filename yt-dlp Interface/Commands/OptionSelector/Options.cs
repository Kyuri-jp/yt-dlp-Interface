using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;

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
            { AudioOptions.Metadata, "--embed-metadata" }
        };

        internal static readonly Dictionary<VideoOptions, string> videoOptionsTable = new()
        {
            { VideoOptions.VideoFormat, "ext={0}" },
            { VideoOptions.AudioFormat, "ext={0}" },
            { VideoOptions.Codec, "-S vcodec:{0}" },
            { VideoOptions.Quality, "-f {0}video[{2}]+{1}audio[{3}]" },
        };

        private static readonly Dictionary<AudioOptions, string> audioOptionsDefault = new()
        {
            {AudioOptions.Format, Yt_dlp.Options.Audio.Formats.mp3.ToString()}
        };

        private static readonly Dictionary<VideoOptions, string> videoOptionsDefault = new()
        {
            {VideoOptions.VideoFormat, Yt_dlp.Options.Video.Formats.mp4.ToString()},
            {VideoOptions.AudioFormat, Yt_dlp.Options.Audio.Formats.m4a.ToString()},
            {VideoOptions.Codec, Yt_dlp.Options.Video.Codecs.h264.ToString()},
            {VideoOptions.Quality, Yt_dlp.Options.Quality.best.ToString() }
        };

        internal static Dictionary<AudioOptions, string> AudioOptionsDefault => audioOptionsDefault;
        internal static Dictionary<VideoOptions, string> VideoOptionsDefault => videoOptionsDefault;

        internal static Dictionary<GeneratedOptions, string> Parse(OptionModes mode, Dictionary<string, string> data)
        {
            if (mode == OptionModes.Video)
            {
                string GetOptionOrDefault(VideoOptions option)
                {
                    return data.TryGetValue(option.ToString(), out string? value)
                        ? value
                        : videoOptionsDefault[option];
                }
                string quality = GetOptionOrDefault(VideoOptions.Quality);
                string codec = GetOptionOrDefault(VideoOptions.Codec);
                string videoFormat = GetOptionOrDefault(VideoOptions.VideoFormat);
                string audioFormat = GetOptionOrDefault(VideoOptions.AudioFormat);

                videoFormat = string.Format(videoOptionsTable[VideoOptions.VideoFormat], videoFormat);
                audioFormat = string.Format(videoOptionsTable[VideoOptions.AudioFormat], audioFormat);

                return new()
                {
                    { GeneratedOptions.Format, string.Format(videoOptionsTable[VideoOptions.Quality], quality, quality, videoFormat, audioFormat) },
                    { GeneratedOptions.Codec, string.Format(videoOptionsTable[VideoOptions.Codec], codec) }
                };
            }
            else if (mode == OptionModes.Audio)
            {
                string GetOptionOrDefault(AudioOptions option)
                {
                    return data.TryGetValue(option.ToString(), out string? value)
                        ? value
                        : audioOptionsDefault[option];
                }
                string format = GetOptionOrDefault(AudioOptions.Format);
                return new()
                {
                    { GeneratedOptions.Format, string.Format(audioOptionsTable[AudioOptions.Format], format) },
                    { GeneratedOptions.Thumbnail, data.ContainsKey(AudioOptions.Thumbnail.ToString()) ? audioOptionsTable[AudioOptions.Thumbnail] : "" },
                    { GeneratedOptions.Metadata, data.ContainsKey(AudioOptions.Metadata.ToString()) ? audioOptionsTable[AudioOptions.Metadata] : "" }
                };
            }
            throw new NotImplementedException();
        }
    }
}