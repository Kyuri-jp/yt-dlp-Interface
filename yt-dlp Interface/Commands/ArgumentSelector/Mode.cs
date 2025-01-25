using yt_dlp_Interface.Applications.ArgumentSelector;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Libs.Utils;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.ArgumentSelector
{
    internal class Mode : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            ArgumentData.Clear();
            Argumentselector.SetMode(Console.Select("Select argument mode.",
                                                    Argumentselector.Modes,
                                                    selectType: Console.SelectType.Loose).ToUpperFirstLetter());
        }
    }
}