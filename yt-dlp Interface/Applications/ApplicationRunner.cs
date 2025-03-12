using yt_dlp_Interface.Applications.Interfaces;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Applications
{
    internal class ApplicationRunner
    {
        internal static void RunApplication(string command, Dictionary<IApplication, string> applications)
        {
            var applicationNames = applications.ToList().Select(x => x.Key.GetType().Name.ToLower());

            if (applicationNames.Contains(command.ToLower()))
            {
                IApplication instance = applications.ElementAt(applicationNames.ToList().IndexOf(command.ToLower())).Key;
                if (instance != null)
                {
                    Console.ColoredWriteLine($"Launched application of {instance.GetType().Name}", ConsoleColor.Cyan);
                    instance.Run([string.Empty]);
                }
            }
            else
            {
                Console.ColoredWriteLine("Invalid command", ConsoleColor.Red);
            }
        }
    }
}