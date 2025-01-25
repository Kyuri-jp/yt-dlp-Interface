using yt_dlp_Interface.Commands.ArgumentSelector.Interface;
using static yt_dlp_Interface.Commands.ArgumentSelector.Options;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.ArgumentSelector.Video
{
    internal class Quality : IArgumentMaker<VideoOptions>, ISelector
    {
        Dictionary<VideoOptions, string> IArgumentMaker<VideoOptions>.Generate() => new()
        {
            {
                VideoOptions.Format,
                Console.Select("Select quality",[..Enum.GetNames<Yt_dlp.Options.Quality>()],selectType:Console.SelectType.Loose)
            }
        };

        ISelector.Mode ISelector.GetMode() => ISelector.Mode.Video;
    }
}