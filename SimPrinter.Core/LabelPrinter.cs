using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
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
    public class LabelPrinter
    {
        /// <summary>
        /// 시리얼포트
        /// </summary>
        private readonly SerialPort serialPort;

        public LabelPrinter(SerialPort serialPort)
        {
            this.serialPort = serialPort;
        }

        /// <summary>
        /// 주문정보를 출력한다.
        /// </summary>
        /// <param name="order"></param>
        internal void Print(OrderModel order)
        {
            // TODO implement
            Console.WriteLine("Print");
        }

        /// <summary>
        /// 본문을 출력한다.
        /// </summary>
        /// <param name="text"></param>
        public void Print(string text)
        {
            // TODO implement
            Console.WriteLine(text);
        }
    }
}
