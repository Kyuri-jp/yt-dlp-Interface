using yt_dlp_Interface.Commands.OptionSelector.Interface;
using static yt_dlp_Interface.Commands.OptionSelector.Options;
using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;

namespace yt_dlp_Interface.Commands.OptionSelector.Audio
{
    internal class Format() : IOptionSelector
    {
        Dictionary<GeneratedOptions, string> IOptionSelector.Generate() => throw new NotImplementedException();

        OptionModes ISelector.GetOptionMode() => OptionModes.Audio;
    }
}