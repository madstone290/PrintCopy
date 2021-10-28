using SimPrinter.Core;
using SimPrinter.Core.ByteParsers;
using SimPrinter.Core.Persistence;
using SimPrinter.Core.TextParsers;
using SimPrinter.DeskTop.Models;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimPrinter.DeskTop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Worker worker = null;

            FormStart formStart = new FormStart();
            formStart.InitializeAction = () =>
            {
                PortSettingManager portSettingManager = PortSettingManager.Instance;
                portSettingManager.Load();
                worker = PizzaAlvolo(portSettingManager.AppPortSetting, portSettingManager.PrinterPortSetting, portSettingManager.LabelPrinterPortSetting);
                worker.Run();
            };

            formStart.ShowDialog();
            if (!formStart.Start)
                return;

            Application.ApplicationExit += (s, e) => { worker.Stop(); };
            Application.Run(new FormMain(worker));
        }

        /// <summary>
        /// 피자알볼로 생성
        /// </summary>
        /// <returns></returns>
        static Worker PizzaAlvolo(PortSettingModel appPortSetting, PortSettingModel printPortSetting, PortSettingModel labelPrintPortSetting)
        {
            SimSerialPort appPort = new SimSerialPort(CreateSerialPort(appPortSetting));
            SimSerialPort printPort = new SimSerialPort(CreateSerialPort(printPortSetting));
            IByteParser byteParser = new AlvoloByteParser(appPortSetting.GetEncoding());
            ITextParser textParser = new AlvoloTextParser();
            LabelPrinter labelPrinter = new LabelPrinter(null);
            //LabelPrinter labelPrinter = new LabelPrinter(CreateSerialPort(labelPrintPortSetting));
            OrderDao orderDao = new OrderDao(Application.StartupPath);

            Worker worker = new Worker(appPort, printPort, byteParser, textParser, labelPrinter, orderDao);
            return worker;
        }


        static SerialPort CreateSerialPort(PortSettingModel portSetting)
        {
            SerialPort port = new SerialPort();
            port.PortName = portSetting.PortName;
            port.BaudRate = portSetting.BaudRate;
            port.DataBits = portSetting.DataBits;
            port.StopBits = portSetting.StopBits;
            port.Parity = portSetting.Parity;
            port.Encoding = portSetting.GetEncoding();
            port.NewLine = portSetting.NewLine;
            return port;
        }
    }
}
