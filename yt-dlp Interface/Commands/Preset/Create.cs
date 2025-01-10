using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using yt_dlp_Interface.Commands.Interfaces;
using ICommand = yt_dlp_Interface.Commands.Interfaces.ICommand;

namespace yt_dlp_Interface.Commands.Preset
{
    internal class Create : ICommand
    {
        Dictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(List<string> arguments)
        {
            throw new NotImplementedException();
        }
    }
}