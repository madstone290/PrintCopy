using SimPrinter.DeskTop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimPrinter.DeskTop
{
    public partial class PortSettingUC : UserControl
    {
        /// <summary>
        /// 그룹 타이틀
        /// </summary>
        public string GroupTitle { get => groupBox1.Text; set => groupBox1.Text = value; }

        public PortSettingModel PortSetting
        {
            get
            {
                return new PortSettingModel()
                {
                    PortName = (string)comboBoxPort.SelectedItem,
                    BaudRate = (int)comboBoxBaudRate.SelectedItem,
                    DataBits = (int)comboBoxDataBits.SelectedItem,
                    StopBits = (StopBits)comboBoxStopBits.SelectedItem,
                    Parity = (Parity)comboBoxParity.SelectedItem,
                    EncodingText = (string)comboBoxEncoding.SelectedItem,
                    NewLine = (string)comboBoxNewLine.SelectedItem
                };
            }
            set
            {
                if (value == null)
                    return;
                comboBoxPort.SelectedItem = value.PortName;
                comboBoxBaudRate.SelectedItem = value.BaudRate;
                comboBoxDataBits.SelectedItem = value.DataBits;
                comboBoxStopBits.SelectedItem = value.StopBits;
                comboBoxParity.SelectedItem = value.Parity;
                comboBoxEncoding.SelectedItem = value.EncodingText;
                comboBoxNewLine.SelectedItem = value.NewLine;
            }
        }

        public PortSettingUC()
        {
            InitializeComponent();
        }

        public void InitDataSource()
        {
            comboBoxPort.Items.AddRange(SerialPort.GetPortNames());

            comboBoxBaudRate.Items.AddRange(new object[] { 1200, 1800, 2400, 4800, 7200, 9600, 14400, 19200, 38400, 57600, 115200, 230400, 460800});
            comboBoxBaudRate.SelectedItem = 2400;

            comboBoxDataBits.Items.AddRange(new object[] { 4, 5, 6, 7, 8 });
            comboBoxDataBits.SelectedItem = 7;

            comboBoxStopBits.Items.AddRange(new object[] { StopBits.One, StopBits.OnePointFive, StopBits.Two });
            comboBoxStopBits.SelectedItem = StopBits.One;

            comboBoxParity.Items.AddRange(new object[] { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space });
            comboBoxParity.SelectedItem = Parity.Even;

            comboBoxEncoding.Items.AddRange(new object[] { PortSettingModel.CP949, PortSettingModel.UTF8, PortSettingModel.EUCKR});
            comboBoxEncoding.SelectedItem = PortSettingModel.CP949;

            comboBoxNewLine.Items.AddRange(new object[] { @"\n", @"\r\n" });
            comboBoxNewLine.SelectedItem = @"\n";
        }

        public void SetEditable(bool editable)
        {
            comboBoxPort.Enabled = editable;
            comboBoxBaudRate.Enabled = editable;
            comboBoxDataBits.Enabled = editable;
            comboBoxStopBits.Enabled = editable;
            comboBoxParity.Enabled = editable;
            comboBoxEncoding.Enabled = editable;
            comboBoxNewLine.Enabled = editable;
        }
    }
}

