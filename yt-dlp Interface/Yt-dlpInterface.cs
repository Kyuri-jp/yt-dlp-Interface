using System.Diagnostics;
using yt_dlp_Interface.Brancher;
using yt_dlp_Interface.Libs.Console;
using yt_dlp_Interface.Libs.Server;
using yt_dlp_Interface.Yt_dlp;

namespace yt_dlp_Interface;

internal class YtdlpInterface
{
    private static void Main()
    {
        Console.WriteLine("=============================\n" +
            "Welcome to yt-dlp Interface!\n" +
            "Auther : Kyuri\n" +
            "Version : 0.0.1-dev\n" +
            "License : MIT License\n" +
            "=============================");

        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Output")))
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Output"));
        string url;
        while (true)
        {
            while (true)
            {
                url = Input.Inputter("Please enter url.");
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute) || !Http.TryAccess(url))
                {
                    Console.WriteLine("That url can't access.");
                    continue;
                }
                break;
            }

            List<string> foundDirectories = Environment.GetEnvironmentVariable("Path")!
                .Split(';')
                .Where(item => !string.IsNullOrWhiteSpace(item))
                .Where(item => File.Exists(Path.Combine(item, "yt-dlp.exe")))
                .ToList();

            Executer executer = new(foundDirectories[0]);
            executer.Execute(url, ArgumentMaker.GetArguments().ToList());
            Process.Start("explorer.exe", Path.Combine(Directory.GetCurrentDirectory(), "Output"));
        }
    }
}