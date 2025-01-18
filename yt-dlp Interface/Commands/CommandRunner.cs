using yt_dlp_Interface.Libs.Systems;
using yt_dlp_Interface.Libs.Utils;
using Console = yt_dlp_Interface.Libs.Systems.Console;
using ICommand = yt_dlp_Interface.Commands.Interfaces.ICommand;

namespace yt_dlp_Interface.Commands
{
    internal class CommandRunner
    {
        internal static void RunCommand(string command, Dictionary<ICommand, string> commandsData)
        {
            var stringedCommandsData = commandsData.ToDictionary(x => x.Key.GetType().Name, x => x.Value);
            var parsedCommand = Argument.Parse(command);
            var mainCommand = parsedCommand.First().Key.ToUpperFirstLetter();

            if (stringedCommandsData.ContainsKey(mainCommand))
            {
                ICommand commandInstance = commandsData.ElementAt(stringedCommandsData.Keys.ToList().IndexOf(command.ToUpperFirstLetter())).Key;
                commandInstance?.Execute(parsedCommand.Skip(1).ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                Console.ColoredWriteLine("Invalid command", ConsoleColor.Red);
            }
        }
    }
}