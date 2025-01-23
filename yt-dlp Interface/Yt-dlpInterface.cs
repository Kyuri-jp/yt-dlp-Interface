using yt_dlp_Interface.Applications;
using yt_dlp_Interface.Applications.ArgumentSelector;
using yt_dlp_Interface.Applications.Interfaces;
using yt_dlp_Interface.Applications.Preset;
using yt_dlp_Interface.Yt_dlp;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface;

internal class YtdlpInterface
{
    private static Executer? executer = null;

    internal static Executer YtDlpExecuter => executer == null ? throw new ArgumentNullException() : executer!;

    private static readonly Dictionary<IApplication, string> Applications = new()
    {
        {new Argumentselector(), "Argument Selector"},
        {new Preset(), "Preset Selector"},
        {new Help(), "Show Applications Help"},
    };

    internal static Dictionary<IApplication, string> ApplicationDatas => Applications;

    private static void Main()
    {
        System.Console.WriteLine("=============================\n" +
            "Welcome to yt-dlp Interface!\n" +
            "Auther : Kyuri\n" +
            "Version : 0.0.1-dev\n" +
            "License : MIT License\n" +
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
            Console.WriteLine("Please enter any key...");
            System.Console.ReadKey();
            Environment.Exit(0);
        }
        executer = new Executer(foundDirectories.First());

        while (true)
        {
            ApplicationRunner.RunApplication(Console.AskLikeCui(), Applications);
        }
    }
}