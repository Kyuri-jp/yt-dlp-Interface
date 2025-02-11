using yt_dlp_Interface.Commands.OptionSelector.Formatter.Audio;
using yt_dlp_Interface.Commands.OptionSelector.Formatter.Specific;
using yt_dlp_Interface.Commands.OptionSelector.Formatter.Video;
using yt_dlp_Interface.Commands.OptionSelector.Interface;
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

            Skip,
        }

        private static readonly Dictionary<Enum, IOptionFormatter> optionFormatters = new()
        {
            { AudioOptions.Format, new Formatter.Audio.Format() },
            { AudioOptions.Thumbnail, new Thumbnail() },
            { AudioOptions.Metadata, new Metadata() },

            { VideoOptions.VideoFormat, new Skip() },
            { VideoOptions.AudioFormat, new Skip() },
            { VideoOptions.Codec, new Codec() },
            { VideoOptions.Quality, new Formatter.Video.Format() },
        };

        private static readonly Dictionary<Enum, string> optionsDefault = new()
        {
            {AudioOptions.Format, Yt_dlp.Options.Audio.Formats.mp3.ToString()},

            {VideoOptions.VideoFormat, Yt_dlp.Options.Video.Formats.mp4.ToString()},
            {VideoOptions.AudioFormat, Yt_dlp.Options.Audio.Formats.m4a.ToString()},
            {VideoOptions.Codec, Yt_dlp.Options.Video.Codecs.h264.ToString()},
            {VideoOptions.Quality, Yt_dlp.Options.Quality.best.ToString() }
        };

        internal static Dictionary<AudioOptions, string> AudioOptionsDefault => optionsDefault.Where(x => x.Key is AudioOptions).ToDictionary(x => (AudioOptions)x.Key, x => x.Value);
        internal static Dictionary<VideoOptions, string> VideoOptionsDefault => optionsDefault.Where(x => x.Key is VideoOptions).ToDictionary(x => (VideoOptions)x.Key, x => x.Value);

        private static Dictionary<AudioOptions, IOptionFormatter> AudioFormatters => optionFormatters.Where(x => x.Key is AudioOptions && x.Value.GetGeneratedOption() is not GeneratedOptions.Skip)
                                                                                                     .ToDictionary(x => (AudioOptions)x.Key, x => x.Value);

        private static Dictionary<VideoOptions, IOptionFormatter> VideoFormatters => optionFormatters.Where(x => x.Key is VideoOptions && x.Value.GetGeneratedOption() is not GeneratedOptions.Skip)
                                                                                                     .ToDictionary(x => (VideoOptions)x.Key, x => x.Value);

        internal static Dictionary<GeneratedOptions, string> Parse(OptionModes mode, Dictionary<string, string> data)
        {
            if (mode == OptionModes.Audio)
            {
                return AudioFormatters.Where(x => data.ContainsKey($"{x.Key}"))
                                      .ToDictionary(x => x.Value.GetGeneratedOption(), x => x.Value.Format(data));
            }
            else if (mode == OptionModes.Video)
            {
                return VideoFormatters.Where(x => data.ContainsKey($"{x.Key}"))
                                      .ToDictionary(x => x.Value.GetGeneratedOption(), x => x.Value.Format(data));
            }
            throw new NotImplementedException();
        }
    }
}