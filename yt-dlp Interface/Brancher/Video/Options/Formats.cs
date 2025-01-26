using yt_dlp_Interface.Brancher.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Video.Options
{
    internal class Formats : IOptionSelector
    {
        private static string OptionSelector(string prompt, IEnumerable<string> validOptions)
        {
            while (true)
            {
                string input = Console.Ask(prompt);
                if (validOptions.Any(option => input.Equals(option, StringComparison.CurrentCultureIgnoreCase)))
                    return input.ToLower();
                Console.ColoredWriteLine("Selected option is unexpected.", ConsoleColor.Yellow);
            }
        }

        string IOptionSelector.Ask()
        {
            List<string> values = [];
            var formatNames = Enum.GetNames<Yt_dlp.Options.Video.Formats>();
            var videoQualityNames = Enum.GetNames<Yt_dlp.Options.Quality>();
            var audioQualityNames = Enum.GetNames<Yt_dlp.Options.Quality>();

            string selectedFormat = OptionSelector($"Select any formats. ({string.Join(',', formatNames)})", formatNames);
            values.Add(selectedFormat.Replace("three", "3"));

            string selectedVideoQuality = OptionSelector($"Select any video quality. ({string.Join(',', videoQualityNames)})", videoQualityNames);
            values.Add(selectedVideoQuality);

            string selectedAudioQuality = OptionSelector($"Select any audio quality. ({string.Join(',', audioQualityNames)})", audioQualityNames);
            values.Add(selectedAudioQuality);

            return string.Join(';', [.. values]);
        }

        Dictionary<string, string> IOptionSelector.Format(string value) => new()
        {
            {ArgumentMaker.Flags.VideoFormat.ToString(),$"{value.Split(';')[1]}[ext={value.Split(';')[0]}]+{value.Split(';')[2]}[ext=m4a]" }
        };
    }
}