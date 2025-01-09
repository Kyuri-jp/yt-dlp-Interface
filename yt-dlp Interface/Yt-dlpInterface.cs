using System.Diagnostics;
using yt_dlp_Interface.Brancher;
using yt_dlp_Interface.Libs.Server;
using yt_dlp_Interface.Yt_dlp;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface;

internal class YtdlpInterface
{
    private static void Main()
    {
        System.Console.WriteLine("=============================\n" +
            "Welcome to yt-dlp Interface!\n" +
            "Auther : Kyuri\n" +
            "Version : 0.0.1-dev\n" +
            "License : MIT License\n" +
            "Used Libs : System.Configuration.ConfigurationManager(Micorosoft/MIT License)\n" +
            "=============================");

        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Output")))
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Output"));
        string url;
        while (true)
        {
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

            List<string> foundDirectories = Environment.GetEnvironmentVariable("Path")!
                .Split(';')
                .Where(item => !string.IsNullOrWhiteSpace(item))
                .Where(item => File.Exists(Path.Combine(item, "yt-dlp.exe")))
                .ToList();
            if (foundDirectories.Count <= 0)
            {
                Console.ColoredWriteLine("yt-dlp.exe was not found.\n" +
                    "Please try again atfer download yt-dlp", ConsoleColor.Red);
                break;
            }

            Executer executer = new(foundDirectories[0]);
            executer.Execute(url, ArgumentMaker.MakeArguments());
            Console.ColoredWriteLine("Done!\n", ConsoleColor.Magenta);
            Process.Start("explorer.exe", Path.Combine(Directory.GetCurrentDirectory(), "Output"));
        }
    }
}