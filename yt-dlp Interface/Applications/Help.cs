using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Libs.Systems;

namespace yt_dlp_Interface.Applications
{
    internal class Help : IApplication
    {
        SortedDictionary<ICommand, string> IApplication.Commands => throw new NotImplementedException();

        void IApplication.Run() => ShowHelp<IApplication>.ShowHelps(YtdlpInterface.ApplicationDatas);
    }
}