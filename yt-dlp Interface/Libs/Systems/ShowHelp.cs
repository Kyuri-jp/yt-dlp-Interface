namespace yt_dlp_Interface.Libs.Systems
{
    internal class ShowHelp<TInterface> where TInterface : notnull
    {
        internal static void ShowHelps(Dictionary<TInterface, string> datas) =>
            datas.ToList().ForEach(data => Console.ColoredWriteLine($"{data.Key.GetType().Name} : {data.Value}", ConsoleColor.Green));
    }
}