using yt_dlp_Interface.Brancher.Interfaces;
using yt_dlp_Interface.Libs.Object;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Video.Options
{
    internal class Formats : IOptionSelector
    {
        string IOptionSelector.Ask()
        {
            List<string> values = [];
            var formatNames = Enum<Yt_dlp.Options.Video.Formats>.GetNames();
            var videoQualityNames = Enum<Yt_dlp.Options.VideoQuality>.GetNames();
            var audioQualityNames = Enum<Yt_dlp.Options.AudioQuality>.GetNames();
            while (true)
            {
                string selectedFormat = Console.Ask($"Select any formats. ({string.Join(',', formatNames)})");
                if (formatNames.Any(name => selectedFormat.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                {
                    values.Add(selectedFormat.ToLower().Replace("three", "3"));
                    while (true)
                    {
                        string selectedVideoQuality = Console.Ask($"Select any video quality. ({string.Join(',', videoQualityNames)})");
                        if (videoQualityNames.Any(name => selectedVideoQuality.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                        {
                            values.Add(selectedVideoQuality.ToLower());
                            while (true)
                            {
                                string selectedAudioQuality = Console.Ask($"Select any video quality. ({string.Join(',', audioQualityNames)})");
                                if (audioQualityNames.Any(name => selectedAudioQuality.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                                {
                                    values.Add(selectedAudioQuality.ToLower());
                                    break;
                                }
                                Console.ColoredWriteLine("Selected quality is unexpected.", ConsoleColor.Yellow);
                            }
                            break;
                        }
                        Console.ColoredWriteLine("Selected quality is unexpected.", ConsoleColor.Yellow);
                    }
                    break;
                }
                Console.ColoredWriteLine("Selected format is unexpected.", ConsoleColor.Yellow);
            }

            return string.Join(';', [.. values]);
        }

        Dictionary<string, string> IOptionSelector.Format(string value) => new()
        {
            {ArgumentMaker.Flags.VideoFormat.ToString(),$"{value.Split(';')[1]}[ext={value.Split(';')[0]}]+{value.Split(';')[2]}[ext=m4a]" }
        };
    }
}