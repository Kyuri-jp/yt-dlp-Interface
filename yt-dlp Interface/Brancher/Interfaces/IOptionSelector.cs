namespace yt_dlp_Interface.Brancher.Interfaces
{
    internal interface IOptionSelector
    {
        internal string Ask();

        internal string Format(string value);
    }
}