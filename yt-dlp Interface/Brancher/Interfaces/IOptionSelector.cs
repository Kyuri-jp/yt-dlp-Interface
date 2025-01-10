namespace yt_dlp_Interface.Brancher.Interfaces
{
    internal interface IOptionSelector
    {
        internal string Ask();

        internal Dictionary<string, string> Format(string value);
    }
}