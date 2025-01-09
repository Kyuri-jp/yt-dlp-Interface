namespace yt_dlp_Interface.Libs.Systems
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
                string? read = ReadLine();
                if (allowNull || !string.IsNullOrEmpty(read)) return read ?? string.Empty;
                ColoredWriteLine("Plase enter any value.", ConsoleColor.Yellow);
            }
        }

        internal static bool AskYesOrNo(string message)
        {
            ArgumentNullException.ThrowIfNull(message);
            while (true)
            {
                string input = Ask($"{message} (y/n)");
                if (input == "y")
                    return true;
                if (input == "n")
                    return false;
                ColoredWriteLine("Please enter yes(y) or no(n)", ConsoleColor.Yellow);
            }
        }

        internal static string Select(string message, List<string> list, bool showList = true)
        {
            ArgumentNullException.ThrowIfNull(message);
            while (true)
            {
                if (showList)
                    foreach (var item in list)
                        ColoredWriteLine(item, ConsoleColor.Cyan);
                string input = Ask(message);
                if (list.Contains(input))
                    return input;
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
                    string input = Ask(message);
                    if (dict.ContainsKey(input))
                        return input;
                    ColoredWriteLine("Please enter correct value.\n", ConsoleColor.Yellow);
                }
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