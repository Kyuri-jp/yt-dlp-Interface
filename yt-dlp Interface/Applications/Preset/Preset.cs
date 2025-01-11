using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Commands;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Libs.Systems;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Applications.Preset
{
    internal class Preset : IApplication
    {
        private static readonly string settingFile = Path.Combine(Directory.GetCurrentDirectory(), "setting.ydis");

        private static readonly Libs.Client.Preset presetInterface = new(settingFile);

        public Dictionary<ICommand, string> Commands => new()
        {
            { new Commands.Preset.Create(presetInterface), "Create new preset" },
            { new Commands.Preset.Load(presetInterface), "Load preset" },
        };

        void IApplication.Run()
        {
            while (true)
            {
                string command = Console.AskLikeCui("Preset");
                if (command == "exit")
                    break;
                if (command.Equals("help", StringComparison.CurrentCultureIgnoreCase))
                {
                    ShowHelp<ICommand>.ShowHelps(Commands);
                    continue;
                }
                CommandRunner.RunCommand(command, Commands);
            }
        }
    }
}