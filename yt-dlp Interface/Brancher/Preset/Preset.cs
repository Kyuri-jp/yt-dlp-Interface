using yt_dlp_Interface.Applications.OptionSelector;
using yt_dlp_Interface.Brancher.Interfaces;
using yt_dlp_Interface.Commands.OptionSelector;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Preset
{
    internal class Preset : IOptionSelector
    {
        public string Ask()
        {
            YtdlpInterface.ApplicationDatas.First(x => x.Key.GetType() == typeof(OptionSelector)).Key.Run(["donotdownload"]);
            return $"{Console.Ask("Plase enter preset name.")},{string.Join(';', Options.Parse(OptionSelector.GetMode(), OptionData.GetOptions()).Values)}";
        }

        public Dictionary<string, string> Format(string value) =>
            new() { { value.Split(',')[0], value.Split(',')[1] } };
    }
}