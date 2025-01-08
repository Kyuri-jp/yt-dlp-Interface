using yt_dlp_Interface.Brancher.Interfaces;
using yt_dlp_Interface.Libs.Systems;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Audio.Options
{
    internal class Metadata : IOptionSelector
    {
        string IOptionSelector.Ask() => Console.AskYesOrNo("Will you embed metadata?").ToString();

        string IOptionSelector.Format(string value) => bool.Parse(value) ? $"--{Yt_dlp.Options.Audio.Data.embed_metadata}".Replace('_', '-') : "";
    }
}