using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop.Models
{
    /// <summary>
    /// 텍스트 데이터 모델
    /// </summary>
    public class TextDataModel
    {
        /// <summary>
        /// 주문번호
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// 16진수 표현
        /// </summary>
        public string Text { get; set; }
    }
}
