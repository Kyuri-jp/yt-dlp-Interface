using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yt_dlp_Interface.Commands.Interfaces;

namespace yt_dlp_Interface.Applications.ArgumentSelector
{
    internal class ArgumentSelector : IApplication
    {
        Dictionary<ICommand, string> IApplication.Commands => throw new NotImplementedException();

        void IApplication.Run(List<string> arguments)
        {
            throw new NotImplementedException();
        }
    }
}