using Serilog.Core;
using SimPrinter.Core.EventArgs;
using SimPrinter.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    /// <summary>
    /// 시리얼 포트 랩퍼.
    /// </summary>
    public class SimSerialPort
    {
        private readonly Logger logger = LoggingManager.Logger;

        /// <summary>
        /// 작동 여부
        /// </summary>
        private bool isRunning = false;

        /// <summary>
        /// 시리얼포트
        /// </summary>
        private readonly SerialPort serialPort;

        /// <summary>
        /// 데이터를 수신하였다.
        /// </summary>
        internal event EventHandler<SerialDataArgs> DataReceived;

        public SimSerialPort(SerialPort serialPort)
        {
            if (serialPort == null)
                throw new ArgumentNullException(nameof(serialPort));

            this.serialPort = serialPort;
            this.serialPort.DataReceived += SerialPort_DataReceived;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bufferSize = serialPort.BytesToRead;
            byte[] buffer = new byte[bufferSize];
            serialPort.Read(buffer, 0, bufferSize);

            RaiseDataReceived(buffer, 0, bufferSize);
        }

        /// <summary>
        /// 데이터 수신이벤트 발생
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        protected void RaiseDataReceived(byte[] buffer, int offset, int length)
        {
            DataReceived?.Invoke(this, new SerialDataArgs(buffer, offset, length));
        }

        /// <summary>
        /// 시리얼포트 작업을 시작한다.
        /// </summary>
        internal void Run()
        {
            if (isRunning)
                throw new InvalidOperationException("시리얼포트가 이미 작동중입니다");

            serialPort.Open();

            isRunning = true;

            logger.Information("Run");
        }

        /// <summary>
        /// 데이터를 송신한다.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        internal void Send(byte[] buffer, int offset, int length)
        {
            serialPort.Write(buffer, offset, length);
        }

        /// <summary>
        /// 시리얼포트 작업을 종료한다.
        /// </summary>
        internal void Stop()
        {
            serialPort.Dispose();

            logger.Information("Stop");
        }
    }
}
