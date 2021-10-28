using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop.Models
{
    /// <summary>
    /// 주문제품 모델
    /// </summary>
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 주문번호
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// 주문시간
        /// </summary>
        public string OrderTime { get; set; }

        /// <summary>
        /// 제품 소계
        /// </summary>
        public string SubTotal { get; set; }

        /// <summary>
        /// 제품 합계
        /// </summary>
        public string Total { get; set; }

        /// <summary>
        /// 신용카드 금액
        /// </summary>
        public string Credit { get; set; }

        /// <summary>
        /// 청구금액
        /// </summary>
        public string BillAmount { get; set; }

        /// <summary>
        /// 고객연락처
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 주소
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 메모
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 주문상세
        /// </summary>
        public string ProductDetail { get; set; }

        public static OrderViewModel FromOrderModel(OrderModel order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                OrderTime = order.OrderTime,
                Contact = order.Contact,
                Address = order.Address,
                Memo = order.Memo,
                SubTotal = order.SubTotal,
                Total = order.Total,
                Credit = order.CreditAmount,
                BillAmount = order.BillAmount,
                ProductDetail = string.Join("\r\n", order.Products.Select(p => p.ToString()))
            };
        }

    }
}
