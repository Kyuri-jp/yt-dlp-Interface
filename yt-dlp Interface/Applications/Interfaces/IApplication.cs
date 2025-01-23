using yt_dlp_Interface.Commands.Interfaces;

namespace yt_dlp_Interface.Applications.Interfaces
{
    internal interface IApplication
    {
        internal SortedDictionary<ICommand, string> Commands { get; }

        internal void Run();
    }
}