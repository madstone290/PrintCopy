using NUnit.Framework;
using SimPrinter.Core;
using SimPrinter.Core.ByteParsers;
using SimPrinter.Core.Models;
using SimPrinter.Core.Persistence;
using SimPrinter.Core.TextParsers;
using SimPrinter.NUnitTest.Mockups;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.NUnitTest
{
    /// <summary>
    /// Worker 클래스 테스트
    /// </summary>
    public class WorkerTest
    {
        static SerialPort CreateSerialPort(string portName)
        {
            SerialPort port = new SerialPort();
            port.PortName = portName;
            port.BaudRate = 9600;
            port.DataBits = 7;
            port.StopBits = StopBits.One;
            port.Parity = Parity.Even;
            port.Encoding = Encoding.GetEncoding(949);
            return port;
        }

        [Test]
        public void ByteReceive_OrderCreate()
        {
            // 시리얼포트 이름 설정할 것
            SimSerialPort appPort = new SimSerialPortMockup(CreateSerialPort("COM0"));
            SimSerialPort printPort = new SimSerialPort(CreateSerialPort("COM0"));
            IByteParser byteParser = new EscPosByteParser(Encoding.GetEncoding(949));
            LabelPrinter labelPrinter = new LabelPrinter(null);
            //LabelPrinter labelPrinter = new LabelPrinter(CreateSerialPort(labelPrintPortSetting));
            OrderDao orderDao = new OrderDao(Directory.GetCurrentDirectory());

            Worker worker = new Worker(appPort, printPort, byteParser, labelPrinter, orderDao);
            worker.Run();

            OrderModel order = null;
            worker.OrderCreated += (s, e) =>
            {
                order = e.Order;
            };

            ((SimSerialPortMockup)appPort).OrderDataReceived();

            Assert.NotNull(order);
            Assert.AreEqual(SimSerialPortMockup.ORDER_TIME.Replace("\r\n", " "), order.OrderTime);
            Assert.AreEqual(SimSerialPortMockup.CONTACT.Replace("\r\n", " "), order.Contact);
            Assert.AreEqual(SimSerialPortMockup.ADDRESS.Replace("\r\n", " "), order.Address);
            Assert.AreEqual(SimSerialPortMockup.MEMO.Replace("\r\n", " "), order.Memo);
            Assert.AreEqual(SimSerialPortMockup.CREDIT_AMOUNT.Replace("\r\n", " "), order.CreditAmount);
            Assert.AreEqual(SimSerialPortMockup.BILL_AMOUNT.Replace("\r\n", " "), order.BillAmount);

        }

        [Test]
        public void DistinguishTest1()
        {
            PrintoutDistinguisher printoutDistinguisher = new PrintoutDistinguisher();
            var type = printoutDistinguisher.Distinguish(
                @"
E1ds23PIZZA ALVOLO
                                          
상    호: 피자알볼로 지산범물점
주    소: 대구광역시 수성구 지산동 1268-15 1층
사업자NO: 5026357815
대 표 자: 오자희
전화번호: 0537838495
                                          
접수유형: BD(배달의민족)
거래일시: 2021-10-30 13:43:26 (토)
------------------------------------------
     상 품 명              수량    금 액
------------------------------------------
날개피자 L                    1     31,000
+기본                         1          0
+코카콜라1.25L 추가           1      2,000
배달비                        1      1,000

------------------------------------------
소  계         34,000
------------------------------------------
합  계         34,000
                                          
배달의민족(선결제)                  34,000
------------------------------------------
청구 금액                                0
"
                );

            Assert.AreEqual(PrintoutType.ZPosOrder, type);
        }

        [Test]
        public void DistinguishTest2()
        {
            PrintoutDistinguisher printoutDistinguisher = new PrintoutDistinguisher();
            var type = printoutDistinguisher.Distinguish(
                @"가맹점 명 : 피자알볼로 지산범물점
가맹점 주소
대구 수성구 지산동 1268-15
주문시간 : 2021-11-20 19:13:36
==========================================
상품명                    수량        가격
------------------------------------------
쉬림프 & 핫치킨골드피       1       31,000
자 L                      
 ▶L                                      
 ▶기본                                   
 ▶코카콜라 1.25L 추가               2,000
배달팁                               1,000
==========================================
                   총  금액 :       34,000
------------------------------------------
                   할인금액 :        5,200
                   결제금액 :       28,800
------------------------------------------
고객 주소
대구광역시 수성구 범물동 1269
대구광역시 수성구 용학로 316
 205동 606호

고객 연락처: 050389134759

결제방법 : 선결제

고객요청사항: (수저포크 X)

배달: 문 앞에 두고 벨 눌러 주세요
------------------------------------------


"
                );

            Assert.AreEqual(PrintoutType.DaeguroOrder, type);

        }


    }
}
