namespace yt_dlp_Interface.Libs.Systems
{
    internal class ShowHelp<TInterface> where TInterface : notnull
    {
        internal static void ShowHelps(SortedDictionary<TInterface, string> datas)
        {
            foreach (var data in datas)
                Console.ColoredWriteLine($"{data.Key.GetType().Name} : {data.Value}", ConsoleColor.Green);
        }
    }
}