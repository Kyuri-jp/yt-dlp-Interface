﻿namespace yt_dlp_Interface.Commands.Interfaces
{
    internal interface ICommand
    {
        internal SortedDictionary<string, string> Arguments { get; }

        internal void Execute(Dictionary<string, List<string>> arguments);
    }
}