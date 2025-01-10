using System.Diagnostics;
using yt_dlp_Interface.Brancher;
using yt_dlp_Interface.Brancher.General;
using yt_dlp_Interface.Libs.Client;
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
            List<string> argument = [];
            if (Console.AskYesOrNo("Do you use any presets?"))
            {
                if (!File.Exists(settingFile))
                {
                    Console.ColoredWriteLine("Setting File is not exists.\nPlase make any presets.\nHow to : *Do you use any presets?*->n *Do you make new preset or modify any preset?*->y", ConsoleColor.Red);
                    continue;
                }

                argument = presetInterface.Setting[Console.Select("Select any preset.", presetInterface.Setting
                                                                                            .ToDictionary(pair => pair.Key,
                                                                                                          pair => string.Join(" ", pair.Value)))];
            }
            else
            {
                if (Console.AskYesOrNo("Do you make new preset or modify any preset?"))
                {
                    PresetMaker.Make();
                    Console.ColoredWriteLine("Created or Modified the preset.\n", ConsoleColor.Magenta);
                    continue;
                }
                argument = ArgumentMaker.MakeArguments();
            }
            executer.Execute(Url.Ask(), argument);
            Console.ColoredWriteLine("Done!\n", ConsoleColor.Magenta);
            Process.Start("explorer.exe", Path.Combine(Directory.GetCurrentDirectory(), "Output"));
        }
    }
}