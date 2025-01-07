using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yt_dlp_Interface.Brancher.Interfaces;
using yt_dlp_Interface.Libs.Console;
using yt_dlp_Interface.Libs.Object;

namespace yt_dlp_Interface.Brancher.Video.Options
{
    internal class Codecs : IOptionSelector
    {
        string IOptionSelector.Ask()
        {
            var names = Enum<Yt_dlp.Options.Video.Codecs>.GetNames();
            while (true)
            {
                string selectedFormat = Input.Inputter($"Select any codecs. ({string.Join(',', names)})");
                if (names.Any(name => selectedFormat.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                    return selectedFormat.ToLower();
                Console.WriteLine("Selected codecs is unexpected.");
            }
        }

        string IOptionSelector.Format(string value) => $"-S vcodec:{value}";
    }
}