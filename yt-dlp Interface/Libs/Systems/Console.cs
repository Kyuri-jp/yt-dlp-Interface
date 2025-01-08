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
                WriteLine("Plase enter any value.");
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
                WriteLine("Please enter yes(y) or no(n)");
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