﻿using yt_dlp_Interface.Commands.Interfaces;

namespace yt_dlp_Interface.Commands.Client
{
    internal class Version : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments) =>
            YtdlpInterface.YtDlpExecuter.ExecuteSelectedArgument("--version");
    }
}