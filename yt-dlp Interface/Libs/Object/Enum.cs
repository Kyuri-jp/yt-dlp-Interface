namespace yt_dlp_Interface.Libs.Object
{
    internal static class Enum
    {
        internal static TEnum ElementAt<TEnum>(int index) where TEnum : System.Enum
        {
            if (index < 0 || index >= System.Enum.GetValues(typeof(TEnum)).Length)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out");
            return (TEnum)System.Enum.GetValues(typeof(TEnum)).GetValue(index)!;
        }

        internal static TEnum GetEnum<TEnum>(string value) where TEnum : System.Enum =>
            ElementAt<TEnum>(System.Enum.GetNames(typeof(TEnum)).ToList().IndexOf(value));
    }
}