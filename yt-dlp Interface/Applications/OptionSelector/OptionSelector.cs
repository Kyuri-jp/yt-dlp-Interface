using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Brancher.General;
using yt_dlp_Interface.Commands;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Commands.OptionSelector;
using yt_dlp_Interface.Libs.Systems;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Applications.OptionSelector
{
    internal class OptionSelector : IApplication
    {
        internal enum OptionModes
        {
            Video,
            Audio,
        }

        internal static List<string> Modes => [.. Enum.GetNames<OptionModes>()];

        private static OptionModes ArgumentMode = OptionModes.Video;

        internal static void SetMode(string modeName)
        {
            if (Enum.GetNames<OptionModes>().Contains(modeName))
                ArgumentMode = Enum.Parse<OptionModes>(modeName);
        }

        internal static OptionModes GetMode() => ArgumentMode;

        public Dictionary<ICommand, string> Commands => new()
        {
            {new Enter(), "Enter the argument."},
            {new Commands.OptionSelector.Mode(),"Set argument mode." },
            {new Make(),"Make argument" }
        };

        void IApplication.Run()
        {
            while (true)
            {
                string command = Console.AskLikeCui("OptionSelector");
                if (command == "exit")
                    break;
                if (command.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    ShowHelp<ICommand>.ShowHelps(Commands);
                    continue;
                }
                CommandRunner.RunCommand(command, Commands.ToDictionary());
            }
            YtdlpInterface.YtDlpExecuter.Execute(Url.Ask(), Brancher.ArgumentMaker.MakeArguments());
        }
    }
}