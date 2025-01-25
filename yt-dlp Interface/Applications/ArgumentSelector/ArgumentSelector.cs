using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Brancher;
using yt_dlp_Interface.Brancher.General;
using yt_dlp_Interface.Commands;
using yt_dlp_Interface.Commands.ArgumentSelector;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Libs.Systems;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Applications.ArgumentSelector
{
    internal class Argumentselector : IApplication
    {
        private enum Mode
        {
            Video,
            Audio,
        }

        internal static List<string> Modes => [.. Enum.GetNames<Mode>()];

        private static Mode ArgumentMode = Mode.Video;

        internal static void SetMode(string modeName)
        {
            if (Enum.GetNames<Mode>().Contains(modeName))
                ArgumentMode = Enum.Parse<Mode>(modeName);
        }

        public Dictionary<ICommand, string> Commands => new()
        {
            {new Enter(), "Enter the argument."},
            {new Commands.ArgumentSelector.Mode(),"Set argument mode." }
        };

        void IApplication.Run()
        {
            while (true)
            {
                string command = Console.AskLikeCui("ArgumentSelector");
                if (command == "exit")
                    break;
                if (command.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    ShowHelp<ICommand>.ShowHelps(Commands);
                    continue;
                }
                CommandRunner.RunCommand(command, Commands.ToDictionary());
            }
            YtdlpInterface.YtDlpExecuter.Execute(Url.Ask(), ArgumentMaker.MakeArguments());
        }
    }
}