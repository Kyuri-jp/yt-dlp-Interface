using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using yt_dlp_Interface.Libs.Systems;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher
{
    internal class PresetMaker
    {
        private static readonly string settingFile = Path.Combine(Directory.GetCurrentDirectory(), "setting.ydis");
        private static readonly Libs.Client.Preset presetInterface = new(settingFile);
        private static readonly Preset.Preset preset = new();

        internal static void Make()
        {
            if (!File.Exists(settingFile))
                File.Create(settingFile);
            var presetInfo = preset.Format(preset.Ask());
            if (presetInterface.Setting.Any(presetName => presetInterface.Setting.ContainsKey(presetInfo.Keys.ElementAt(0))))
                if (!Console.AskYesOrNo("This preset name is already exists.\nCan you execuse override the preset?"))
                    return;
            presetInterface.Add(presetInfo.ElementAt(0));
        }
    }
}