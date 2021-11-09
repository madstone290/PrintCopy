using Serilog.Core;
using SimPrinter.Core.Logging;
using SimPrinter.Core.Models;
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
            string[] textLines = receiptText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

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
            string orderTime = FindByDelimiter(textLines, OrderTimeString).Trim();
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
            string contact = FindByDelimiter(textLines, ContactString).Trim();
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
            string address = FindByDelimiters(textLines, AddressString, ContactString).Trim();
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
            string memo = FindByDelimiters(textLines, Memo1String,  Memo2String).Trim();
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
            string memo = FindByDelimiters(textLines, Memo2String, OrderEndLineString).Trim();
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

            // TODO Hint클래스 적용할 것
            // 제품문자열 검색
            string[] productTextLines = FindLinesByDelimiters(textLines, ProductStartLineString, 0, ProductEndLineString, 1);

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

                    if(allParts[0] == DeliveryTip)  // 예외처리
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
                else if (textLine.StartsWith(SetComponentString))
                {
                    // 세트구성품. 세트구성품문자를 변경한다.
                    string component = SET_MARK + textLine.Replace(SetComponentString, "").Trim();
                    products.Add(component);
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



        /// <summary>
        /// 구분자로 문자열 검색 후 구분자가 제거된 문자열을 반환한다.
        /// 구분자 검색실패시 null반환.
        /// </summary>
        /// <param name="textLines"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        private string FindByDelimiter(string[] textLines, string delimiter)
        {
            foreach (string text in textLines)
            {
                string result = FindByDelimiter(text, delimiter);
                if (result != null)
                    return result;
            }
            return null;
        }

        /// <summary>
        /// 구분자로 문자열 검색 후 구분자가 제거된 문자열을 반환한다.
        /// 구분자 검색실패시 null반환.
        /// </summary>
        /// <param name="text">문자열</param>
        /// <param name="delimiter">구분자</param>
        /// <returns></returns>
        private string FindByDelimiter(string text, string delimiter, bool removeDelimiter = true)
        {
            if (delimiter == null)
                return null;

            int index = text.IndexOf(delimiter);

            if (-1 == index)
                return null;

            if (removeDelimiter)
                return text.Substring(index + delimiter.Length).Trim();
            else
                return text.Trim();
        }

        /// <summary>
        /// 시작구분자와 종료구분자사이 문자열을 검색한다.
        /// </summary>
        /// <param name="textLines"></param>
        /// <param name="delimiter1"></param>
        /// <param name="delimiter2"></param>
        /// <returns></returns>
        private string FindByDelimiters(string[] textLines, string delimiter1, string delimiter2)
        {
            // TODO 
            // 시작, 끝 구분 명확하게
            bool firstLineFound = false;
            List<string> resultText = new List<string>();
            foreach (string textLine in textLines)
            {
                if (!firstLineFound)
                {
                    string firstLine = FindByDelimiter(textLine, delimiter1);
                    if (firstLine != null)
                    {
                        // 처음 라인 추가
                        resultText.Add(firstLine);
                        firstLineFound = true;
                    }
                }
                else
                {
                    string lastLine = FindByDelimiter(textLine, delimiter2);
                    if (lastLine != null)
                        break;

                    // 마지막 라인전까지 모든 라인을 추가
                    resultText.Add(textLine);
                }

            }

            return resultText.Count == 0 ? null : string.Join(" ", resultText);
        }

        /// <summary>
        /// 시작구분자와 종료구분자를 이용해 라인단위로 검색한다.
        /// 순서는 0부터 시작한다.
        /// </summary>
        /// <param name="textLines">문자배열</param>
        /// <param name="delimiter1">구분자1</param>
        /// <param name="order1">구분자1 순서</param>
        /// <param name="delimiter2">구분자2</param>
        /// <param name="order2">구분자2 순서</param>
        /// <returns></returns>
        private string[] FindLinesByDelimiters(string[] textLines, string delimiter1, int order1, string delimiter2, int order2)
        {
            int startLine = FindIndex(textLines, delimiter1, order1);
            int endLine = FindIndex(textLines, delimiter2, order2);

            List<string> filtered = new List<string>();
            for (int i = 0; i < textLines.Length; i++)
            {
                if (startLine < i && i < endLine)
                    filtered.Add(textLines[i]);
            }

            return filtered.ToArray();
        }

        /// <summary>
        /// 구분자가 포함된 라인의 인덱스를 검색한다.
        /// 순서는 0부터 시작한다.
        /// </summary>
        /// <param name="textLines">문자열목록</param>
        /// <param name="delimiter">구분자</param>
        /// <param name="order">구분자순서</param>
        /// <returns></returns>
        private int FindIndex(string[] textLines, string delimiter, int order = 0)
        {
            for (int i = 0; i < textLines.Length; i++)
            {
                if (textLines[i].Contains(delimiter))
                {
                    if (order == 0)
                        return i;
                    order--;
                }
            }
            return -1;
        }
    }
}
