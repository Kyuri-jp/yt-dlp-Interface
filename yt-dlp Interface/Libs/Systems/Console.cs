﻿namespace yt_dlp_Interface.Libs.Systems
{
    internal static class Console
    {
        //Input
        internal static string Ask(string message, bool allowNull = false)
        {
            ArgumentNullException.ThrowIfNull(message);
            while (true)
            {
                WriteLine(message);
                string? read = ReadLine()?.Trim();
                if (allowNull || !string.IsNullOrEmpty(read)) return read ?? string.Empty;
                ColoredWriteLine("Plase enter any value.", ConsoleColor.Yellow);
            }
        }

        internal static bool AskYesOrNo(string message)
        {
            ArgumentNullException.ThrowIfNull(message);
            while (true)
            {
                WriteLine($"{message} (y/n)");
                ConsoleKeyInfo input = System.Console.ReadKey(true);
                if (input.Key == ConsoleKey.Y)
                    return true;
                if (input.Key == ConsoleKey.N)
                    return false;
                ColoredWriteLine("Please enter yes(y) or no(n)", ConsoleColor.Yellow);
            }
        }

        internal enum SelectType
        {
            Strict,
            Loose
        }

        internal static string Select(string message, List<string> list, bool showList = true, SelectType selectType = SelectType.Strict)
        {
            ArgumentNullException.ThrowIfNull(message);
            while (true)
            {
                if (showList)
                    foreach (var item in list)
                        ColoredWriteLine(item, ConsoleColor.Cyan);
                string input = Ask(message).Trim();
                list = selectType == SelectType.Loose ? list.Select(x => x.ToLower()).ToList() : list;
                var result = list.Where(x => x == (selectType == SelectType.Loose ? input.ToLower() : input));
                if (result.Any())
                    return result.First();
                ColoredWriteLine("Please enter correct value.\n", ConsoleColor.Yellow);
            }
        }

        internal static string Select<TValue>(string message, Dictionary<string, TValue> dict, bool showList = true)
        {
            {
                ArgumentNullException.ThrowIfNull(message);
                while (true)
                {
                    if (showList)
                        foreach (var pair in dict)
                            ColoredWriteLine($"{pair.Key} : {pair.Value}", ConsoleColor.Cyan);
                    string input = Ask(message).Trim();
                    if (dict.ContainsKey(input))
                        return input;
                    ColoredWriteLine("Please enter correct value.\n", ConsoleColor.Yellow);
                }
            }
        }

        internal static string AskLikeCui(string Name = "")
        {
            while (true)
            {
                System.Console.Write($"\n{Name}> ");
                string? read = ReadLine()?.Trim();
                if (read != null && read.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                    return "exit";
                if (!string.IsNullOrEmpty(read))
                    return read;
            }
        }

        //Output
        internal static void ColoredWriteLine(string message, ConsoleColor consoleColor)
        {
            ConsoleColor color = System.Console.ForegroundColor;
            System.Console.ForegroundColor = consoleColor;
            WriteLine(message);
            System.Console.ForegroundColor = color;
        }

        //Wrapper
        internal static void WriteLine(string message) => System.Console.WriteLine(message);

        internal static string? ReadLine() => System.Console.ReadLine()?.ToString();
    }
}