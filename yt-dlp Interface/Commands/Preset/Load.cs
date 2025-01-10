using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yt_dlp_Interface.Commands.Interfaces;

namespace yt_dlp_Interface.Commands.Preset
{
    internal class Load : ICommand
    {
        Dictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(List<string> arguments)
        {
            throw new NotImplementedException();
        }
    }
}