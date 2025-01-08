using yt_dlp_Interface.Brancher.Interfaces;
using yt_dlp_Interface.Libs.Object;
using yt_dlp_Interface.Libs.Systems;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Audio.Options
{
    internal class Formats : IOptionSelector
    {
        string IOptionSelector.Ask()
        {
            var names = Enum<Yt_dlp.Options.Audio.Formats>.GetNames();
            while (true)
            {
                string selectedFormat = Libs.Systems.Console.Ask($"Select any formats. ({string.Join(',', names)})");
                if (names.Any(name => selectedFormat.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                    return selectedFormat.ToLower();
                Console.ColoredWriteLine("Selected format is unexpected.", ConsoleColor.Yellow);
            }
        }

        string IOptionSelector.Format(string value) => $"--audio-format {value}";
    }
}