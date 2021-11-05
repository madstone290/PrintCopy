using SimPrinter.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimPrinter.DeskTop.Views
{
    public partial class CustomLabelListView : UserControl
    {
        /// <summary>
        /// 라벨프린터
        /// </summary>
        public LabelPrinter LabelPrinter { get; set; }

        /// <summary>
        /// 라벨 본문
        /// </summary>
        public string LabelText => labelTextEdit.Text;

        public CustomLabelListView()
        {
            InitializeComponent();

            printBtn.Click += PrintBtn_Click;
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            if (LabelPrinter == null)
            {
                MessageBoxEx.Show("라벨프린터가 null입니다");
                return;
            }

            LabelPrinter.Print(LabelText);
        }
    }
}
