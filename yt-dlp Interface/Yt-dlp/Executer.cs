using System.Diagnostics;

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

            Console.WriteLine($"{string.Join(' ', args)} {url}");
            Process.Start(psInfo)!.WaitForExit();
        }
    }
}