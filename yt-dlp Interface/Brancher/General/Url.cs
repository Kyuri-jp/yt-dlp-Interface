using yt_dlp_Interface.Libs.Server;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Brancher.General
{
    internal class Url
    {
        internal static string Ask()
        {
            string url;
            while (true)
            {
                url = Console.Ask("Please enter url.");
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute) || !Http.TryAccess(url))
                {
                    Console.ColoredWriteLine("That url can't access.", ConsoleColor.Yellow);
                    continue;
                }
                break;
            }
            return url;
        }
    }
}