using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    /// <summary>
    /// 출력물 구분기
    /// </summary>
    public class PrintoutDistinguisher
    {
        /// <summary>
        /// 구분문구
        /// </summary>
        private const string DISTINGUISH_PHRASE1 = "PIZZA ALVOLO";

        /// <summary>
        /// 출력물을 구분한다.
        /// </summary>
        /// <param name="printoutText">출력물 텍스트</param>
        /// <returns>출력물 유형</returns>
        public PrintoutType Distinguish(string printoutText)
        {
            // 첫번째 라인에서 문구 포함여부 확인

            string[] textLines = printoutText.TrimStart().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            PrintoutType printoutType = 0 < textLines.Length && textLines[0].Contains(DISTINGUISH_PHRASE1)
                ? PrintoutType.Order
                : PrintoutType.Other;

            return printoutType;
        }
    }
}
