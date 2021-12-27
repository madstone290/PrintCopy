using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.LabelPrinters
{
    public class DummyPrinter : ILabelPrinter
    {
        public void Print(OrderModel order)
        {
            
        }

        public void Print(string text)
        {
            
        }
    }
}
