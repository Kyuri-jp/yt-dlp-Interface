using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher
{
    internal class PresetMaker()
    {
        private static readonly Preset.Preset preset = new();

        internal static void Make(Libs.Client.Preset presetInterface)
        {
            if (!File.Exists(presetInterface.SettingFile))
                File.Create(presetInterface.SettingFile).Dispose();

            var presetInfo = preset.Format(preset.Ask()).ToDictionary(pair => pair.Key, pair => pair.Value.Split(';').ToList());
            if (presetInterface.Setting.Any(presetName => presetInterface.Setting.ContainsKey(presetInfo.Keys.ElementAt(0))))
                if (!Console.AskYesOrNo("This preset name is already exists.\nCan you execuse override the preset?"))
                    return;
            presetInterface.Add(presetInfo.ElementAt(0));
        }
    }
}