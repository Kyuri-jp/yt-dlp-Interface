using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Libs.Systems;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.Preset
{
    internal class Get(Libs.Client.Preset presetInterface) : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            presetInterface.Setting.ToList().ForEach(pair => Console.ColoredWriteLine($"{pair.Key} : {string.Join(" ", pair.Value)}", ConsoleColor.Cyan));
        }
    }
}