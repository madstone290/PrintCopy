using SimPrinter.Core.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    /// <summary>
    /// 바이트 배열을 분석해서 영수증을 추출한다.
    /// </summary>
    public interface IByteParser
    {
        /// <summary>
        /// 분석이 완료되었다
        /// </summary>
        event EventHandler<ByteParsingArgs> ParsingCompleted;

        /// <summary>
        /// 시리얼데이터를 분석해서 영수증 데이터를 추출한다
        /// </summary>
        /// <param name="buffer">시리얼데이터 버퍼</param>
        /// <param name="offset">오프셋</param>
        /// <param name="length">길이</param>
        /// <returns></returns>
        void Parse(byte[] buffer, int offset, int length);
    }
}
