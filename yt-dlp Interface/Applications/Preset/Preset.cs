using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Applications.OptionSelector;
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
            { new Commands.Preset.Get(presetInterface), "Get preset" },
        };

        void IApplication.Run()
        {
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