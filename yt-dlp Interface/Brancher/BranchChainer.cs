using yt_dlp_Interface.Brancher.Interfaces;

namespace yt_dlp_Interface.Brancher
{
    internal class BranchChainer
    {
        internal static IEnumerable<Dictionary<string, string>> Chain(List<IOptionSelector> optionSelectors) => optionSelectors.Select(@class => @class.Format(@class.Ask()));
    }
}