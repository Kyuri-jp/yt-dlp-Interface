using System.Diagnostics;
using yt_dlp_Interface.Brancher;
using yt_dlp_Interface.Brancher.General;
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

        List<string> foundDirectories = Environment.GetEnvironmentVariable("Path")!
            .Split(';')
            .Where(item => !string.IsNullOrWhiteSpace(item))
            .Where(item => File.Exists(Path.Combine(item, "yt-dlp.exe")))
            .ToList();

        if (foundDirectories.Count <= 0)
        {
            Console.ColoredWriteLine("yt-dlp.exe was not found.\n" +
                "Please try again atfer download yt-dlp", ConsoleColor.Red);
            Console.WriteLine("Please enter any keys...");
            System.Console.ReadKey();
            Environment.Exit(0);
        }

        Executer executer = new(foundDirectories[0]);

        while (true)
        {
            executer.Execute(Url.Ask(), ArgumentMaker.MakeArguments());
            Console.ColoredWriteLine("Done!\n", ConsoleColor.Magenta);
            Process.Start("explorer.exe", Path.Combine(Directory.GetCurrentDirectory(), "Output"));
        }
    }
}