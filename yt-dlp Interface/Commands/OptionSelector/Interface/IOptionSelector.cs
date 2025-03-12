namespace yt_dlp_Interface.Commands.OptionSelector.Interface
{
    internal interface IOptionSelector : ISelector
    {
        internal Dictionary<string, string> Generate();
    }
}