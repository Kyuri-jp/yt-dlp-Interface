using yt_dlp_Interface.Commands.Interfaces;

namespace yt_dlp_Interface.Applications.Preset
{
    internal class Preset : IApplication
    {
        private static readonly string settingFile = Path.Combine(Directory.GetCurrentDirectory(), "setting.ydis");

        private static readonly Libs.Client.Preset presetInterface = new(settingFile);

        Dictionary<ICommand, string> IApplication.Commands => new()
        {
            { new Commands.Preset.Create(), "Create new preset" },
            { new Commands.Preset.Load(), "Load preset" },
            { new Commands.Preset.Modify(), "Modify preset" }
        };

        void IApplication.Run(List<string> arguments)
        {
        }
    }
}