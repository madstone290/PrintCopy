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
        public static string FindByDelimiter(string[] textLines, string delimiter, bool removeDelimiter = true)
        {
            foreach (string text in textLines)
            {
                string result = FindByDelimiter(text, delimiter, removeDelimiter);
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
        /// 주어진 라인에서 구분자1, 구분자2 사이의 문자를 검색한다
        /// </summary>
        /// <param name="textLines"></param>
        /// <param name="delimiter1"></param>
        /// <param name="delimiter2"></param>
        /// <param name="removeDelimiter"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string FindByDelimiters(string[] textLines, string delimiter1, string delimiter2, 
            bool includeDelimiter1Line = true,
            bool includeDelimiter2Line = true,
            bool removeDelimiter1 = true,
            bool removeDelimiter2 = true, 
            string separator = " ")
        {
            string[] foundLines = FindLinesByDelimiters(textLines, delimiter1, delimiter2,
                includeDelimiter1Line, includeDelimiter2Line);
            
            // 유효한 결과가 존재할 경우
            if (foundLines != null && 0 < foundLines.Length)
            {
                if(includeDelimiter1Line && removeDelimiter1)
                    foundLines[0] = FindByDelimiter(foundLines[0], delimiter1, removeDelimiter1);

                if(includeDelimiter2Line && removeDelimiter2)
                    foundLines[foundLines.Length - 1] = FindByDelimiter(foundLines[foundLines.Length - 1], delimiter2, removeDelimiter2);
            }
            if (foundLines == null)
                return null;
            return string.Join(separator, foundLines);
        }

        /// <summary>
        /// 시작구분자와 종료구분자를 이용해 라인단위로 검색한다.
        /// </summary>
        /// <param name="textLines"></param>
        /// <param name="delimiter1"></param>
        /// <param name="delimiter2"></param>
        /// <param name="includeDelimiterLine1"></param>
        /// <param name="includeDelimiterLine2"></param>
        /// <returns></returns>
        public static string[] FindLinesByDelimiters(string[] textLines, string delimiter1, string delimiter2,  
            bool includeDelimiterLine1 = true, bool includeDelimiterLine2 = true)
        {
            int startLineIndex = FindLineIndex(textLines, delimiter1);
            int endLineIndex = delimiter2 != null 
                ? FindLineIndexFromStartIndex(textLines, delimiter2, startLineIndex)
                : textLines.Length - 1;

            // 검색결과 없음
            if (startLineIndex == -1 || endLineIndex == -1)
                return null;

            if (!includeDelimiterLine1)
                startLineIndex += 1;
            if (!includeDelimiterLine2 && delimiter2 != null)
                endLineIndex -= 1;

            List<string> filtered = new List<string>();
            for (int i = startLineIndex; i <= endLineIndex; i++)
            {
                filtered.Add(textLines[i]);
            }

            return filtered.ToArray();
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
        /// <param name="includeDelimiterLine1">구분자1이 포함된 라인을 결과물에 포함할것인가?</param>
        /// <param name="includeDelimiterLine2">구분자2가 포함된 라인을 결과물에 포함할것인가?</param>
        /// <returns></returns>
        public static string[] FindLinesByDelimiters(string[] textLines, string delimiter1, int order1, string delimiter2, int order2,
            bool includeDelimiterLine1 = true, bool includeDelimiterLine2 = true)
        {
            int startLineIndex = FindLineIndex(textLines, delimiter1, order1);
            int endLineIndex = delimiter2 != null ? FindLineIndex(textLines, delimiter2, order2) : textLines.Length - 1;

            // 검색결과 없음
            if (startLineIndex == -1 || endLineIndex == -1)
                return null;

            if (!includeDelimiterLine1)
                startLineIndex += 1;
            if (!includeDelimiterLine2 && delimiter2 != null)
                endLineIndex -= 1;

            List<string> filtered = new List<string>();
            for(int i = startLineIndex; i <= endLineIndex; i++)
            {
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
        public static int FindLineIndex(string[] textLines, string delimiter, int order = 0)
        {
            int[] indexes = FindLineIndexes(textLines, delimiter);
            if (order < indexes.Length)
                return indexes[order];
            return -1;
        }

        /// <summary>
        /// 구분자가 포함된 라인의 인덱스를 검색한다.
        /// </summary>
        /// <param name="textLines"></param>
        /// <param name="delimiter"></param>
        /// <param name="startIndex">검색 시작인덱스</param>
        /// <returns></returns>
        public static int FindLineIndexFromStartIndex(string[] textLines, string delimiter, int startIndex = 0)
        {
            int[] indexes = FindLineIndexes(textLines, delimiter)
                .Where(index=> startIndex <= index).ToArray();

            if (0 < indexes.Count())
                return indexes.First();
            return -1;
        }


        /// <summary>
        /// 구분자가 포함된 모든 라인을 검색한다
        /// </summary>
        /// <param name="textLines"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static int[] FindLineIndexes(string[] textLines, string delimiter)
        {
            if (textLines == null)
                return new int[] { };

            List<int> indexes = new List<int>();
            for (int i = 0; i < textLines.Length; i++)
            {
                if (textLines[i].Contains(delimiter))
                {
                    indexes.Add(i);
                }
            }
            return indexes.ToArray();
        }

    }
}
