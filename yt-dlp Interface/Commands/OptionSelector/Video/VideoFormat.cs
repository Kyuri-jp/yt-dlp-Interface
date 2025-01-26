using yt_dlp_Interface.Commands.OptionSelector.Interface;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;
using static yt_dlp_Interface.Commands.OptionSelector.Options;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector.Video
{
    internal class VideoFormat() : IOptionSelector
    {
        Dictionary<string, string> IOptionSelector.Generate() => new()
        {
            {
                VideoOptions.VideoFormat.ToString(),
                Console.Select("Select format",
                                                [..Enum.GetNames<Yt_dlp.Options.Video.Formats>()],
                                                selectType:Console.SelectType.Loose)
            }
        };

        OptionModes ISelector.GetOptionMode() => OptionModes.Video;
    }
}