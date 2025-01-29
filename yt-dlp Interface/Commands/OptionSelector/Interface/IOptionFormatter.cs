namespace yt_dlp_Interface.Commands.OptionSelector.Interface
{
    internal interface IOptionFormatter
    {
        internal string Format(Dictionary<string, string> data);
    }
}