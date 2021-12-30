using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop.Settings
{
    public class 라벨설정
    {
        
        public const int PaperWidthDefault = 99;

        public const int PaperHeightDefault = 40;

        /// <summary>
        /// 출력 예외항목 기본값
        /// </summary>
        public static readonly string[] DefaultNoPrintProducts = new string[]
        {
            "배달료", "배달비"
        };


        public static 라벨설정 Default => new 라벨설정()
        {
            용지너비mm = PaperWidthDefault,
            용지높이mm = PaperHeightDefault,
            미출력제품목록 = DefaultNoPrintProducts,
        };

        /// <summary>
        /// 용지너비(mm)
        /// </summary>
        public int 용지너비mm { get; set; } 
        
        /// <summary>
        /// 용지높이(mm)
        /// </summary>
        public int 용지높이mm { get; set; }
        
        public string[] 미출력제품목록 { get; set; }

    }
}
