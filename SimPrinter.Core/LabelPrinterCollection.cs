using SimPrinter.Core.LabelPrinters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    public static class LabelPrinterCollection
    {
        public static ILabelPrinter Dummy { get; } = new DummyPrinter();

        public static ILabelPrinter BixolonSrp770 { get; } = new BixolonSrp770();
    }
}
