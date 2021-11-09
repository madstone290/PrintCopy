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
        public decimal FontSize 
        {
            get => numericUpDown1.Value;
            set => numericUpDown1.Value = value;
        }


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

            numericUpDown1.Minimum = 8;
            numericUpDown1.Maximum = 30;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
            printBtn.Click += PrintBtn_Click;

            FontSize = 10;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            labelTextEdit.Font = new Font(labelTextEdit.Font.FontFamily, Convert.ToSingle(FontSize));
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
