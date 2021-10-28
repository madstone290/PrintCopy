using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    /// <summary>
    /// 프린터 명령어를 제거한다.
    /// </summary>
    public class PrintCommandRemover
    {

        /// <summary>
        /// 프린트 명령어 제거
        /// </summary>
        /// <param name="array">명령어가 포함된 바이트배열</param>
        /// <returns>명령어가 제거된 바이트배열</returns>
        public byte[] Remove(byte[] array)
        {
            List<byte> byteList = new List<byte>(array);

            // 리스트 현재 위치
            int index = 0;

            while (true)
            {
                int count = byteList.Count;

                if (count <= index)
                    break;

                if(CommandContains(byteList, index, out int commandLength))
                {
                    // 커맨드 제거 후 현재 위치에서 검색시작.
                    byteList.RemoveRange(index, commandLength);
                }
                else
                {
                    // 커맨드 없음. 다음 위치에서 검색시작.
                    index += 1;
                }
            }

            return byteList.ToArray();
        }

        /// <summary>
        /// 커맨드 존재여부 확인
        /// </summary>
        /// <param name="byteList">바이트리스트</param>
        /// <param name="index">시작위치</param>
        /// <param name="commandLength">발견된 커맨드길이</param>
        /// <returns>커맨드 존재여부</returns>
        private bool CommandContains(List<byte> byteList, int index, out int commandLength)
        {
            
            Dictionary<int, byte[]> commandCache = new Dictionary<int, byte[]>(); // 명령어 길이별로 검색대상을 저장하는 캐시
            
            foreach(PrintCommand printCommand in PrintCommand.PrintCommandCollection)
            {
                if (!commandCache.TryGetValue(printCommand.TotalLength, out byte[] target))
                {
                    target = byteList.Skip(index).Take(printCommand.TotalLength).ToArray(); // 검색대상
                    commandCache.Add(printCommand.TotalLength, target);
                }

                // 바이트배열 검색
                if (ArrayUtil.ArrayEquals(target, printCommand.Code, printCommand.CodeLength))
                {
                    commandLength = printCommand.TotalLength;
                    return true;
                }
            }
            commandLength = 0;
            return false;
        }



    }
}
