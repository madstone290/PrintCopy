using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    /// <summary>
    /// 제품유형 구별기
    /// </summary>
    public class ProductDistinguisher
    {

        /// <summary>
        /// 피자목록.
        /// 사이즈로 구분되지 않는 피자만 등록한다.
        /// 필요한 경우 모든 피자를 등록하여 사용가능하다.
        /// </summary>
        public string[] Pizzas { get; set; } = new string[]
        {
            "하프앤하프",
            "디럭스 콤비 피자",
            "스위트 고구마 피자",
            "트리플 치즈 피자",
            "하와이은 페페피자",
            "핫치킨 피자"
        };

        public string[] SideDishes { get; set; } = new string[]
        {
            "콘치즈그라탕"
        };

        /// <summary>
        /// 피자사이즈 문자열
        /// </summary>
        public string[] PizzaSizeStrings { get; set; } = new string[] { "R", "S", "L" };

        /// <summary>
        /// 세트아이템 표식문자
        /// </summary>
        public string[] SetItemMarkStrings { get; set; } = new string[] { " ▶", "  -", " -", "-", "+" };

        public ProductType Distinguish(string productName)
        {
            /*
             * 1. 피자명으로 구분
             * 2. 사이드메뉴명으로 구분
             * 3. 세트아이템 시작문자로 구분
             * 4. 피자사이즈 유무로 구분
             * */

            if (string.IsNullOrWhiteSpace(productName))
                return ProductType.SideDish;

            if (SetItemMarkStrings.Any(mark => productName.StartsWith(mark)))
                return ProductType.SetItem;

            if (SideDishes.Any(sideDish => productName.Contains(sideDish)))
                return ProductType.SideDish;

            if (Pizzas.Any(pizza => productName.Contains(pizza)))
                return ProductType.Pizza;

            string[] nameParts = productName.Split(' ');
            string pizzaSize = nameParts[nameParts.Length - 1];

            if (PizzaSizeStrings.Contains(pizzaSize))
                return ProductType.Pizza;
            else
                return ProductType.SideDish;
        }
    }
}
