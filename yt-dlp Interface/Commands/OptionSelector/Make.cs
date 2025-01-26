using yt_dlp_Interface.Applications.OptionSelector;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Commands.OptionSelector.Interface;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;
using static yt_dlp_Interface.Commands.OptionSelector.Options;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector
{
    internal class Make : ICommand
    {
        private static Dictionary<Enum, IOptionSelector> OptionPairs => new()
        {
            //Audio
            {AudioOptions.Format, new Audio.Format()},
            {AudioOptions.Thumbnail, new Audio.Thumbnail()},
            {AudioOptions.Metadata, new Audio.Metadata()},

            //Video
            {VideoOptions.VideoFormat, new Video.VideoFormat()},
            {VideoOptions.AudioFormat, new Video.AudioFormat()},
            {VideoOptions.Codec, new Video.Codec()},
            {VideoOptions.Quality, new Video.Quality()},
        };

        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            var enableOptions = OptionPairs.Where(x => x.Value.GetOptionMode() == GetMode()).ToDictionary(x => x.Key,
                                                                                                          x => x.Value);
            while (true)
            {
                string command = Console.AskLikeCui("OptionSelector/Make");
                if (command == "exit")
                    break;
                if (command.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    enableOptions.ToList().ForEach(x => Console.ColoredWriteLine(x.Key.ToString(), ConsoleColor.Cyan));
                    continue;
                }
                if (GetMode() == OptionModes.Video
                    ? Libs.Object.Enum.Contains<VideoOptions>(command, true)
                    : Libs.Object.Enum.Contains<AudioOptions>(command, true))
                {
                    var option = enableOptions.First(x => x.Key.ToString().Equals(command, StringComparison.CurrentCultureIgnoreCase));
                    var result = option.Value.Generate();
                    result.ToList().ForEach(x => OptionData.Add(x.Key, x.Value));
                    result.ToList().ForEach(x => Console.ColoredWriteLine($"{x.Key} : {x.Value}", ConsoleColor.Cyan));
                    continue;
                }
                Console.ColoredWriteLine("Invalid command", ConsoleColor.Red);
            }
        }
    }
}