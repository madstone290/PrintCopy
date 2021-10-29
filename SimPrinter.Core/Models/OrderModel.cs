using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.Models
{
    /// <summary>
    /// 주문정보 모델
    /// </summary>
    public class OrderModel
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// 주문번호
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// 주문시간
        /// </summary>
        public string OrderTime { get; set; }

        /// <summary>
        /// 주문 제품
        /// </summary>
        public ProductModel[] Products { get; set; } = new ProductModel[] { };

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
        public string CreditAmount { get; set; }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ID: {0}, OrderNumber: {1}", Id.ToString(), OrderNumber);
            return sb.ToString();
        }

    }
}
