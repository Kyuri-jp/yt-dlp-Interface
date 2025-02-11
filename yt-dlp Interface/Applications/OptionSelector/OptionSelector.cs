using yt_dlp_Interface.Applications.Interfaces;
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
            OptionData.SetDefault(GetMode());
        }

        internal static OptionModes GetMode() => ArgumentMode;

        public Dictionary<ICommand, string> Commands => new()
        {
            {new Enter(), "Enter the argument."},
            {new Mode(),"Set argument mode." },
            {new Make(),"Make argument" },
            {new Get(),"Get argument" },
            {new Custom(),"Set custom argument"   }
        };

        void IApplication.Run()
        {
            OptionData.SetDefault(GetMode());
            while (true)
            {
                var command = Argument.Parse(Console.AskLikeCui("OptionSelector"));
                if (command.First().Key == "exit")
                    break;
                if (command.First().Key.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    ShowHelp<ICommand>.ShowHelps(Commands, command);
                    continue;
                }
                CommandRunner.RunCommand(command.First().Key, Commands.ToDictionary());
            }
        }
    }
}