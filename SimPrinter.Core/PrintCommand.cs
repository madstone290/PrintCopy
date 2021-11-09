using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core
{
    /// <summary>
    /// ESC/POS 프린터 커맨드.
    /// 명령어 코드 및 명령어 인자로 구성된다.
    /// 명령어 참조. https://escpos.readthedocs.io
    /// PDF 참조. http://www.sam4s.co.kr/files/DOWN/2019012393432_1.pdf
    /// </summary>
    public class PrintCommand
    {
        /// <summary>
        /// 명령어 코드
        /// </summary>
        public byte[] Code { get; }

        /// <summary>
        /// 코드 길이
        /// </summary>
        public int CodeLength { get; }

        /// <summary>
        /// 명령어 인자 길이
        /// </summary>
        public int ArgumentLength { get; }

        /// <summary>
        /// 명령어 전체길이
        /// </summary>
        public int TotalLength { get; }

        private PrintCommand(byte[] code, int argumentLength)
        {
            Code = code;
            CodeLength = code.Length;
            ArgumentLength = argumentLength;
            TotalLength = code.Length + argumentLength;
        }

        /// <summary>
        /// 프린트 명령어 목록
        /// </summary>
        public static PrintCommand[] PrintCommandCollection => new PrintCommand[]
        {
            // 프린터 정보
            PrinterId, TransmitStatus, TransmitPaperSensorStatus,

            // 폰트 설정
            Initialize, SelectPrintMode, UnderlineMode, ItalicsMode, EmphasisMode, SelectCharacterFont,
            SelectFontA, SelectFontC, SelectFontD, Rotation, SelectCharacterCodePage,
            UpsideDownMode, SetCpiMode, SelectCodePage, SelectCharacterSize, ReversePrintMode, SelectDoubleStrikeMode,

            // 이미지
            NVBitImage,

            // 용지 설정
            PartialCut, FullCut,Ejector, EnableAndDisableAutoCut, SelectCutModeAndCutPaper, PrintAndFeedPaperNLines, PrintAndFeedPaper,
        };

        #region 커스텀 명령어.
        
        /// <summary>
        /// 출력물 끝 커스텀명령어. 용지자르기 + 프린트모드 + NewLine으로 구성되어 있다.
        /// </summary>
        public static readonly PrintCommand EndOfPrintout = new PrintCommand(new byte[] { 0x1D, 0x56, 0x01, 0x1B, 0x21, 0x00, 0x0D, 0x0A }, 0);

        #endregion

        #region 프린터 정보 

        /// <summary>
        /// 프린터ID 조회
        /// </summary>
        public static readonly PrintCommand PrinterId = new PrintCommand(new byte[] { 0x1D, 0x49 }, 1);

        /// <summary>
        /// 전송상태 조회
        /// </summary>
        public static readonly PrintCommand TransmitStatus = new PrintCommand(new byte[] { 0x1D, 0x72 }, 1);

        /// <summary>
        /// 전송용지 센서상태 조회
        /// </summary>
        public static readonly PrintCommand TransmitPaperSensorStatus = new PrintCommand(new byte[] { 0x1B, 0x76 }, 0);

        #endregion

        #region 폰트

        /// <summary>
        /// 프린트 버퍼 초기화
        /// </summary>
        public static readonly PrintCommand Initialize = new PrintCommand(new byte[] { 0x1B, 0x40 }, 0);

        /// <summary>
        /// 프린터 선택
        /// </summary>
        public static readonly PrintCommand SelectPrintMode = new PrintCommand(new byte[] { 0x1B, 0x21 }, 1);

        /// <summary>
        /// 밑줄
        /// </summary>
        public static readonly PrintCommand UnderlineMode = new PrintCommand(new byte[] { 0x1B, 0x20 }, 1);

        /// <summary>
        /// 이탤릭체
        /// </summary>
        public static readonly PrintCommand ItalicsMode = new PrintCommand(new byte[] { 0x1B, 0x34 }, 1);

        /// <summary>
        /// 강조모드
        /// </summary>
        public static readonly PrintCommand EmphasisMode = new PrintCommand(new byte[] { 0x1B, 0x45 }, 1);

        /// <summary>
        /// 폰트선택
        /// </summary>
        public static readonly PrintCommand SelectCharacterFont = new PrintCommand(new byte[] { 0x1B, 0x4D }, 1);

        /// <summary>
        /// 폰트A선택
        /// </summary>
        public static readonly PrintCommand SelectFontA = new PrintCommand(new byte[] { 0x1B, 0x50 }, 0);

        /// <summary>
        /// 폰트C선택
        /// </summary>
        public static readonly PrintCommand SelectFontC = new PrintCommand(new byte[] { 0x1B, 0x54 }, 0);

        /// <summary>
        /// 폰트D선택
        /// </summary>
        public static readonly PrintCommand SelectFontD = new PrintCommand(new byte[] { 0x1B, 0x55 }, 0);

        /// <summary>
        /// 90도 회전
        /// </summary>
        public static readonly PrintCommand Rotation = new PrintCommand(new byte[] { 0x1B, 0x56 }, 1);

        /// <summary>
        /// 코드페이지선택
        /// </summary>
        public static readonly PrintCommand SelectCharacterCodePage = new PrintCommand(new byte[] { 0x1B, 0x74 }, 1);

        /// <summary>
        /// 상하반전
        /// </summary>
        public static readonly PrintCommand UpsideDownMode = new PrintCommand(new byte[] { 0x1B, 0x7B }, 1);

        /// <summary>
        /// CPI모드설정
        /// </summary>
        public static readonly PrintCommand SetCpiMode = new PrintCommand(new byte[] { 0x1B, 0xC1 }, 1);

        /// <summary>
        /// 코드페이지 선택
        /// </summary>
        public static readonly PrintCommand SelectCodePage = new PrintCommand(new byte[] { 0x1C, 0x7D, 0x26 }, 2);

        /// <summary>
        /// 문자크기선택
        /// </summary>
        public static readonly PrintCommand SelectCharacterSize = new PrintCommand(new byte[] { 0x1D, 0x21 }, 1);

        /// <summary>
        /// 프린트모드 반전
        /// </summary>
        public static readonly PrintCommand ReversePrintMode = new PrintCommand(new byte[] { 0x1D, 0x42 }, 1);

        /// <summary>
        /// 두줄긋기모드
        /// </summary>
        public static readonly PrintCommand SelectDoubleStrikeMode = new PrintCommand(new byte[] { 0x1B, 0x47 }, 1);

        #endregion

        #region 커서 위치. 사용하지 않음.

        #endregion

        #region 용지설정

        /// <summary>
        /// 부분자르기
        /// </summary>
        public static readonly PrintCommand PartialCut = new PrintCommand(new byte[] { 0x1B, 0x69 }, 0);

        /// <summary>
        /// 전체자르기
        /// </summary>
        public static readonly PrintCommand FullCut = new PrintCommand(new byte[] { 0x1B, 0x6D }, 0);

        /// <summary>
        /// 방출
        /// </summary>
        public static readonly PrintCommand Ejector = new PrintCommand(new byte[] { 0x1D, 0x65 }, 3);

        /// <summary>
        /// 자동자르기 설정
        /// </summary>
        public static readonly PrintCommand EnableAndDisableAutoCut = new PrintCommand(new byte[] { 0x1C, 0x7D, 0x60 }, 1);

        /// <summary>
        /// 자르기 모드 선택후 자르기
        /// </summary>
        public static readonly PrintCommand SelectCutModeAndCutPaper = new PrintCommand(new byte[] { 0x1D, 0x56 }, 1);

        /// <summary>
        /// 출력 후 용지공급
        /// </summary>
        public static readonly PrintCommand PrintAndFeedPaperNLines = new PrintCommand(new byte[] { 0x1B, 0x64 }, 1);

        /// <summary>
        /// 출력 후 용지공급
        /// </summary>
        public static readonly PrintCommand PrintAndFeedPaper = new PrintCommand(new byte[] { 0x1B, 0x4A }, 1);

        #endregion

        #region 레이아웃. 


        /// <summary>
        /// 우측 공백 설정
        /// </summary>
        public static readonly PrintCommand RightSideCharacterSpacing = new PrintCommand(new byte[] { 0x1B, 0x20 }, 1);

        /// <summary>
        /// 라인 공백
        /// </summary>
        public static readonly PrintCommand LineSpacing = new PrintCommand(new byte[] { 0x1B, 0x33 }, 1);

        /// <summary>
        /// 라인 공백을 1/6인치 설정
        /// </summary>
        public static readonly PrintCommand SelectOneSixthInchLineSpacing = new PrintCommand(new byte[] { 0x1B, 0x32 }, 0);

        /// <summary>
        /// 라인 공백을 1/8인치 설정
        /// </summary>
        public static readonly PrintCommand SelectOneEighthInchLineSpacing = new PrintCommand(new byte[] { 0x1B, 0x30 }, 0);

        /// <summary>
        /// 정렬 선택
        /// </summary>
        public static readonly PrintCommand SelectJustification = new PrintCommand(new byte[] { 0x1B, 0x61 }, 1);

        /// <summary>
        /// 좌측 마진
        /// </summary>
        public static readonly PrintCommand LeftMargin = new PrintCommand(new byte[] { 0x1D, 0x4C }, 2);

        /// <summary>
        /// 모션 유닛
        /// </summary>
        public static readonly PrintCommand MotionUnits = new PrintCommand(new byte[] { 0x1D, 0x50 }, 2);

        /// <summary>
        /// 프린트 영역 너비
        /// </summary>
        public static readonly PrintCommand PrintAreaWidth = new PrintCommand(new byte[] { 0x1D, 0x57 }, 2);

        #endregion

        #region 이미지 & 바코드

        /// <summary>
        /// NV 비트 이미지 출력
        /// </summary>
        public static readonly PrintCommand NVBitImage = new PrintCommand(new byte[] { 0x1C, 0x70 }, 2);

        #endregion

        #region Reliance 제품

        /// <summary>
        /// Reliance 실시간 상태
        /// </summary>
        public static readonly PrintCommand RelianceRealTimeStatus = new PrintCommand(new byte[] { 0x10, 0x04 }, 1);

        #endregion

        #region Phoenix 제품

        /// <summary>
        /// Phoenix 실시간 상태
        /// </summary>
        public static readonly PrintCommand PhoenixRealTimeStatus = new PrintCommand(new byte[] { 0x10, 0x04 }, 1);

        #endregion


    }
}
