using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.EventArgs
{
    /// <summary>
    /// 바이트 분석 인자
    /// </summary>
    public class ByteParsingArgs
    {
        /// <summary>
        /// 원본 버퍼
        /// </summary>
        public byte[] RawBuffer { get; }

        /// <summary>
        /// 원본 버퍼 오프셋
        /// </summary>
        public int RawBufferOffset { get; }

        /// <summary>
        /// 원본 버퍼 길이
        /// </summary>
        public int RawBufferLength { get; }

        /// <summary>
        /// 원본버퍼 16진수 표현
        /// </summary>
        public string RawBufferHex { get; }

        /// <summary>
        /// 문자열버퍼
        /// </summary>
        public byte[] TextBuffer { get; }

        /// <summary>
        /// 문자열버퍼 오프셋
        /// </summary>
        public int TextBufferOffset { get; }

        /// <summary>
        /// 문자열버퍼 길이
        /// </summary>
        public int TextBufferLength { get; }

        /// <summary>
        /// 문자열버퍼 16진수 표현
        /// </summary>
        public string TextBufferHex { get; }

        /// <summary>
        /// 문자열
        /// </summary>
        public string Text { get; }

        public ByteParsingArgs(byte[] rawBuffer, int rawBufferOffset, int rawBufferLength, byte[] textBuffer, int textBufferOffset, int textBufferLength, string text)
        {
            RawBuffer = rawBuffer;
            RawBufferOffset = rawBufferOffset;
            RawBufferLength = rawBufferLength;
            RawBufferHex = BitConverter.ToString(rawBuffer, rawBufferOffset, rawBufferLength);

            TextBuffer = textBuffer;
            TextBufferOffset = textBufferOffset;
            TextBufferLength = textBufferLength;
            TextBufferHex = BitConverter.ToString(textBuffer, textBufferOffset, textBufferLength);

            Text = text;
        }
    }
}
