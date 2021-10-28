using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimPrinter.DeskTop
{
    public static class UIThreadExtensions
    {
        /// <summary>
        /// cross thread 오류를 방지하기 위해 UI 쓰레드를 사용한다
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void UseUIThread(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action.Invoke();
            }
        }
    }
}
