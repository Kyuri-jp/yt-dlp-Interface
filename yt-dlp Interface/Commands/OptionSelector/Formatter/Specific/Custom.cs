using yt_dlp_Interface.Commands.OptionSelector.Interface;

namespace yt_dlp_Interface.Commands.OptionSelector.Formatter.Specific
{
    internal class Custom : IOptionFormatter
    {
        string IOptionFormatter.Format(Dictionary<string, string> data) => data["Custom"];

        Options.GeneratedOptions IOptionFormatter.GetGeneratedOption() => Options.GeneratedOptions.Custom;
    }
}