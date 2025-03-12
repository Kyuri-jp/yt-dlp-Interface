using static yt_dlp_Interface.Applications.OptionSelector.OptionSelector;

namespace yt_dlp_Interface.Commands.OptionSelector.Interface
{
    internal interface ISelector
    {
        internal OptionModes GetOptionMode();
    }
}