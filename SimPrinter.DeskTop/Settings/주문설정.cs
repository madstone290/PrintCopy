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
    public class 주문설정
    {
        /// <summary>
        /// 피자 기본값
        /// </summary>
        public static readonly string[] DefaultPizzas = new string[]
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
        public static readonly string[] DefaultSideDishes = new string[]
        {
            "콘치즈그라탕"
        };

        public static 주문설정 Default => new 주문설정()
        {
            피자목록 = DefaultPizzas,
            사이드목록 = DefaultSideDishes,
        };
        
        public string[] 피자목록 { get; set; }
        
        public string[] 사이드목록 { get; set; }

 


    }
}
