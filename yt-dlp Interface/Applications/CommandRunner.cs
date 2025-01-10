using System.Runtime.InteropServices;
using System.Windows.Input;
using yt_dlp_Interface.Libs.Systems;

namespace yt_dlp_Interface.Applications
{
    internal class CommandRunner
    {
        internal static void RunCommand(string command, Dictionary<ICommand, string> commandsData)
        {
            var stringedCommandsData = commandsData.ToDictionary(x => x.Key.GetType().Name, x => x.Value);
            var parsedCommand = Argument.Parse(command);

            var commandKey = parsedCommand.First().Key;
            if (stringedCommandsData.ContainsKey(commandKey))
            {
                var commandType = Type.GetType(commandKey);
                if (commandType != null && commandsData.TryGetValue((ICommand)Activator.CreateInstance(commandType)!, out var commandInstance))
                    commandInstance.Execute(parsedCommand.Skip(1).ToList());
            }
        }
    }
}