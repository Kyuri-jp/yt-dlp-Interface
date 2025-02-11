using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Libs.Utils;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector
{
    internal class Mode : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            SetMode(Console.Select("Select argument mode.",
                                                    Modes,
                                                    selectType: Console.SelectType.Loose).ToUpperFirstLetter());
        }
    }
}