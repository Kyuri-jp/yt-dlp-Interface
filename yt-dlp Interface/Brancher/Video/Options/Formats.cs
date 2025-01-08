using yt_dlp_Interface.Brancher.Interfaces;
using yt_dlp_Interface.Libs.Object;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Video.Options
{
    internal class Formats : IOptionSelector
    {
        string IOptionSelector.Ask()
        {
            var names = Enum<Yt_dlp.Options.Video.Formats>.GetNames();
            while (true)
            {
                string selectedFormat = Libs.Systems.Console.Ask($"Select any formats. ({string.Join(',', names)})");
                if (names.Any(name => selectedFormat.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                    return selectedFormat.ToLower();
                Console.ColoredWriteLine("Selected format is unexpected.", ConsoleColor.Yellow);
            }
        }

        string IOptionSelector.Format(string value) => $"-f bestvideo[ext={value.Replace("three", "3")}]+bestaudio[ext=m4a]";
    }
}