using System.Runtime.CompilerServices;
using yt_dlp_Interface.Applications.ArgumentSelector;
using yt_dlp_Interface.Commands.ArgumentSelector.Interface;
using yt_dlp_Interface.Commands.Interfaces;
using static yt_dlp_Interface.Commands.ArgumentSelector.Options;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.ArgumentSelector
{
    internal class Make : ICommand
    {
        private static Dictionary<AudioOptions, IArgumentMaker<AudioOptions>> AudioMode => new()
        {
            {AudioOptions.Format, new Audio.Format()},
            {AudioOptions.Thumbnail, new Audio.Thumbnail()},
            {AudioOptions.Metadata, new Audio.Metadata()},
        };

        private static Dictionary<VideoOptions, IArgumentMaker<VideoOptions>> VideoMode => new()
        {
            {VideoOptions.Format, new Video.Format()},
            {VideoOptions.Codec, new Video.Codec()},
            {VideoOptions.Quality, new Video.Quality()},
        };

        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            while (true)
            {
                string command = Console.AskLikeCui("ArgumentSelector/Make");
                if (command == "exit")
                    break;
                if (command.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    var keys = Argumentselector.GetMode() switch
                    {
                        Argumentselector.Mode.Audio => AudioMode.Keys.Select(x => x.ToString()),
                        Argumentselector.Mode.Video => VideoMode.Keys.Select(x => x.ToString()),
                        _ => throw new NotImplementedException(),
                    };
                    keys.ToList().ForEach(x => Console.ColoredWriteLine(x, ConsoleColor.Cyan));
                    continue;
                }
                switch (Argumentselector.GetMode())
                {
                    case Argumentselector.Mode.Video:
                        {
                            var result = VideoMode[(VideoOptions)Enum.GetNames<VideoOptions>()
                                                                     .ToList()
                                                                     .IndexOf(Console.Select("Select option", [.. Enum.GetNames<VideoOptions>()]))].Generate();
                            result.ToList().ForEach(x => ArgumentData.Add(string.Format(videoOptionsTable[x.Key], x.Value)));
                        }
                        break;

                    case Argumentselector.Mode.Audio:
                        {
                            var result = AudioMode[(AudioOptions)Enum.GetNames<AudioOptions>()
                                                                     .ToList()
                                                                     .IndexOf(Console.Select("Select option", [.. Enum.GetNames<AudioOptions>()]))].Generate();
                            result.ToList().ForEach(x => ArgumentData.Add(string.Format(audioOptionsTable[x.Key], x.Value)));
                        }
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }
    }
}