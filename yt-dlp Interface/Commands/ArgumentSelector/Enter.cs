using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yt_dlp_Interface.Commands.Interfaces;

namespace yt_dlp_Interface.Commands.ArgumentSelector
{
    internal class Enter : ICommand
    {
        SortedDictionary<string, string> ICommand.Arguments => throw new NotImplementedException();

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            throw new NotImplementedException();
        }
    }
}