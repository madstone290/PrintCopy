using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimPrinter.DeskTop
{
    public static class RichTextBoxExtensions
    {
        /// <summary>
        /// 텍스트 추가
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="maxLine"></param>
        public static void AddText(this RichTextBox box, string text, uint? maxLine = null)
        {
            if (text == null)
                return;

            /*max line check*/
            if (maxLine != null && maxLine > 0)
            {
                if (box.Lines.Count() >= maxLine)
                {
                    List<string> lines = box.Lines.ToList();
                    lines.RemoveAt(0); 
                    box.Lines = lines.ToArray();
                }
            }
            
            while(box.MaxLength < box.TextLength + text.Length)
            {
                List<string> lines = box.Lines.ToList();
                lines.RemoveAt(0);
                box.Lines = lines.ToArray();
            }

            box.AppendText(text);
        }


    }
}
