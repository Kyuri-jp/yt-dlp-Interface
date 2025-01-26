﻿using yt_dlp_Interface.Applications.OptionSelector;
using yt_dlp_Interface.Brancher.General;
using yt_dlp_Interface.Commands.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector
{
    internal class Enter : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            OptionData.GetArguments().ToList().ForEach(x => Console.ColoredWriteLine($"{x.Key} : {x.Value}", ConsoleColor.Cyan));
            if (!Console.AskYesOrNo("Do you confirm this options?"))
                return;
            var parsedOption = Options.Parse(Applications.OptionSelector.OptionSelector.GetMode(), OptionData.GetArguments());
            Console.WriteLine("Parsed Options:");
            parsedOption.ToList().ForEach(x => Console.ColoredWriteLine($"{x.Key} : {x.Value}", ConsoleColor.Cyan));
            YtdlpInterface.YtDlpExecuter.Execute(Url.Ask(), [.. parsedOption.Values]);
        }
    }
}