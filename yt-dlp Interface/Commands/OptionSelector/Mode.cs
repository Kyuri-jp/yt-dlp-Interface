using yt_dlp_Interface.Applications.OptionSelector;
using yt_dlp_Interface.Applications.OptionSelector;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Libs.Utils;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector
{
    internal class Mode : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            OptionData.Clear();
            OptionSelector.SetMode(Console.Select("Select argument mode.",
                                                    OptionSelector.Modes,
                                                    selectType: Console.SelectType.Loose).ToUpperFirstLetter());
        }
    }
}