using SimPrinter.Core.BixolonPrinter;
using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    /// <summary>
    /// 라벨프린터.
    /// 주문정보를 출력한다.
    /// </summary>
    public interface ILabelPrinter
    {
        /// <summary>
        /// 용지높이
        /// </summary>
        double PaperHeight { get; set; }

        /// <summary>
        /// 용지너비
        /// </summary>
        double PaperWidth { get; set; }

        /// <summary>
        /// 미출력 제품
        /// </summary>
        string[] NoPrintProducts { get; set; }

        /// <summary>
        /// 주문정보를 출력한다.
        /// </summary>
        /// <param name="order"></param>
        void Print(OrderModel order);

        /// <summary>
        /// 본문을 출력한다.
        /// </summary>
        /// <param name="text"></param>
        void Print(string text);
      
    }
}
