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
        /// ZPos 문구
        /// </summary>
        private const string ZPOS_PHRASE = "PIZZA ALVOLO";

        /// <summary>
        /// 대구로 문구
        /// </summary>
        private const string DAEGURO_PHRASE = "가맹점 명 :";

        /// <summary>
        /// 출력물을 구분한다.
        /// </summary>
        /// <param name="printoutText">출력물 텍스트</param>
        /// <returns>출력물 유형</returns>
        public PrintoutType Distinguish(string printoutText)
        {
            // 첫번째 라인에서 문구 포함여부 확인
            string[] textLines = printoutText.TrimStart().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            if (textLines.Length < 1)
                return PrintoutType.Other;

            if (textLines[0].Contains(ZPOS_PHRASE))
                return PrintoutType.ZPosOrder;

            if (textLines[0].Contains(DAEGURO_PHRASE))
                return PrintoutType.DaeguroOrder;

            return PrintoutType.Other;
        }
    }
}
