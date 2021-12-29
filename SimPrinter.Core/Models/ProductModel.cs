using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.Models
{
    /// <summary>
    /// 제품
    /// </summary>
    public class ProductModel
    {

        private const string SET_MARK = "-";

        /// <summary>
        /// 제품명
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 수량
        /// </summary>
        public string Quantity { get; set; }

        public int QuantityInt => Convert.ToInt32(Quantity);

        /// <summary>
        /// 금액
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// 제품유형
        /// </summary>
        public ProductType Type { get; set; }

        /// <summary>
        /// 세트 구성품
        /// </summary>
        public List<string> SetComponents { get; set; } = new List<string>();

        /// <summary>
        /// 표식이 추가된 세트구성품
        /// </summary>
        public IEnumerable<string> MarkedSetComponents => SetComponents.Select(component => SET_MARK + component);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0, 5} {1} {2, 5}개", Type, Name, Quantity );
            foreach(string component in MarkedSetComponents)
            {
                sb.AppendLine();
                sb.Append(component);
            }
            return sb.ToString();
        }
    }
}
