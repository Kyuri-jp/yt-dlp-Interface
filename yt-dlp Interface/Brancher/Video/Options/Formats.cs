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
    internal class Formats : IOptionSelector
    {
        string IOptionSelector.Ask()
        {
            var names = Enum<Yt_dlp.Options.Video.Formats>.GetNames();
            while (true)
            {
                string selectedFormat = Input.Inputter($"Select any formats. ({string.Join(',', names)})");
                if (names.Any(name => selectedFormat.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                    return selectedFormat.ToLower();
                Console.WriteLine("Selected format is unexpected.");
            }
        }

        string IOptionSelector.Format(string value) => $"-f bestvideo[ext={value.Replace("three", "3")}]+bestaudio[ext=m4a]";
    }
}