using yt_dlp_Interface.Commands.OptionSelector.Interface;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;
using static yt_dlp_Interface.Commands.OptionSelector.Options;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector.Video
{
    internal class Codec : IOptionSelector, ISelector
    {
        Dictionary<GeneratedOptions, string> IOptionSelector.Generate() => new() {
            {
                GeneratedOptions.Codec,
                Console.Select("Select quality",[..Enum.GetNames<Yt_dlp.Options.Video.Codecs>()],selectType:Console.SelectType.Loose)
            }
        };

        OptionModes ISelector.GetOptionMode() => OptionModes.Video;
    }
}