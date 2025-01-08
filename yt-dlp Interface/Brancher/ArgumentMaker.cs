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

        internal static IEnumerable<string> GetArguments() => Console.AskYesOrNo("Will you extract audio only") ? BranchChainer.Chain(audioOptions).Prepend("-x") : BranchChainer.Chain(videoOptions);
    }
}