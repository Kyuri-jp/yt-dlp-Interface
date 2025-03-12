using yt_dlp_Interface.Commands.OptionSelector.Interface;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;
using static yt_dlp_Interface.Commands.OptionSelector.Options;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector.Audio
{
    internal class Format() : IOptionSelector
    {
        Dictionary<string, string> IOptionSelector.Generate() => new()
        {
            {
                GeneratedOptions.Format.ToString(),
                Console.Select("Select format",
                                                [..Enum.GetNames<Yt_dlp.Options.Audio.Formats>()],
                                                selectType:Console.SelectType.Loose)
            }
        };

        OptionModes ISelector.GetOptionMode() => OptionModes.Audio;
    }
}