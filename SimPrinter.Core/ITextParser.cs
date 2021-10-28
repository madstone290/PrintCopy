using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    /// <summary>
    /// 영수증 텍스트를 분석해서 주문정보를 추출한다.
    /// </summary>
    public interface ITextParser
    {
        /// <summary>
        /// 영수증텍스트에서 주문정보를 추출한다.
        /// </summary>
        /// <param name="receiptText">영수증 텍스트</param>
        /// <returns></returns>
        OrderModel Parse(string receiptText);
    }
}
