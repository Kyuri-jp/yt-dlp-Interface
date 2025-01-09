using yt_dlp_Interface.Libs.Systems;

namespace yt_dlp_Interface.Libs.Client
{
    internal class Preset(string settingFile)
    {
        internal Dictionary<string, string> Setting
        {
            set => Override(value);
            get => Parse();
        }

        internal Dictionary<string, string> Parse()
        {
            Dictionary<string, string> value = [];
            string[] fileData = File.ReadAllLines(settingFile);
            foreach (var item in fileData)
            {
                if (item[0] == '#') continue;
                value.Add(item[..item.IndexOf('=')].Trim(), item[(item.IndexOf('=') + 1)..].Trim());
            }
            return value;
        }

        internal void Override(Dictionary<string, string> value)
        {
            Dictionary<string, string> fileData = Parse();
            foreach (var item in value.Where(item => fileData.ContainsKey(item.Key)))
                fileData[item.Key] = item.Value;

            List<string> writeList = [];
            writeList.AddRange(fileData.Select(item => $"{item.Key}={item.Value}"));
            File.WriteAllLines(settingFile, writeList, Encode.GetEncoding(settingFile));
        }

        internal void Add(KeyValuePair<string, string> value)
        {
            Dictionary<string, string> result = Parse();
            result[value.Key] = value.Value;
            Override(result);
        }

        internal void Remove(KeyValuePair<string, string> value)
        {
            Dictionary<string, string> result = Parse();
            result.Remove(value.Key);
            Override(result);
        }
    }
}