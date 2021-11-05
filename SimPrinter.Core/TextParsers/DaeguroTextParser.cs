using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.TextParsers
{
    /// <summary>
    /// 대구로 주문 분석기
    /// </summary>
    public class DaeguroTextParser : ITextParser
    {


        public OrderModel Parse(string receiptText)
        {
            return new OrderModel();
        }
    }
}
