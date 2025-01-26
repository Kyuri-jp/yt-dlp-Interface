using yt_dlp_Interface.Commands.OptionSelector.Interface;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;
using static yt_dlp_Interface.Commands.OptionSelector.Options;

namespace yt_dlp_Interface.Commands.OptionSelector.Audio
{
    internal class Thumbnail : IOptionSelector
    {
        Dictionary<string, string> IOptionSelector.Generate() => throw new NotImplementedException();

        OptionModes ISelector.GetOptionMode() => OptionModes.Audio;
    }
}