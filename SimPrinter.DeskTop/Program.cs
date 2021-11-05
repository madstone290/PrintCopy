using SimPrinter.Core;
using SimPrinter.Core.ByteParsers;
using SimPrinter.Core.Persistence;
using SimPrinter.Core.TextParsers;
using SimPrinter.DeskTop.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimPrinter.DeskTop
{
    static class Program
    {
        /// <summary>
        /// 프로그램 설정 관리자
        /// </summary>
        public static SettingManager SettingManager { get; private set; }

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern void SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 중복 실행시 기존 윈도우를 활성화한다.
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            Process previous = processes.Where(p => p.Id != current.Id).FirstOrDefault();

            if(previous != null)
            {
                IntPtr handle = FindWindow(null, previous.MainWindowTitle);
                
                // 활성화
                ShowWindow(handle, SW_SHOWNORMAL);
                SetForegroundWindow(handle);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SettingManager = new SettingManager(Application.StartupPath);

            Worker worker = null;

            FormStart formStart = new FormStart();
            formStart.InitializeAction = () =>
            {
                PortSettingManager portSettingManager = PortSettingManager.Instance;
                portSettingManager.Load();
                worker = PizzaAlvolo(portSettingManager.AppPortSetting, portSettingManager.PrinterPortSetting, portSettingManager.LabelPrinterPortSetting);
                worker.Run();
            };
            Application.Run(formStart);

            if (!formStart.Start)
                return;
            
            Application.ApplicationExit += (s, e) => { worker.Stop(); };
            Application.Run(new FormMain(worker));
        }

        /// <summary>
        /// 피자알볼로 생성
        /// </summary>
        /// <returns></returns>
        static Worker PizzaAlvolo(PortSetting appPortSetting, PortSetting printPortSetting, PortSetting labelPrintPortSetting)
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


        static SerialPort CreateSerialPort(PortSetting portSetting)
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
