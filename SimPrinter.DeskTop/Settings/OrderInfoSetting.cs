using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop.Settings
{
    /// <summary>
    /// 주문정보
    /// </summary>
    public class OrderInfoSetting
    {
        public string[] Pizzas { get; set; }

        public string[] SideDishes { get; set; }

        public string[] NoPrintProducts { get; set; }

        /// <summary>
        /// 피자 기본값
        /// </summary>
        public string[] DefaultPizzas { get; set; } = new string[]
        {
            "하프앤하프",
            "디럭스 콤비 피자",
            "스위트 고구마 피자",
            "트리플 치즈 피자",
            "하와이은 페페피자",
            "핫치킨 피자"
        };

        /// <summary>
        /// 사이드 기본값
        /// </summary>
        public string[] DefaultSideDishes { get; set; } = new string[]
        {
            "콘치즈그라탕"
        };

        /// <summary>
        /// 출력 예외항목 기본값
        /// </summary>
        public string[] DefaultNoPrintProducts { get; set; } = new string[]
        {
            "배달료", "배달비"
        };

    }
}
