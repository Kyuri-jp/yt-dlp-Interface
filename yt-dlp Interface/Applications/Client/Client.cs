using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Commands;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Libs.Systems;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Applications.Client
{
    internal class Client : IApplication
    {
        public Dictionary<ICommand, string> Commands => new()
        {
            { new Commands.Client.Update(), "Update yt-dlp" },
            { new Commands.Client.Version(), "Check yt-dlp version" }
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
                CommandRunner.RunCommand(command, Commands.ToDictionary());
            }
        }
    }
}