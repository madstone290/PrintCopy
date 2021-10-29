using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.DeskTop.Settings
{
    /// <summary>
    /// 시리얼포트 설정
    /// </summary>
    public class PortSetting
    {
        private const int euckrCodepage = 51949;

        private const int cp949CodePage = 949;

        /// <summary>
        /// UTF8 인코딩
        /// </summary>
        public const string UTF8 = "UTF8";

        /// <summary>
        /// EUC-KR 인코딩
        /// </summary>
        public const string EUCKR = "EUCKR";

        /// <summary>
        /// CP949 인코딩
        /// </summary>
        public const string CP949 = "CP949";


        public string PortName { get; set; }

        public int BaudRate { get; set; } = 9600;

        public int DataBits { get; set; } = 7;

        public StopBits StopBits { get; set; } = StopBits.One;

        public Parity Parity { get; set; } = Parity.Even;

        public string EncodingText { get; set; } = CP949;

        public string NewLine { get; set; } = "\n";

        public Encoding GetEncoding()
        {
            switch (EncodingText)
            {
                case UTF8:
                    return Encoding.UTF8;
                case EUCKR:
                    return Encoding.GetEncoding(euckrCodepage);
                case CP949:
                    return Encoding.GetEncoding(cp949CodePage);
                default:
                    return Encoding.GetEncoding(cp949CodePage);
            }
        }

        /// <summary>
        /// 설정값 유효성 검사 실행
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool Validate(out string message)
        {
            if (string.IsNullOrWhiteSpace(PortName))
                message = "포트이름이 없습니다";
            else
                message = null;

            return message == null;
        }
    }
}
