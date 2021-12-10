using Serilog.Core;
using SimPrinter.Core.Logging;
using SimPrinter.Core.Models;
using SimPrinter.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.TextParsers
{
    /// <summary>
    /// 대구로 주문 분석기
    /// </summary>
    public class DaeguroTextParser : ITextParser
    {
        private readonly Logger logger = LoggingManager.Logger;

        /// <summary>
        /// 제품텍스트라인에서 세트구성품을 식별하기위한 표식문자
        /// </summary>
        private const string SET_MARK = "-";

        /// <summary>
        /// 피자사이즈 문자열
        /// </summary>
        public string[] PizzaSizeStrings { get; set; } = new string[] { "R", "S", "L" };

        /// <summary>
        /// 거래일시 문자열
        /// </summary>
        public string OrderTimeString { get; set; } = "주문시간 :";

        /// <summary>
        /// 고객번호 문자
        /// </summary>
        public string ContactString { get; set; } = "고객 연락처:";

        /// <summary>
        /// 고객주소 문자
        /// </summary>
        public string AddressString { get; set; } = "고객 주소";

        /// <summary>
        /// 메모1 문자
        /// </summary>
        public string Memo1String { get; set; } = "고객요청사항:";

        /// <summary>
        /// 메모2 문자
        /// </summary>
        public string Memo2String { get; set; } = "배달:";

        /// <summary>
        /// 제품구분 시작라인 문자
        /// </summary>
        public string ProductStartLineString { get; set; } = "------------------------------------------";

        /// <summary>
        /// 제품구분 종료라인 문자
        /// </summary>
        public string ProductEndLineString { get; set; } = "==========================================";

        /// <summary>
        /// 세트구성품 문자
        /// </summary>
        public string SetComponentString { get; set; } = " ▶";

        /// <summary>
        /// 주문 끝 문자열
        /// </summary>
        public string OrderEndLineString { get; set; } = "------------------------------------------";

        /// <summary>
        /// 배달팁 
        /// </summary>
        public string DeliveryTip { get; set; } = "배달팁";

        public OrderModel Parse(string receiptText)
        {
            string[] textLines = receiptText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            OrderModel order = new OrderModel();
            order.OrderTime = ParseOrderTime(textLines);
            order.Contact = ParseContact(textLines);
            order.Address = ParseAddress(textLines);
            order.Memo = string.Join(Environment.NewLine, ParseMemo1(textLines), ParseMemo2(textLines));
            order.Products = ParseProduct(textLines);

            return order;
        }


        /// <summary>
        /// 주문시간 분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseOrderTime(string[] textLines)
        {
            // 거래일시 문자열로 검색
            string orderTime = StringUtil.FindByDelimiter(textLines, OrderTimeString)?.Trim();
            logger.Information("ParseOrderTime {OrderTimeText} {orderTime}", OrderTimeString, orderTime);
            return orderTime;
        }

        /// <summary>
        /// 고객번호 분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseContact(string[] textLines)
        {
            // 고객번호 문자열로 검색
            string contact = StringUtil.FindByDelimiter(textLines, ContactString)?.Trim();
            logger.Information("ParseContact {ContactString} {contact}", ContactString, contact);
            return contact;
        }

        /// <summary>
        /// 고객주소 분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseAddress(string[] textLines)
        {
            // 고객주소 문자열에서 연락처 문자열 사이
            string address = StringUtil.FindByDelimiters(textLines, AddressString, ContactString,
                includeDelimiter1Line: true,
                includeDelimiter2Line: false,
                removeDelimiter1: true,
                removeDelimiter2: true);

            address = address?.Trim();
            logger.Information("ParseAddress {AddressString} {MemoString} {address}", AddressString, ContactString, address);
            return address;
        }

        /// <summary>
        /// 메모분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseMemo1(string[] textLines)
        {
            // 메모1에서 메모2까지
            string memo = StringUtil.FindByDelimiters(textLines, Memo1String, Memo2String,
                includeDelimiter1Line: true,
                includeDelimiter2Line: false,
                removeDelimiter1: true,
                removeDelimiter2: true);

            memo = memo?.Trim();
            logger.Information("ParseAddress {Memo1String} {memo}", Memo1String, memo);
            return memo;
        }

        /// <summary>
        /// 메모분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseMemo2(string[] textLines)
        {
            // 메모2에서 주문끝까지
            string memo = StringUtil.FindByDelimiters(textLines, Memo2String, OrderEndLineString,
                includeDelimiter1Line: true,
                includeDelimiter2Line: false,
                removeDelimiter1: true,
                removeDelimiter2: true);
            memo = memo?.Trim();
            logger.Information("ParseAddress {Memo2String} {memo}", Memo2String, memo);
            return memo;
        }

        /// <summary>
        /// 제품목록 분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public ProductModel[] ParseProduct(string[] textLines)
        {
            // 0. 공백인가? -> 스킵
            // 1. 제품1인가?
            // 1-Y. 제품추가
            // 1-N. 제품2인가?
            // 1-N-Y. 제품 병합
            // 1-N-N(세트). 제품 구성품 추가

            // 제품문자열 검색
            string[] productTextLines = 
                StringUtil.FindLinesByDelimiters(textLines, ProductStartLineString, 0, ProductEndLineString, 1, false);
            


            // 제품명, 수량, 가격 합치기
            string[] mergedProductTextLines = MergeProductText(productTextLines);

            List<ProductModel> productModels = new List<ProductModel>();

            // 문자열라인을 제품으로 변경
            foreach (var textLine in mergedProductTextLines)
            {
                if (!textLine.StartsWith(SET_MARK)) // 제품
                {
                    // 제품전체 파트
                    string[] allParts = textLine.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                    if (allParts.Length == 0)
                        continue;

                    // 공백으로 구분시 끝에서부터 순서대로 가격, 수량, 제품명
                    string quantity;
                    string price;
                    string name;

                    if (allParts[0] == DeliveryTip)  // 예외처리
                    {
                        name = DeliveryTip;
                        price = allParts[1];
                        quantity = "1";
                    }
                    else if (allParts.Length < 3) // 이름으로 구성
                    {
                        price = string.Empty;
                        quantity = string.Empty;
                        name = string.Join(" ", allParts);
                    }
                    else // 이름, 수량, 가격으로 구성됨
                    {
                        price = allParts[allParts.Length - 1];
                        quantity = allParts[allParts.Length - 2];
                        name = string.Join(" ", allParts.Take(allParts.Length - 2));
                    }

                    // 제품명 파트
                    string[] nameParts = name.Split(' ');
                    string pizzaSize = nameParts[nameParts.Length - 1];
                    ProductType productType = PizzaSizeStrings.Contains(pizzaSize) ? ProductType.Pizza : ProductType.Other;

                    // 제품 유형분석
                    ProductModel productModel = new ProductModel();
                    productModel.Name = name;
                    productModel.Price = price;
                    productModel.Quantity = quantity;
                    productModel.Type = productType;

                    productModels.Add(productModel);
                }
                else // 구성품
                {
                    ProductModel productModel = productModels.Last();
                    productModel.SetComponents.Add(textLine);
                }
            }
            ProductModel[] products = productModels.ToArray();
            logger.Information("ParseProduct {products}", products);
            return products;

        }

        /// <summary>
        /// 두줄로 나눠진 제품 텍스트를 한줄로 병합하고 그 결과를 반환한다.
        /// </summary>
        /// <param name="productTextLines"></param>
        /// <returns></returns>
        private string[] MergeProductText(string[] productTextLines)
        {
            /*
             * 제품이름이 긴 경우 제품1, 제품2 파트로 나뉜다
             * 제품1 파트는 이름, 수량, 가격으로 구성
             * 제품2 파트는 이름으로 구성.
             * 제품은 제품1이름 + 제품2이름 , 제품1수량, 제품1 가격
             * 예외) 배달팁
             * */

            List<string> products = new List<string>();
            for (int i = 0; i < productTextLines.Length; i++)
            {
                string textLine = productTextLines[i];

                if (string.IsNullOrWhiteSpace(textLine))
                    continue;

                var components = textLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);


                // 배달팁 제품
                if (0 < components.Length && components[0] == DeliveryTip)
                {
                    products.Add(textLine.Trim());
                }
                // 제품1 식별. 가격 및 수량이 존재한다.
                else if (3 <= components.Length
                    && decimal.TryParse(components[components.Length - 1], out decimal r1)
                    && decimal.TryParse(components[components.Length - 2], out decimal r2)
                )
                {
                    products.Add(textLine.Trim());
                }
                // 세트구성품. 세트구성품문자를 변경한다.
                else if (textLine.StartsWith(SetComponentString))
                {
                    string component = SET_MARK + textLine.Replace(SetComponentString, "")?.Trim();
                    products.Add(component);
                }
                // 제품2. 제품1과 결합한다.
                else
                {
                    string product2 = textLine.Trim();
                    string product1 = products.Last();

                    var productComponents = product1.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    string product = string.Join(" ",
                        string.Join(" ", productComponents.ToArray(), 0, productComponents.Count - 2) + product2,
                        string.Join(" ", productComponents.ToArray(), productComponents.Count - 2, 2)
                        );
                    
                    products[products.Count - 1] = product;
                }
            }
            return products.ToArray();

        }

    }
}
