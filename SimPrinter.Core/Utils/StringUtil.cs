using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.Utils
{
    /// <summary>
    /// 문자열 편의기능 제공
    /// </summary>
    public class StringUtil
    {

        /// <summary>
        /// 구분자로 문자열 검색 후 구분자가 제거된 문자열을 반환한다.
        /// 구분자 검색실패시 null반환.
        /// </summary>
        /// <param name="textLines"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string FindByDelimiter(string[] textLines, string delimiter)
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
        public static string FindByDelimiter(string text, string delimiter, bool removeDelimiter = true)
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
        public static string FindByDelimiters(string[] textLines, string delimiter1, string delimiter2)
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
        public static string[] FindLinesByDelimiters(string[] textLines, string delimiter1, int order1, string delimiter2, int order2)
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
        public static int FindIndex(string[] textLines, string delimiter, int order = 0)
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
