using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Libs.Utils;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Applications
{
    internal class ApplicationRunner
    {
        internal static void RunApplication(string command, Dictionary<IApplication, string> applicationsData)
        {
            var stringedApplicationsData = applicationsData.ToDictionary(x => x.Key.GetType().Name, x => x.Value);

            if (stringedApplicationsData.ContainsKey(command.ToUpperFirstLetter()))
            {
                IApplication commandInstance = applicationsData.ElementAt(stringedApplicationsData.Keys.ToList().IndexOf(command.ToUpperFirstLetter())).Key;
                if (commandInstance != null)
                {
                    Console.ColoredWriteLine($"Launched application of {commandInstance.GetType().Name}", ConsoleColor.Cyan);
                    commandInstance.Run();
                }
            }
            else
            {
                Console.ColoredWriteLine("Invalid command", ConsoleColor.Red);
            }
        }
    }
}