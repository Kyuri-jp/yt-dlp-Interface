using yt_dlp_Interface.Brancher.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Preset
{
    internal class Preset : IOptionSelector
    {
        public string Ask() => $"{Console.Ask("Plase enter preset name.")},{string.Join(';', ArgumentMaker.MakeArguments())}";

        public Dictionary<string, string> Format(string value) =>
            new() { { value.Split(',')[0], value.Split(',')[1] } };
    }
}