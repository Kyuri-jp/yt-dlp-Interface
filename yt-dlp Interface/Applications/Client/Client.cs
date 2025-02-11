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