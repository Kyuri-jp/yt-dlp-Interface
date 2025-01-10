namespace yt_dlp_Interface.Commands.Interfaces
{
    internal interface IApplication
    {
        internal Dictionary<ICommand, string> Commands { get; }

        internal void Run(List<string> arguments);
    }
}