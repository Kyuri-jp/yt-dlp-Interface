using yt_dlp_Interface.Commands.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.Preset
{
    internal class Get(Libs.Client.Preset presetInterface) : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            if (!File.Exists(presetInterface.SettingFile))
            {
                Console.ColoredWriteLine("Setting File is not exists.\nPlase make any presets.", ConsoleColor.Red);
                return;
            }
            presetInterface.Setting.ToList().ForEach(pair => Console.ColoredWriteLine($"{pair.Key} : {string.Join(" ", pair.Value)}", ConsoleColor.Cyan));
        }
    }
}