using yt_dlp_Interface.Libs.Systems;
using ICommand = yt_dlp_Interface.Commands.Interfaces.ICommand;

namespace yt_dlp_Interface.Commands.Preset
{
    internal class Help : ICommand
    {
        Dictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> commandsData)
        {
            ShowHelp<ICommand>.ShowHelps(commandsData.ToDictionary(pair => pair.Key, pair => pair.Value));
        }
    }
}