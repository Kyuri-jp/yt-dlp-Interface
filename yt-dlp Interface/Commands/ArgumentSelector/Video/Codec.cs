using yt_dlp_Interface.Commands.ArgumentSelector.Interface;
using static yt_dlp_Interface.Commands.ArgumentSelector.Options;

namespace yt_dlp_Interface.Commands.ArgumentSelector.Video
{
    internal class Codec : IArgumentMaker<VideoOptions>
    {
        Dictionary<VideoOptions, string> IArgumentMaker<VideoOptions>.Generate() => throw new NotImplementedException();
    }
}