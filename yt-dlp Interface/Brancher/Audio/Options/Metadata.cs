using yt_dlp_Interface.Brancher.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.Audio.Options
{
    internal class Metadata : IOptionSelector
    {
        string IOptionSelector.Ask() => Console.AskYesOrNo("Will you embed metadata?").ToString();

        Dictionary<string, string> IOptionSelector.Format(string value) => bool.Parse(value)
        ? new()
        {
            {ArgumentMaker.Flags.EmbedMetadata.ToString(),ArgumentMaker.Flags.NoValue.ToString() }
        }
        : new();
    }
}