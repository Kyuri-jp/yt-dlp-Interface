using yt_dlp_Interface.Libs.Systems;

namespace yt_dlp_Interface.Libs.Client
{
    internal class Preset(string settingFile)
    {
        internal Dictionary<string, List<string>> Setting
        {
            set => Override(value);
            get => Parse();
        }

        internal Dictionary<string, List<string>> Parse()
        {
            Dictionary<string, string> value = [];
            string[] fileData = File.ReadAllLines(settingFile);
            foreach (var item in fileData)
            {
                if (item[0] == '#') continue;
                value.Add(item[..item.IndexOf('=')].Trim(), item[(item.IndexOf('=') + 1)..].Trim());
            }
            return value.ToDictionary(value => value.Key, value => value.Value.Split(';').ToList());
        }

        internal void Override(Dictionary<string, List<string>> value)
        {
            Dictionary<string, List<string>> fileData = Parse();
            foreach (var pair in value)
                if (fileData.ContainsKey(pair.Key))
                    fileData[pair.Key] = pair.Value;
                else
                    fileData.Add(pair.Key, pair.Value);

            List<string> writeList = [];
            writeList.AddRange(fileData.Select(item => $"{item.Key}={string.Join(';', item.Value)}"));
            File.WriteAllLines(settingFile, writeList, Encode.GetEncoding(settingFile));
        }

        internal void Add(KeyValuePair<string, List<string>> value)
        {
            Dictionary<string, List<string>> result = Parse();
            if (result.ContainsKey(value.Key))
                result[value.Key] = value.Value;
            else
                result.Add(value.Key, value.Value);
            Override(result);
        }

        internal void Remove(KeyValuePair<string, List<string>> value)
        {
            Dictionary<string, List<string>> result = Parse();
            result.Remove(value.Key);
            Override(result);
        }
    }
}