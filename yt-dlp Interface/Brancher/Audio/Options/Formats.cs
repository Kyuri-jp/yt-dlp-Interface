using yt_dlp_Interface.Brancher.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Audio.Options
{
    internal class Formats : IOptionSelector
    {
        string IOptionSelector.Ask()
        {
            var names = Enum.GetNames<Yt_dlp.Options.Audio.Formats>();
            while (true)
            {
                string selectedFormat = Console.Ask($"Select any formats. ({string.Join(',', names)})");
                if (names.Any(name => selectedFormat.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                    return selectedFormat.ToLower();
                Console.ColoredWriteLine("Selected format is unexpected.", ConsoleColor.Yellow);
            }
        }

        Dictionary<string, string> IOptionSelector.Format(string value) => new()
        {
            {ArgumentMaker.Flags.AudioFormat.ToString(),value }
        };
    }
}