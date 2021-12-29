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
    /// ZPos 주문텍스트를 분석해서 주문정보를 추출한다.
    /// </summary>
    public class ZPosTextParser : ITextParser
    {
        private readonly Logger logger = LoggingManager.Logger;

        /// <summary>
        /// 피자사이즈 문자열
        /// </summary>
        public string[] PizzaSizeStrings { get; set; } = new string[] { "R", "S", "L" };

        /// <summary>
        /// 거래일시 문자열
        /// </summary>
        public string OrderTimeString { get; set; } = "거래일시:";

        /// <summary>
        /// 소계 문자열
        /// </summary>
        public string SubTotalString { get; set; } = "소  계";

        /// <summary>
        /// 합계 문자열
        /// </summary>
        public string TotalString { get; set; } = "합  계";

        /// <summary>
        /// 신용카드 문자열
        /// </summary>
        public string CreditString { get; set; } = "신용카드";

        /// <summary>
        /// 청구금액 문자
        /// </summary>
        public string BillAmountString { get; set; } = "청구 금액";

        /// <summary>
        /// 고객번호 문자
        /// </summary>
        public string ContactString { get; set; } = "고객번호:";

        /// <summary>
        /// 고객주소 시작 구분문자
        /// </summary>
        public string AddressStartDelimiter { get; set; } = "고객주소:";

        /// <summary>
        /// 고객주소 종료 구분문자
        /// </summary>
        public string[] AddressEndDelimiters { get; set; } = new string[] { "주문메모:", "-----", null };

        /// <summary>
        /// 주문메모 시작 구분문자
        /// </summary>
        public string MemoStartDelimiter { get; set; } = "주문메모:";

        /// <summary>
        /// 주문메모 종료 구분문자
        /// </summary>
        public string[] MemoEndDelimiters { get; set; } = new string[] { "-----", null };

        /// <summary>
        /// 제품구분 문자
        /// </summary>
        public string ProductString { get; set; } = "-----------";

        /// <summary>
        /// 세트구성품 문자열
        /// </summary>
        public string[] SetMarkStrings { get; set; } = new string[] { "  -", "+" };

        public OrderModel Parse(string receiptText)
        {
            string[] textLines = receiptText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            OrderModel order = new OrderModel();
            order.OrderTime = ParseOrderTime(textLines);
            order.SubTotal = ParseSubTotal(textLines);
            order.Total = ParseTotal(textLines);
            order.CreditAmount = ParseCreditAmount(textLines);
            order.BillAmount = ParseBillAmount(textLines);
            order.Contact = ParseContact(textLines);
            order.Address = ParseAddress(textLines);
            order.Memo = ParseMemo(textLines);
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
        /// 소계 분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseSubTotal(string[] textLines)
        {
            // 소계 문자열로 검색
            string subTotal = StringUtil.FindByDelimiter(textLines, SubTotalString)?.Trim();
            logger.Information("ParseSubTotal {SubTotalText} {subTotal}", SubTotalString, subTotal);
            return subTotal;
        }

        /// <summary>
        /// 합계분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseTotal(string[] textLines)
        {
            // 합계 문자열로 검색
            string total = StringUtil.FindByDelimiter(textLines, TotalString)?.Trim();
            logger.Information("ParseTotal {TotalString} {total}", TotalString, total);
            return total;
        }

        /// <summary>
        /// 신용카드 분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseCreditAmount(string[] textLines)
        {
            // 신용카드 문자열로 검색
            string credit = StringUtil.FindByDelimiter(textLines, CreditString)?.Trim();
            logger.Information("ParseCreditAmount {CreditString} {credit}", CreditString, credit);
            return credit;
        }

        /// <summary>
        /// 청구금액 분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseBillAmount(string[] textLines)
        { 
            // 청구금액 문자열로 검색
            string billAmount = StringUtil.FindByDelimiter(textLines, BillAmountString)?.Trim();
            logger.Information("ParseCreditAmount {BillAmountString} {billAmount}", BillAmountString, billAmount);
            return billAmount;
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
            string address = null;
            foreach (string endDelimiter in AddressEndDelimiters)
            {
                address = StringUtil.FindByDelimiters(textLines, AddressStartDelimiter, endDelimiter,
                    includeDelimiter1Line: true,
                    includeDelimiter2Line: false,
                    removeDelimiter1: true,
                    removeDelimiter2: true);
                if (address != null)
                {
                    address = address.Trim();
                    logger.Information("ParseMemo {start} {end} {address}", AddressStartDelimiter, endDelimiter, address);
                    break;
                }
            }
            return address;
        }

        /// <summary>
        /// 메모분석
        /// </summary>
        /// <param name="textLines"></param>
        /// <returns></returns>
        public string ParseMemo(string[] textLines)
        {
            string memo = null;
            foreach (string endDelimiter in MemoEndDelimiters)
            {
                memo = StringUtil.FindByDelimiters(textLines, MemoStartDelimiter, endDelimiter,
                    includeDelimiter1Line: true,
                    includeDelimiter2Line: false,
                    removeDelimiter1: true,
                    removeDelimiter2: true);

                if (memo != null)
                {
                    memo = memo.Trim();
                    logger.Information("ParseMemo {start} {end} {memo}", MemoStartDelimiter, endDelimiter, memo);
                    break;
                }
            }
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

            // TODO Hint클래스 적용할 것
            // 제품문자열 검색
            string[] productTextLines = StringUtil.FindLinesByDelimiters(textLines, ProductString, 1, ProductString, 2,
                includeDelimiterLine1: false,
                includeDelimiterLine2: false);

            // 제품명, 수량, 가격 합치기
            string[] mergedProductTextLines = MergeProductText(productTextLines);
           
            List<ProductModel> productModels = new List<ProductModel>();

            foreach(var textLine in mergedProductTextLines)
            {
                // 제품
                if (!SetMarkStrings.Any(setMark => textLine.StartsWith(setMark)))
                {
                    // 제품전체 파트
                    string[] allParts = textLine.Split(' ').Where(x=> !string.IsNullOrWhiteSpace(x)).ToArray();

                    // 공백으로 구분시 끝에서부터 순서대로 가격, 수량, 제품명
                    string quantity;
                    string price;
                    string name;
                    if(allParts.Length < 3) // 이름, 수량, 가격 구성을 이루지 않음
                    {
                        price = string.Empty;
                        quantity = string.Empty;
                        name = string.Join(" ", allParts);
                    }
                    else
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
                    string setMark = SetMarkStrings.First(mark => textLine.StartsWith(mark));

                    ProductModel productModel = productModels.Last();
                    productModel.SetComponents.Add(textLine.Replace(setMark, ""));
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
             * */

            List<string> products = new List<string>();
            for (int i = 0; i < productTextLines.Length; i++)
            {
                string textLine = productTextLines[i];

                if (string.IsNullOrWhiteSpace(textLine))
                    continue;
                
                if (!string.IsNullOrWhiteSpace(textLine[0].ToString()))
                {
                    // 첫글자가 공백이 아닌 경우 제품1
                    string product = textLine.Trim();
                    products.Add(product);
                }
                else if(SetMarkStrings.Any(setMark => textLine.StartsWith(setMark)))
                {
                    // 세트구성품.
                    products.Add(textLine);
                }
                else
                {
                    // 제품2. 제품1과 결합한다.
                    var product2 = textLine.Trim();
                    var product = products.Last();
                    products[products.Count - 1] = string.Join(" ", product, product2);
                }
            }
            return products.ToArray();

        }



    }
}
