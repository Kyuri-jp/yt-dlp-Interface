﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_dlp_Interface.Libs.Systems
{
    internal class Argument
    {
        internal static Dictionary<string, List<string>> Parse(string str, string argsPause = "--", char valueMark = '=', char valueBegin = '[', char valueClose = ']')
        {
            ArgumentNullException.ThrowIfNull(str);

            //adv trim
            str = str.Trim();

            Dictionary<string, List<string>> result = [];

            while (true)
            {
                if (str.Length <= 0)
                    break;

                string targetedArg = str;
                if (str.Contains(argsPause))
                    targetedArg = str[..str.IndexOf(argsPause, StringComparison.Ordinal)];

                if (targetedArg.Contains(valueMark))
                {
                    if (!targetedArg.Contains(valueBegin) || !targetedArg.Contains(valueClose))
                        throw new ArgumentException("Args didn't contain value beginer and closer ");
                    result.Add(targetedArg[..targetedArg.IndexOf(valueMark)].Replace(" ", ""), [.. targetedArg[(targetedArg.IndexOf(valueBegin) + 1)..targetedArg.IndexOf(valueClose)].Split(',')]);
                }
                else
                {
                    result.Add(targetedArg.Replace(" ", ""), []);
                }
                if (!str.Contains(argsPause))
                    break;

                str = str.Remove(0, str.IndexOf(argsPause, StringComparison.Ordinal) + argsPause.Length);
            }

            return result;
        }
    }
}