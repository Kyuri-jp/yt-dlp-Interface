namespace yt_dlp_Interface.Commands.OptionSelector.Interface
{
    internal interface IOptionSelector : ISelector
    {
        internal Dictionary<Options.GeneratedOptions, string> Generate();
    }
}