using yt_dlp_Interface.Commands.OptionSelector.Interface;

namespace yt_dlp_Interface.Commands.OptionSelector.Formatter.Specific
{
    internal class Skip : IOptionFormatter
    {
        string IOptionFormatter.Format(Dictionary<string, string> data)
        {
            throw new NotImplementedException();
        }

        Options.GeneratedOptions IOptionFormatter.GetGeneratedOption() => Options.GeneratedOptions.Skip;
    }
}