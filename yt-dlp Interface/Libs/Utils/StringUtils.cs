﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_dlp_Interface.Libs.Utils
{
    internal static class StringUtils
    {
        internal static string ToUpperFirstLetter(this string value)
        {
            char[] chars = value.ToLower().ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return string.Join("", chars);
        }
    }
}