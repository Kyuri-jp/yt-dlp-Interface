﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yt_dlp_Interface.Commands.OptionSelector.Interface;

namespace yt_dlp_Interface.Commands.OptionSelector.Formatter.Video
{
    internal class Codec : IOptionFormatter
    {
        string IOptionFormatter.Format(Dictionary<string, string> data)
        {
            throw new NotImplementedException();
        }

        Options.GeneratedOptions IOptionFormatter.GetGeneratedOption() => Options.GeneratedOptions.Codec;
    }
}