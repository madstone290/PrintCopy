using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.Models
{
    /// <summary>
    /// 출력물 유형
    /// </summary>
    public enum PrintoutType
    {
        /// <summary>
        /// 기타 출력물
        /// </summary>
        Other,

        /// <summary>
        /// ZPos 주문 출력물
        /// </summary>
        ZPosOrder,

        /// <summary>
        /// 대구로 주문
        /// </summary>
        DaeguroOrder,

        
    }
}
