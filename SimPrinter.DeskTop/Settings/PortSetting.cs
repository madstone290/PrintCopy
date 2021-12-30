using SimPrinter.DeskTop.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop.Settings
{
    /// <summary>
    /// 시리얼포트 설정
    /// </summary>
    public class PortSetting
    {
        /// <summary>
        /// 앱 포트
        /// </summary>
        public PortInfoModel AppPort { get; set; }
        
        /// <summary>
        /// 프린터 포트
        /// </summary>
        public PortInfoModel PrinterPort { get; set; }

        public static PortSetting Default => new PortSetting()
        {
            AppPort = new PortInfoModel(),
            PrinterPort = new PortInfoModel()
        };

       
       
    }
}
