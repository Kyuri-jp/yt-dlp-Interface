using yt_dlp_Interface.Brancher.Audio.Options;
using yt_dlp_Interface.Brancher.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher
{
    internal class ArgumentMaker
    {
        private static readonly List<IOptionSelector> videoOptions =
        [
            new Video.Options.Formats(),
            new Video.Options.Codecs()
        ];

        private static readonly List<IOptionSelector> audioOptions =
        [
            new Formats(),
            new Metadata(),
            new Thumbnail()
        ];

        internal enum Flags
        {
            ExtractAudioOnly,
            AudioFormat,
            VideoFormat,
            Quality,
            Codec,
            EmbedThumbnail,
            EmbedMetadata,
            NoValue
        }

        private static readonly Dictionary<string, string> argumentTable = new()
        {
            {Flags.ExtractAudioOnly.ToString(),"-x" },
            {Flags.AudioFormat.ToString(),"--audio-format" },
            {Flags.VideoFormat.ToString(),"-f" },
            {Flags.Codec.ToString(),"-S" },
            {Flags.EmbedThumbnail.ToString() ,"--embed-thumbnail"},
            {Flags.EmbedMetadata.ToString() ,"--embed-metadata"},
        };

        internal static Dictionary<string, string> GetArguments()
        {
            var option = Console.AskYesOrNo("Will you extract audio only") ? audioOptions : videoOptions;
            var result = BranchChainer.Chain(option)
                                    .SelectMany(dict => dict)
                                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            if (option == audioOptions)
                result.Add(Flags.ExtractAudioOnly.ToString(), Flags.NoValue.ToString());
            return result;
        }

        internal static List<string> MakeArguments() => GetArguments()
                                                                .Select(pair => pair.Value == Flags.NoValue.ToString()
                                                                ? argumentTable[pair.Key]
                                                                : $"{argumentTable[pair.Key]} {pair.Value}")
                                                                .ToList();
    }
}