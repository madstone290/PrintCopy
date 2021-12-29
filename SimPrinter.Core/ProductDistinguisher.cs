using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    public class ProductDistinguisher
    {
        /// <summary>
        /// 피자사이즈 문자열
        /// </summary>
        public string[] PizzaSizeStrings { get; set; } = new string[] { "R", "S", "L" };

        public ProductType Distinguish(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
                return ProductType.Other;

            if (productName.Contains("콘치즈그라탕"))
                return ProductType.Other;

            string[] nameParts = productName.Split(' ');
            string pizzaSize = nameParts[nameParts.Length - 1];

            if (PizzaSizeStrings.Contains(pizzaSize))
                return ProductType.Pizza;

            return ProductType.Other;
        }
    }
}
