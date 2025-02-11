using yt_dlp_Interface.Applications.OptionSelector;
using yt_dlp_Interface.Commands.Interfaces;
using yt_dlp_Interface.Libs.Systems;
using Console = yt_dlp_Interface.Libs.Systems.Console;

namespace yt_dlp_Interface.Commands.OptionSelector
{
    internal class Custom : ICommand
    {
        private enum Arguments
        {
            Add,
            Get
        }

        SortedDictionary<string, string> ICommand.Arguments => new()
        {
            {$"{Arguments.Add}","Add custom argument" },
            {$"{Arguments.Get}","Get now argument" }
        };

        void ICommand.Execute(Dictionary<string, List<string>> arguments)
        {
            if (arguments.ContainsKey($"{Arguments.Get}"))
            {
                Console.ColoredWriteLine(OptionData.GetOptions().ToList().Find(x => x.Key.Equals("custom", StringComparison.CurrentCultureIgnoreCase)).Value, ConsoleColor.Cyan);
                return;
            }

            if (arguments.ContainsKey($"{Arguments.Add}"))
            {
                OptionData.Add("Custom", OptionData.GetOptions().ToList()
                                       .Find(x => x.Key.Equals("custom", StringComparison.CurrentCultureIgnoreCase)).Value
                                       .Trim() + $" {Console.Ask("Enter custom argument")}");
                return;
            }

            OptionData.Add("Custom", Console.Ask("Enter custom argument"));
        }
    }
}