using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop.Settings
{
    public class LabelSetting
    {
        /// <summary>
        /// 용지너비(mm)
        /// </summary>
        public int PaperWidth { get; set; } 

        /// <summary>
        /// 용지높이(mm)
        /// </summary>
        public int PaperHeight { get; set; }

        public int PaperWidthDefault => 99;

        public int PaperHeightDefault => 40;

    }
}
