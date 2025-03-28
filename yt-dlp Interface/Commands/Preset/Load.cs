﻿using yt_dlp_Interface.Brancher.General;
using yt_dlp_Interface.Commands.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.Preset
{
    internal class Load(Libs.Client.Preset presetInterface) : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            if (!File.Exists(presetInterface.SettingFile))
            {
                Console.ColoredWriteLine("Setting File is not exists.\nPlase make any presets.", ConsoleColor.Red);
                return;
            }
            YtdlpInterface.YtDlpExecuter.Download(Url.Ask(), presetInterface.Setting[Console.Select("Select any preset.", presetInterface.Setting
                                                                                    .ToDictionary(pair => pair.Key, pair => string.Join(" ", pair.Value)))]);
        }
    }
}