using yt_dlp_Interface.Commands.OptionSelector.Interface;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;
using static yt_dlp_Interface.Commands.OptionSelector.Options;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector.Audio
{
    internal class Metadata : IOptionSelector
    {
        Dictionary<string, string> IOptionSelector.Generate() => new()
        {
            {
                GeneratedOptions.Metadata.ToString(),
                Console.AskYesOrNo("Will you embed metadata?").ToString()
            }
        };

        OptionModes ISelector.GetOptionMode() => OptionModes.Audio;
    }
}