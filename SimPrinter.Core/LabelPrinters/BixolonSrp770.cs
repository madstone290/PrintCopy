using SimPrinter.Core.BixolonPrinter;
using SimPrinter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPrinter.Core.LabelPrinters
{
    public class BixolonSrp770 : ILabelPrinter
    {
        /// <summary>
        /// 용지 너비 mm
        /// </summary>
        const double PaperWidth = 99;

        /// <summary>
        /// 용지 높이 mm
        /// </summary>
        const double PaperHeight = 40;

        /// <summary>
        /// X축 마진
        /// </summary>
        const int MarginX = 1;

        /// <summary>
        /// Y축 마진
        /// </summary>
        const int MarginY = 1;

        /// <summary>
        /// 라벨번호 X위치 
        /// </summary>
        const int LabelNumberPosX = 80;

        /// <summary>
        /// 라벨번호 Y위치 
        /// </summary>
        const int LabelNumberPosY = 35;


        const int PrintDPI = 203;
        
        /// <summary>
        /// 한줄의 높이(mm)
        /// </summary>
        const int LineHeight = 3;

        // Interface Type
        public const int ISerial = 0;
        public const int IParallel = 1;
        public const int IUsb = 2;
        public const int ILan = 3;
        public const int IBluetooth = 5;



        /// <summary>
        /// 라벨 한장에 출력가능한 세트품목수
        /// </summary>
        public int SetItemMaxCount { get; set; } = 4;

        /// <summary>
        /// 라벨 한장에 출력가능한 기타품목수
        /// </summary>
        public int OtherItemMaxCount { get; set; } = 6;



        public void Print(OrderModel order)
        {
            if (order == null)
                return;

            PrintType1(order);
        }

        public void Print(string text)
        {
        }

        void PrintType1(OrderModel order)
        {
            if (!ConnectPrinter(out string message))
            {
                // todo 로그
                return;
            }

            SendPrinterSettingCommand(PaperWidth, PaperHeight, 0, 0);

            // 라벨번호 1부터
            int labelNumber = 1;

            // 피자
            var pizzas = order.Products.Where(x => x.Type == ProductType.Pizza);
            foreach (var pizza in pizzas)
            {
                for(int i = 0; i < pizza.Quantity; i++)
                    PrintPizza(order, pizza, ref labelNumber);
            }

            // 사이드 제품. 무시가능한 제품 제외.
            var sideDishes = order.Products.Where(x => x.Type == ProductType.Other)
                .Where(product => !ProductModel.IgnoreList.Contains(product.Name))
                .SelectMany(sd =>
                {
                    return new ProductModel[] { sd }.Concat(sd.SetItems);
                })
                .ToArray();

            PrintSideDishes(order, sideDishes, ref labelNumber);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }

        private void PrintPizza(OrderModel order, ProductModel pizza, ref int labelNumber)
        {
            // 처리된 세트아이템 번호
            int setItemIndex = 0;
       
            // 인쇄 끝
            bool endOfPrint = false;

            // 피자이름 인쇄여부. 피자이름은 1회만 인쇄한다.
            bool pizzaPrinted = false;

            while (!endOfPrint)
            {
                PrintText(MarginX, MarginY, order.Contact);
                PrintText(MarginX, MarginY + LineHeight * 1, order.Address);
                PrintText(MarginX, MarginY + LineHeight * 4, order.Memo);

                // 세트품목 인쇄위치(26)
                int printRawPosY;
                if (!pizzaPrinted)
                {
                    PrintText(MarginX, MarginY + LineHeight * 7, pizza.Name, bold: true, deviceFont: SLCS_DEVICE_FONT.KOR_24X24);
                    pizzaPrinted = true;

                    printRawPosY = MarginY + (LineHeight * 7) + 4;
                }
                else
                {
                    printRawPosY = MarginY + LineHeight * 7;
                }
              
                // 프린트열 번호
                int printRawIndex = 0;
                // 라벨끝
                bool endOfLabel = false; 
                while (!endOfLabel)
                {
                    var setItem = pizza.SetItems[setItemIndex];
                    PrintText(MarginX, printRawPosY + (LineHeight * printRawIndex), $"-{setItem.Name}  {setItem.Quantity}ea");
                    setItemIndex++;
                    printRawIndex++;
                    
                    endOfPrint = setItemIndex == pizza.SetItems.Count();
                    endOfLabel = endOfPrint || setItemIndex % SetItemMaxCount == 0;
                }

                PrintText(LabelNumberPosX, LabelNumberPosY, labelNumber.ToString(), bold: true);
                labelNumber++;

                //	Print Command
                BXLLApi.Prints(1, 1);
            }
        }

        private void PrintSideDishes(OrderModel order, ProductModel[] sideDishes, ref int labelNumber)
        {
            if (!sideDishes.Any())
                return;

            // 처리된 사이트메뉴 번호
            int sideDishIndex = 0;

            // 인쇄 끝
            bool endOfPrint = false;

            while (!endOfPrint)
            {
                PrintText(MarginX, MarginY, order.Contact);
                PrintText(MarginX, MarginY + LineHeight * 1, order.Address);
                PrintText(MarginX, MarginY + LineHeight * 4, order.Memo);

                // 사이드메뉴 인쇄위치(22)
                int printRawPosY = MarginY + LineHeight * 7; 
                // 프린트열 번호
                int printRawIndex = 0;
                // 라벨끝
                bool endOfLabel = false;
                while (!endOfLabel)
                {
                    var sideDish = sideDishes[sideDishIndex];
                    PrintText(MarginX, printRawPosY + (LineHeight * printRawIndex), $"{sideDish.Name}  {sideDish.Quantity}ea");
                    sideDishIndex++;
                    printRawIndex++;

                    endOfPrint = sideDishIndex == sideDishes.Count();
                    endOfLabel = endOfPrint || sideDishIndex % SetItemMaxCount == 0;
                }

                PrintText(LabelNumberPosX, LabelNumberPosY, labelNumber.ToString(), bold: true);
                labelNumber++;

                //	Print Command
                BXLLApi.Prints(1, 1);
            }
        }


        void PrintText(int posX, int posY, string text, int multiplier = 1, bool bold = false, SLCS_DEVICE_FONT deviceFont = SLCS_DEVICE_FONT.KOR_20X20)
        {
            int resolution = PrintDPI;
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);

            BXLLApi.PrintDeviceFont(
                posX * dotsPer1mm,
                posY * dotsPer1mm,
                (int)deviceFont,
                multiplier,
                multiplier,
                (int)SLCS_ROTATION.ROTATE_0,
                bold,
                text);
        }

        private bool ConnectPrinter(out string message)
        {
            string strPort = "";
            int nInterface = IUsb;
            int nBaudrate = 115200, nDatabits = 8, nParity = 0, nStopbits = 0;
            int nStatus = (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR;

            nStatus = BXLLApi.ConnectPrinterEx(nInterface, strPort, nBaudrate, nDatabits, nParity, nStopbits);

            if (nStatus != (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR)
            {
                BXLLApi.DisconnectPrinter();
                message = GetStatusMsg(nStatus);
                return false;
            }
            message = null;
            return true;
        }

        private string GetStatusMsg(int nStatus)
        {
            string errMsg = "";
            switch ((SLCS_ERROR_CODE)nStatus)
            {
                case SLCS_ERROR_CODE.ERR_CODE_NO_ERROR: errMsg = "No Error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_PAPER: errMsg = "Paper Empty"; break;
                case SLCS_ERROR_CODE.ERR_CODE_COVER_OPEN: errMsg = "Cover Open"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CUTTER_JAM: errMsg = "Cutter jammed"; break;
                case SLCS_ERROR_CODE.ERR_CODE_TPH_OVER_HEAT: errMsg = "TPH overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_AUTO_SENSING: errMsg = "Gap detection Error (Auto-sensing failure)"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_RIBBON: errMsg = "Ribbon End"; break;
                case SLCS_ERROR_CODE.ERR_CODE_BOARD_OVER_HEAT: errMsg = "Board overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_MOTOR_OVER_HEAT: errMsg = "Motor overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_WAIT_LABEL_TAKEN: errMsg = "Waiting for the label to be taken"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CONNECT: errMsg = "Port open error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_GETNAME: errMsg = "Unknown (or Not supported) printer name"; break;
                case SLCS_ERROR_CODE.ERR_CODE_OFFLINE: errMsg = "Offline (The printer is in an error status)"; break;
                default: errMsg = "Unknown error"; break;
            }
            return errMsg;
        }


        private void SendPrinterSettingCommand(double paperWidth, double paperHeight, double marginX, double marginY,
            int cmbDensity = 14, SLCS_ORIENTATION orientation = SLCS_ORIENTATION.TOP2BOTTOM,
            SLCS_MEDIA_TYPE sensorType = SLCS_MEDIA_TYPE.GAP, bool cut = false, bool directThermal = true)
        {
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int dotsPer1mm = (int)Math.Round((float)BXLLApi.GetPrinterDPI() / 25.4f);
            int nPaper_Width = Convert.ToInt32(paperWidth * dotsPer1mm);
            int nPaper_Height = Convert.ToInt32(paperHeight * dotsPer1mm);
            int nMarginX = Convert.ToInt32(marginX * dotsPer1mm);
            int nMarginY = Convert.ToInt32(marginY * dotsPer1mm);
            int nSpeed = (int)SLCS_PRINT_SPEED.PRINTER_SETTING_SPEED;
            int nDensity = cmbDensity;
            int nOrientation = (int)orientation;
            int nSensorType = (int)sensorType;

            //	Clear Buffer of Printer
            BXLLApi.ClearBuffer();

            //	Set Label and Printer
            BXLLApi.SetConfigOfPrinter(nSpeed, nDensity, nOrientation, cut, 1, true);

            // Select international character set and code table.To
            BXLLApi.SetCharacterset((int)SLCS_INTERNATIONAL_CHARSET.ICS_KOREA, (int)SLCS_CODEPAGE.FCP_CP437);

            /* 
                1 Inch : 25.4mm
                1 mm   :  7.99 Dots (XT5-40, SLP-TX400, SLP-DX420, SLP-DX220, SLP-DL410, SLP-T400, SLP-D420, SLP-D220, SRP-770/770II/770III)
                1 mm   :  7.99 Dots (SPP-L310, SPP-L410, SPP-L3000, SPP-L4000) 
                1 mm   :  7.99 Dots (XD3-40d, XD3-40t, XD5-40d, XD5-40t, XD5-40LCT)
                1 mm   : 11.81 Dots (XT5-43, SLP-TX403, SLP-DX423, SLP-DX223, SLP-DL413, SLP-T403, SLP-D423, SLP-D223)
                1 mm   : 11.81 Dots (XD5-43d, XD5-43t, XD5-43LCT)
                1 mm   : 23.62 Dots (XT5-46)
            */

            BXLLApi.SetPaper(nMarginX, nMarginY, nPaper_Width, nPaper_Height, nSensorType, 0, 2 * dotsPer1mm);

            // Direct thermal
            if (directThermal)
                BXLLApi.PrintDirect("STd", true);
            else // Thermal transfer
                BXLLApi.PrintDirect("STt", true);
        }

    }
}
