using System.Diagnostics;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Yt_dlp
{
    internal class Executer(string bin)
    {
        private void Execute(string line)
        {
            ProcessStartInfo psInfo = new()
            {
                FileName = Path.Combine(bin, "yt-dlp.exe"),
                Arguments = $"{string.Join(' ', line)}",
                WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output"),
            };

            Console.ColoredWriteLine($"Created Argument => {string.Join(' ', line)}", ConsoleColor.Green);
            try
            {
                Process.Start(psInfo)!.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.ColoredWriteLine($"{ex}\n{ex.StackTrace}", ConsoleColor.Red);
            }
            Console.ColoredWriteLine("Done!\n", ConsoleColor.Magenta);
        }

        internal void Download(string url, List<string> args)
        {
            Execute($"--output %(title)s.%(ext)s {string.Join(' ', args)} {url}");
            var process = Process.Start("explorer.exe", Path.Combine(Directory.GetCurrentDirectory(), "Output"));
            if (process == null)
                throw new InvalidOperationException("Failed to start explorer.exe process.");
        }

        internal void ExecuteSelectedArgument(params string[] args) => Execute(string.Join(' ', args));
    }
}