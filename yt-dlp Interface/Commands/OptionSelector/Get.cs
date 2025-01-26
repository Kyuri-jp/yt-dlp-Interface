using yt_dlp_Interface.Applications.OptionSelector;
using yt_dlp_Interface.Commands.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector
{
    internal class Get : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            OptionData.GetArguments().ToList()
                                     .ForEach(x => Console.ColoredWriteLine($"{x.Key} : {string.Join(',', x.Value)}", ConsoleColor.Cyan));
        }
    }
}