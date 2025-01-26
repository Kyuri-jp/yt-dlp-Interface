using yt_dlp_Interface.Commands.OptionSelector.Interface;
using yt_dlp_Interface.Commands.Interfaces;
using static yt_dlp_Interface.Commands.OptionSelector.Options;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;
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
            var enableOptions = OptionPairs.Where(x => x.Value.GetOptionMode() == GetMode());
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
            }
        }
    }
}