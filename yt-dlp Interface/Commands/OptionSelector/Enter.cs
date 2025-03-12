using yt_dlp_Interface.Applications.OptionSelector;
using yt_dlp_Interface.Brancher.General;
using yt_dlp_Interface.Commands.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector
{
    internal class Enter : ICommand
    {
        private enum Arguments
        {
            DoNotDownload
        }

        SortedDictionary<string, string> ICommand.Arguments => new()
        {
            {$"{Arguments.DoNotDownload}","It will not download." }
        };

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            OptionData.GetOptions().ToList().ForEach(x => Console.ColoredWriteLine($"{x.Key} : {x.Value}", ConsoleColor.Cyan));
            if (!Console.AskYesOrNo("Do you confirm this options?"))
                return;
            var parsedOption = Options.Parse(Applications.OptionSelector.OptionSelector.GetMode(), OptionData.GetOptions());
            Console.WriteLine("Parsed Options:");
            parsedOption.ToList().ForEach(x => Console.ColoredWriteLine($"{x.Key} : {x.Value}", ConsoleColor.Green));
            if (arguments.ContainsKey($"{Arguments.DoNotDownload.ToString().ToLower()}"))
                Console.ColoredWriteLine("No download option is selected.", ConsoleColor.Yellow);
            else
                YtdlpInterface.YtDlpExecuter.Download(Url.Ask(), [.. parsedOption.Values]);
            Applications.OptionSelector.OptionSelector.entered = true;
        }
    }
}