namespace yt_dlp_Interface.Commands.ArgumentSelector.Interface
{
    internal interface IArgumentMaker<TEnum> where TEnum : Enum
    {
        internal Dictionary<TEnum, string> Generate();
    }
}