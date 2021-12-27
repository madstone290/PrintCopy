﻿using SimPrinter.Core.BixolonPrinter;
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
