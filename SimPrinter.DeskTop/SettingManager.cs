using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop
{
    public class SettingManager
    {
        private readonly string directoryName = "Settings";
        private readonly string directoryPath;

        public event EventHandler<object> SettingSaved;

        public SettingManager(string basePath)
        {
            directoryPath = Path.Combine(basePath, directoryName);
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }

        string GetSettingFilePath<TSetting>()
        {
            string fileName = string.Format("{0}.json", typeof(TSetting).Name);
            return Path.Combine(directoryPath, fileName);
        }

        public void Save<TSetting>(TSetting setting)
        {
            string json = JsonConvert.SerializeObject(setting, Formatting.Indented);
            File.WriteAllText(GetSettingFilePath<TSetting>(), json);

            SettingSaved?.Invoke(this, setting);
        }

        public TSetting Load<TSetting>()
        {
            string filePath = GetSettingFilePath<TSetting>();
            if (!File.Exists(filePath))
                return (TSetting)Activator.CreateInstance(typeof(TSetting));

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<TSetting>(json);
        }

        public bool TryLoad<TSetting>(out TSetting setting)
        {
            string filePath = GetSettingFilePath<TSetting>();
            if (!File.Exists(filePath))
            {
                setting = default;
                return false;
            }

            try
            {
                string json = File.ReadAllText(filePath);
                setting = JsonConvert.DeserializeObject<TSetting>(json);
                return true;
            }
            catch
            {
            }
            setting = default;
            return false;
            
        }
    }
}
