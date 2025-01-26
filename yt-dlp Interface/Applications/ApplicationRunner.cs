using System.Globalization;
using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Libs.Utils;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Applications
{
    internal class ApplicationRunner
    {
        private static readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        internal static void RunApplication(string command, Dictionary<IApplication, string> applications)
        {
            var applicationNames = applications.ToList().Select(x => x.Key.GetType().Name.ToLower());

            if (applicationNames.Contains(command.ToLower()))
            {
                IApplication instance = applications.ElementAt(applicationNames.ToList().IndexOf(command.ToLower())).Key;
                if (instance != null)
                {
                    Console.ColoredWriteLine($"Launched application of {instance.GetType().Name}", ConsoleColor.Cyan);
                    instance.Run();
                }
            }
            else
            {
                Console.ColoredWriteLine("Invalid command", ConsoleColor.Red);
            }
        }
    }
}