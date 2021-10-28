using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop.Models
{
    /// <summary>
    /// 이진데이터 모델
    /// </summary>
    public class BinaryDataModel
    {
        /// <summary>
        /// 주문번호
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// 원본데이터 16진수 표현
        /// </summary>
        public string RawHex { get; set; }

        /// <summary>
        /// 주문데이터 16진수 표현
        /// </summary>
        public string OrderHex { get; set; }
    }
}
