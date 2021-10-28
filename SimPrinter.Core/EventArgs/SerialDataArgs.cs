using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.EventArgs
{
    /// <summary>
    /// 시리얼 데이터 인자
    /// </summary>
    public class SerialDataArgs
    {
        /// <summary>
        /// 데이터 버퍼
        /// </summary>
        public byte[] Buffer { get; }

        /// <summary>
        /// 버퍼 오프셋
        /// </summary>
        public int Offset { get; }
        
        /// <summary>
        /// 데이터 길이
        /// </summary>
        public int Length { get; }

        public SerialDataArgs(byte[] buffer, int offset, int length)
        {
            Buffer = buffer;
            Offset = offset;
            Length = length;
        }
    }
    
}
