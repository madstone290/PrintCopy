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

        private readonly ProductDistinguisher productDistinguisher = new ProductDistinguisher();

        /// <summary>
        /// 제품 병합단계에서 세트품목을 나타내기위한 마크
        /// </summary>
        private const string SET_MARK = "-";

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
            order.Id = Guid.NewGuid();
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
                if (string.IsNullOrWhiteSpace(textLine))
                    continue;

                // 제품명, 수량, 가격 분석
                ParseNameQuantityPrice(textLine, out string productName, out decimal quantity, out decimal price);

                // 제품 유형분석
                ProductType productType = productDistinguisher.Distinguish(productName);

                ProductModel product = new ProductModel()
                {
                    Quantity = quantity,
                    Price = price,
                    Type = productType,
                };

                if (productType == ProductType.SetItem)
                {
                    product.Name = productName.Replace(SET_MARK, "");
                    productModels.Last().SetItems.Add(product);
                }
                else
                {
                    product.Name = productName;
                    productModels.Add(product);
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

                if (SetMarkStrings.Any(setMark => textLine.StartsWith(setMark)))
                {
                    // 세트구성품.
                    string setMark = SetMarkStrings.First(mark => textLine.StartsWith(mark));
                    string product = textLine.Replace(setMark, SET_MARK).Trim();
                    products.Add(product);
                }
                else if (!string.IsNullOrWhiteSpace(textLine[0].ToString()))
                {
                    // 첫글자가 공백이 아닌 경우 제품1
                    string product = textLine.Trim();
                    products.Add(product);
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

        private void ParseNameQuantityPrice(string text, out string name, out decimal quantity, out decimal price)
        {
            // 제품전체 파트
            string[] allParts = text.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            if (allParts.Length == 1) 
            {
                // 한 단어만 존재.
                name = allParts[0];
                quantity = 1;
                price = 0;
            }
            else if(allParts.Length == 2)
            {
                // 두 단어 존재. 이름 or 이름+가격
                quantity = 1;
                if (!decimal.TryParse(allParts[allParts.Length - 1], out price))
                {
                    name = string.Join(" ", allParts);
                }
                else
                {
                    name = allParts[0];
                }
            }
            else
            {
                // 3단어 이상 존재. 
                // 아래 패턴중 하나
                // 1. 이름 수량 가격
                // 2. 이름 가격
                // 3. 이름

                // 3번케이스. 가격 변환실패. 모든 파트가 이름. 
                if (!decimal.TryParse(allParts[allParts.Length - 1], out price))
                {
                    name = text;
                    quantity = 1;
                    return;
                }

                // 2번케이스. 수량 변환실패. 이부분까지 이름.
                if (!decimal.TryParse(allParts[allParts.Length - 2], out quantity))
                {
                    name = string.Join(" ", allParts.Take(allParts.Length - 1));
                    quantity = 1;
                    return;
                }

                // 1번케이스. 가격 및 수량 변환성공. 나머지 부분이 이름. 
                name = string.Join(" ", allParts.Take(allParts.Length - 2));
            }
        }



    }
}
