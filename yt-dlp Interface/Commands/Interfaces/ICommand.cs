﻿namespace yt_dlp_Interface.Commands.Interfaces
{
    internal interface ICommand
    {
        internal Dictionary<string, string> Arguments { get; }

        internal void Execute(Dictionary<string, List<string>> arguments);
    }
}