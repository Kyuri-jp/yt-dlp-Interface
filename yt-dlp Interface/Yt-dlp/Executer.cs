using System.Diagnostics;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Yt_dlp
{
    internal class Executer(string bin)
    {
        internal void Execute(string url, List<string> args)
        {
            ProcessStartInfo psInfo = new()
            {
                FileName = Path.Combine(bin, "yt-dlp.exe"),
                Arguments = $"--output %(title)s.%(ext)s {string.Join(' ', args)} {url}",
                WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output"),
            };

            Console.ColoredWriteLine($"Created Argument => {string.Join(' ', args)} {url}", ConsoleColor.Green);
            try
            {
                Process.Start(psInfo)!.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.ColoredWriteLine($"{ex}\n{ex.StackTrace}", ConsoleColor.Red);
            }
        }
    }
}