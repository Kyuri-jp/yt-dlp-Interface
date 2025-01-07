using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_dlp_Interface.Libs.Console
{
    internal class Input
    {
        internal static string Inputter(string message, bool allowNull = false)
        {
            ArgumentNullException.ThrowIfNull(message);
            while (true)
            {
                System.Console.WriteLine(message);
                string? read = System.Console.ReadLine();
                if (allowNull || !string.IsNullOrEmpty(read)) return read ?? string.Empty;
                System.Console.WriteLine("Plase enter any value.");
            }
        }

        internal static bool YesOrNo(string message)
        {
            ArgumentNullException.ThrowIfNull(message);
            while (true)
            {
                string input = Inputter($"{message} (y/n)");
                if (input == "y")
                    return true;
                if (input == "n")
                    return false;
                System.Console.WriteLine("Please enter yes(y) or no(n)");
            }
        }
    }
}