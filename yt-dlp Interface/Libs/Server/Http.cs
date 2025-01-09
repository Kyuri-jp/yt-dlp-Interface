namespace yt_dlp_Interface.Libs.Server
{
    internal class Http
    {
        internal static bool TryAccess(string url) => Uri.TryCreate(url, UriKind.Absolute, out Uri? uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}