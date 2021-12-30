using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop.Settings
{
    public class GeneralSetting
    {
        /// <summary>
        /// 폰트크기
        /// </summary>
        public float FontSize { get; set; } = 8;

        /// <summary>
        /// 라벨설정 사용여부
        /// </summary>
        public bool UseLabelSetting { get; set; }

        /// <summary>
        /// 주문설정 사용여부
        /// </summary>
        public bool UseOrderSetting { get; set; }
    }
}
