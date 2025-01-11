using yt_dlp_Interface.Brancher;
using Console = yt_dlp_Interface.Libs.Systems.Console;
using ICommand = yt_dlp_Interface.Commands.Interfaces.ICommand;

namespace yt_dlp_Interface.Commands.Preset
{
    internal class Create(Libs.Client.Preset presetInterface) : ICommand
    {
        Dictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            PresetMaker.Make(presetInterface);
            Console.ColoredWriteLine("Created or Modified the preset.\n", ConsoleColor.Magenta);
        }
    }
}