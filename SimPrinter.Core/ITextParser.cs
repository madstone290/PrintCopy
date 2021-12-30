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
        /// 주문텍스트에서 주문모델을 생성한다.
        /// </summary>
        /// <param name="orderText">주문 텍스트</param>
        /// <returns></returns>
        OrderModel Parse(string orderText);

        /// <summary>
        /// 피자목록
        /// </summary>
        string[] Pizzas { get; set; }

        /// <summary>
        /// 사이드 제품목록
        /// </summary>
        string[] SideDishes { get; set; }

    }
}
