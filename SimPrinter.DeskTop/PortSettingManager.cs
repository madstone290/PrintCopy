using SimPrinter.DeskTop.Models;
using SimPrinter.DeskTop.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SimPrinter.DeskTop
{
    public class PortSettingManager
    {
        private readonly string filePath;

        private static readonly PortSettingManager portSettingManager = new PortSettingManager();
        public static PortSettingManager Instance => portSettingManager;

        private PortSettingManager()
        {
            filePath = Path.Combine(Application.StartupPath, "port-settings.yml");
        }

        /// <summary>
        /// 입력포트 설정
        /// </summary>
        public PortSetting AppPortSetting { get; private set; } = new PortSetting();

        /// <summary>
        /// 일반 프린터 설정
        /// </summary>
        public PortSetting PrinterPortSetting { get; private set; } = new PortSetting();

        /// <summary>
        /// 포트설정을 갱신한다.
        /// </summary>
        /// <param name="appPortSetting"></param>
        /// <param name="printPortSetting"></param>
        /// <param name="labelPrinterPortSetting"></param>
        public void SetPortSettings(PortSetting appPortSetting, PortSetting printPortSetting)
        {
            if (appPortSetting == null)
                throw new ArgumentNullException(nameof(appPortSetting), "앱포트 설정이 null입니다");
            if (printPortSetting == null)
                throw new ArgumentNullException(nameof(printPortSetting), "프린터 설정이 null입니다");

            AppPortSetting = appPortSetting;
            PrinterPortSetting = printPortSetting;
        }

        /// <summary>
        /// 파일에서 설정을 불러온다.
        /// </summary>
        public void Load()
        {
            if (!File.Exists(filePath))
                return;

            string yaml = File.ReadAllText(filePath);

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)  // see height_in_inches in sample yml 
                .Build();

            PortSetting[] portSettings = null;
            try
            {
                portSettings = deserializer.Deserialize<PortSetting[]>(yaml);
            }
            catch (YamlDotNet.Core.YamlException)
            {
                // TODO log
            }

            if (portSettings == null)
                return;

            AppPortSetting = 0 < portSettings.Length ? portSettings[0] : new PortSetting();
            PrinterPortSetting = 1 < portSettings.Length ? portSettings[1] : new PortSetting();

        }

        /// <summary>
        /// 로컬파일에 설정을 저장한다.
        /// </summary>
        public void Save()
        {
            var serializer = new SerializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            try
            {
                string yaml = serializer.Serialize(new PortSetting[]
                {
                    AppPortSetting, PrinterPortSetting
                });
                File.WriteAllText(filePath, yaml);
            }
            catch (YamlDotNet.Core.YamlException)
            {
                // TODO log
            }
        }

    }
}
