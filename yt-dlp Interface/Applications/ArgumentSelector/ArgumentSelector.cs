using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Brancher;
using yt_dlp_Interface.Brancher.General;
using yt_dlp_Interface.Commands.Interfaces;

namespace yt_dlp_Interface.Applications.ArgumentSelector
{
    internal class Argumentselector : IApplication
    {
        Dictionary<ICommand, string> IApplication.Commands => throw new NotImplementedException();

        void IApplication.Run() =>
            YtdlpInterface.YtDlpExecuter.Execute(Url.Ask(), ArgumentMaker.MakeArguments());
    }
}