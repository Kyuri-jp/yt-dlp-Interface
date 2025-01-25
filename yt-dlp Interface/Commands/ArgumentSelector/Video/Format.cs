using yt_dlp_Interface.Commands.ArgumentSelector.Interface;
using static yt_dlp_Interface.Commands.ArgumentSelector.Options;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.ArgumentSelector.Video
{
    internal class Format() : IArgumentMaker<VideoOptions>, ISelector
    {
        Dictionary<VideoOptions, string> IArgumentMaker<VideoOptions>.Generate() => new()
        {
            {
                VideoOptions.VideoFormat,
                Console.Select("Select format",
                                                [..Enum.GetNames<Yt_dlp.Options.Video.Formats>()],
                                                selectType:Console.SelectType.Loose)
            },
            {
                VideoOptions.AudioFormat,
                "m4a"
            }
        };

        ISelector.Mode ISelector.GetMode() => ISelector.Mode.Video;
    }
}