using yt_dlp_Interface.Brancher.Interfaces;
using yt_dlp_Interface.Libs.Object;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Video.Options
{
    internal class Codecs : IOptionSelector
    {
        string IOptionSelector.Ask()
        {
            var names = Enum<Yt_dlp.Options.Video.Codecs>.GetNames();
            while (true)
            {
                string selectedFormat = Console.Ask($"Select any codecs. ({string.Join(',', names)})");
                if (names.Any(name => selectedFormat.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                    return selectedFormat.ToLower();
                Console.ColoredWriteLine("Selected codecs is unexpected.", ConsoleColor.Yellow);
            }
        }

        Dictionary<string, string> IOptionSelector.Format(string value) => new()
        {
            {ArgumentMaker.Flags.Codec.ToString(),$"vcodec:{value}" }
        };
    }
}