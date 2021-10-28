using SimPrinter.Core.Models;
using SimPrinter.Core.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimPrinter.Core.Logging;
using Serilog.Core;
using SimPrinter.Core.Persistence;

namespace SimPrinter.Core
{
    /// <summary>
    /// 작업스레드.
    /// 이벤트를 처리한다.
    /// </summary>
    public class Worker
    {
        private readonly Logger logger = LoggingManager.Logger;

        /// <summary>
        /// 어플리케이션 연결포트
        /// </summary>
        private readonly SimSerialPort appPort;

        /// <summary>
        /// 프린터 연결포트
        /// </summary>
        private readonly SimSerialPort printerPort;
        
        /// <summary>
        /// 영수증 추출기
        /// </summary>
        private readonly IByteParser byteParser;

        /// <summary>
        /// 주문정보 추출기
        /// </summary>
        private readonly ITextParser textParser;

        /// <summary>
        /// 라벨프린터
        /// </summary>
        private readonly LabelPrinter labelPrinter;

        /// <summary>
        /// 주문DAO
        /// </summary>
        private readonly OrderDao orderDao;

        /// <summary>
        /// 주문목록
        /// </summary>
        private readonly List<OrderModel> orders = new List<OrderModel>();

        /// <summary>
        /// 주문목록
        /// </summary>
        public OrderModel[] Orders => orders.ToArray();

        /// <summary>
        /// 주문정보가 생성되었다.
        /// </summary>
        public event EventHandler<OrderArgs> OrderCreated;

        public Worker(SimSerialPort appPort, SimSerialPort printerPort, IByteParser byteParser, ITextParser textParser, LabelPrinter labelPrinter, OrderDao orderDao)
        {
            if (appPort == null)
                throw new ArgumentNullException(nameof(appPort));
            if (printerPort == null)
                throw new ArgumentNullException(nameof(printerPort));
            if (byteParser == null)
                throw new ArgumentNullException(nameof(byteParser));
            if (textParser == null)
                throw new ArgumentNullException(nameof(textParser));
            if (labelPrinter == null)
                throw new ArgumentNullException(nameof(labelPrinter));
            if (orderDao == null)
                throw new ArgumentNullException(nameof(orderDao));

            this.appPort = appPort;
            this.printerPort = printerPort;
            this.byteParser = byteParser;
            this.textParser = textParser;
            this.labelPrinter = labelPrinter;
            this.orderDao = orderDao;

            appPort.DataReceived += AppPort_DataReceived;
            printerPort.DataReceived += PrinterPort_DataReceived;
            byteParser.ParsingCompleted += ByteParser_ParsingCompleted;
        }

        /// <summary>
        /// 설정된 일자기준으로 데이터를 복원한다. 
        /// </summary>
        /// <param name="today"></param>
        public void Restore(DateTime date)
        {
            var dateOrders = orderDao.GetOrders(date);
            
            orders.Clear();
            orders.AddRange(dateOrders);
        }

        /// <summary>
        /// 라벨발행
        /// </summary>
        /// <param name="orderId">주문ID</param>
        public void PrintLabel(Guid orderId)
        {
            OrderModel order = orders.FirstOrDefault(x => x.Id == orderId);
            
            if(order != null)
                labelPrinter.Print(order);
        }

        private void ByteParser_ParsingCompleted(object sender, ByteParsingArgs e)
        {
            /*
             * 영수증 분석이 완료되면
             * 1.주문정보 분석
             * 2.라벨프린터 출력
             * 3.주문생성 이벤트
             * */
            logger.Information("ReceiptParsed {NewLine}{Receipt}", Environment.NewLine, e.Text);

            OrderModel order = textParser.Parse(e.Text);
            order.OrderNumber = orderDao.GetOrderNumber(DateTime.Today);
            orderDao.Save(DateTime.Today, order);
            orders.Add(order);

            logger.Information("OrderParsed {order}", order);

            if (order.IsLabelPrinted)
                labelPrinter.Print(order);

            OrderCreated?.Invoke(this, new OrderArgs(order, e.RawBufferHex, e.TextBufferHex, e.Text));
        }

        private void AppPort_DataReceived(object sender, SerialDataArgs e)
        {
            /*
             * 앱포트에서 데이터가 수신되면 
             * 1. 프린터포트로 송신
             * 2. 영수증 바이트 분석
             * */
            logger.Information("AppPort_DataReceived {Data}", BitConverter.ToString(e.Buffer, e.Offset, e.Length));

            printerPort.Send(e.Buffer, e.Offset, e.Length);

            byteParser.Parse(e.Buffer, e.Offset, e.Length);
        }

        private void PrinterPort_DataReceived(object sender, SerialDataArgs e)
        {
            /*
            * 프린트포트에서 데이터가 수신되면 
            * 1. 앱 포트로 송신
            * */
            logger.Information("AppPort_DataReceived {Data}", BitConverter.ToString(e.Buffer, e.Offset, e.Length));

            appPort.Send(e.Buffer, e.Offset, e.Length);
        }


        /// <summary>
        /// 작업을 시작한다.
        /// </summary>
        public void Run()
        {
            appPort.Run();
            printerPort.Run();
        }

        /// <summary>
        /// 작업을 종료한다.
        /// </summary>
        public void Stop()
        {
            appPort.Stop();
            printerPort.Stop();
        }
    }
}
