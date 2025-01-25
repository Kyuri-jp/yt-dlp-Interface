namespace yt_dlp_Interface.Commands.ArgumentSelector.Interface
{
    internal interface ISelector
    {
        internal enum Mode
        {
            Audio,
            Video,
            General,
        }

        internal Mode GetMode();
    }
}