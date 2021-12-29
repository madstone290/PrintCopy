using NUnit.Framework;
using SimPrinter.Core;
using SimPrinter.Core.Models;
using SimPrinter.Core.TextParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.NUnitTest
{
    /// <summary>
    /// ZPos 배민주문 테스트
    /// </summary>
    public class ZPos_BD_Test
    {
        public const string ORDER_TIME = "2021-10-31 21:19:52 (일)";
        public const string SUB_TOTAL = "25,100";
        public const string TOTAL = "25,100";
        public const string BILL_AMOUNT = "0";
        public const string NUMBER = "0507-1203-9205";
        public const string ADDRESS = "수성구 두산동 113 수성SK리더스뷰 103동 803호 (수성구 동대구로 95 수성SK리더스뷰 103동 803호)";
        public const string MEMO = "[배민 선결제완료] *확인필수* 늦었지만 정성스럽게 부탁드립니다ㅎㅎ!! 라이더분께 요청사항 확인좀하라고전해주세요. (수저포크 X) (배달요청)음식 문 앞에 두고 벨 한번 눌러주고 바로 가시면 됩니다. 사람나올 때까지 기다리지 말아주세요. 배달의민족 콜센터: 1600-0987";

        private string testText;

        private string[] textLines;


        [SetUp]
        public void Setup()
        {
            testText = string.Format(@"
PIZZA ALVOLO
                                          
상    호: 피자알볼로 지산범물점
주    소: 대구광역시 수성구 지산동 1268-15 1층
사업자NO: 5026357815
대 표 자: 오자희
전화번호: 0537838495
                                          
접수유형: BD(배달의민족)
거래일시: {0}
------------------------------------------
     상 품 명              수량    금 액
------------------------------------------
단호박피자 R                  1     19,000
+치즈크러스트                 1      3,000
+스프라이트500ml 추가         1      1,500
갈릭디핑소스 15g              3        600
배달비                        1      1,000

------------------------------------------
소  계         {1}
------------------------------------------
합  계         {2}
                                          
배달의민족(선결제)                  25,100
------------------------------------------
청구 금액                                {3}
                                          
                                          
                                          
고객번호: {4}
고 객 명: 고객님(신규)
고객주소: {5}
주문메모: {6}
                                         

", ORDER_TIME, SUB_TOTAL, TOTAL, BILL_AMOUNT, NUMBER, ADDRESS, MEMO);


            textLines = testText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        }


        [Test]
        public void ParseOrderTimeTest()
        {
            ZPosTextParser textParser = new ZPosTextParser();

            string orderTime = textParser.ParseOrderTime(textLines);

            Assert.AreEqual(ORDER_TIME, orderTime);

            Console.WriteLine(orderTime);
        }

        [Test]
        public void ParseProductSubTotal()
        {
            ZPosTextParser textParser = new ZPosTextParser();

            string subTotal = textParser.ParseSubTotal(textLines);

            Assert.AreEqual(SUB_TOTAL, subTotal);

            Console.WriteLine(subTotal);
        }

        [Test]
        public void ParseProductTotal()
        {
            ZPosTextParser textParser = new ZPosTextParser();

            string total = textParser.ParseTotal(textLines);

            Assert.AreEqual(TOTAL, total);

            Console.WriteLine(total);
        }

        [Test]
        public void ParseBillAmount()
        {
            ZPosTextParser textParser = new ZPosTextParser();

            string amount = textParser.ParseBillAmount(textLines);

            Assert.AreEqual(BILL_AMOUNT, amount);

            Console.WriteLine(amount);
        }


        [Test]
        public void ParseContactNumber()
        {
            ZPosTextParser textParser = new ZPosTextParser();

            string number = textParser.ParseContact(textLines);

            Assert.AreEqual(NUMBER, number);

            Console.WriteLine(number);
        }

        [Test]
        public void ParseAddress()
        {
            ZPosTextParser textParser = new ZPosTextParser();

            string address = textParser.ParseAddress(textLines);

            Assert.AreEqual(ADDRESS.Replace("\r\n", " "), address);

            Console.WriteLine(address);
        }

        [Test]
        public void ParseProduct()
        {
            ZPosTextParser textParser = new ZPosTextParser();

            ProductModel[] products = textParser.ParseProduct(textLines);

            Assert.NotNull(products);
            Assert.IsTrue(0 < products.Length);
            Assert.IsTrue(products.Any(X=> X.SetItems.Count > 0));
            foreach (var product in products)
                Console.WriteLine(product);
        }

        [Test]
        public void ParseOrder()
        {
            ZPosTextParser textParser = new ZPosTextParser();

            OrderModel order = textParser.Parse(testText);

            Assert.NotNull(order);
            Assert.AreEqual(ORDER_TIME, order.OrderTime);
            Assert.AreEqual(SUB_TOTAL, order.SubTotal);
            Assert.AreEqual(TOTAL, order.Total);
            Assert.AreEqual(BILL_AMOUNT, order.BillAmount);
            Assert.AreEqual(NUMBER, order.Contact);
            Assert.AreEqual(ADDRESS.Replace("\r\n", " "), order.Address);

        }

        [Test]
        public void CheckPizzaCount()
        {
            ZPosTextParser textParser = new ZPosTextParser();

            ProductModel[] products = textParser.ParseProduct(textLines);

            Assert.NotNull(products);
            Assert.IsTrue(0 < products.Length);

            Assert.AreEqual(1, products.Count(x => x.Type == ProductType.Pizza));
        }
    }
}
