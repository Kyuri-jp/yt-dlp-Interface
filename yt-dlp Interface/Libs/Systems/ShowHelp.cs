using yt_dlp_Interface.Commands.Interfaces;

namespace yt_dlp_Interface.Libs.Systems
{
    internal class ShowHelp<TInterface> where TInterface : notnull
    {
        internal static void ShowHelps(Dictionary<TInterface, string> datas) =>
            datas.ToList().ForEach(data => Console.ColoredWriteLine($"{data.Key.GetType().Name} : {data.Value}", ConsoleColor.Green));

        internal static void ShowCommandHelps(Dictionary<ICommand, string> datas, string command)
        {
            if (datas.Keys.Select(x => x.GetType().Name).Contains(command))
                datas.ToList().Find(x => x.Key.GetType().Name == command).Key.Arguments.ToList()
                     .ForEach(x => Console.ColoredWriteLine($"{x.Key} : {x.Value}", ConsoleColor.Green))
            else
                Console.ColoredWriteLine("Invalid command", ConsoleColor.Red);
        }
    }
}