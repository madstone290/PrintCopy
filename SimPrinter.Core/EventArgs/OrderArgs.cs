using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.EventArgs
{
    /// <summary>
    /// 주문 인자
    /// </summary>
    public class OrderArgs
    {
        /// <summary>
        /// 주문모델
        /// </summary>
        public OrderModel Order { get; }

        /// <summary>
        /// 시리얼데이터 16진수 표현
        /// </summary>
        public string RawHex { get; }

        /// <summary>
        /// 주문데이터 16진수 표현
        /// </summary>
        public string OrderHex { get; }

        /// <summary>
        /// 주문 문자표현
        /// </summary>
        public string OrderText { get; }

        public OrderArgs(OrderModel order, string rawHex, string orderHex, string orderText)
        {
            Order = order;
            RawHex = rawHex;
            OrderHex = orderHex;
            OrderText = orderText;
        }
    }
}
