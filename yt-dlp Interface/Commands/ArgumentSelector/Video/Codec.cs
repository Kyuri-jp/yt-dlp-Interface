using yt_dlp_Interface.Commands.ArgumentSelector.Interface;
using yt_dlp_Interface.Libs.Systems;
using static yt_dlp_Interface.Commands.ArgumentSelector.Options;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.ArgumentSelector.Video
{
    internal class Codec : IArgumentMaker<VideoOptions>, ISelector
    {
        Dictionary<VideoOptions, string> IArgumentMaker<VideoOptions>.Generate() => new() {
            {
                VideoOptions.Codec,
                Console.Select("Select quality",[..Enum.GetNames<Yt_dlp.Options.Video.Codecs>()],selectType:Console.SelectType.Loose)
            }
        };

        ISelector.Mode ISelector.GetMode() => ISelector.Mode.Video;
    }
}