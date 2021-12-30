using SimPrinter.DeskTop.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimPrinter.DeskTop
{
    public partial class FormSetting : Form
    {
        /// <summary>
        /// 수정 진행여부
        /// </summary>
        private bool isEditing;

        public FormSetting()
        {
            InitializeComponent();

            buttonEdit.Click += ButtonEdit_Click;
            buttonClose.Click += ButtonClose_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            inputPortSettingUC.InitDataSource();
            printerPortSettingUC.InitDataSource();

            if (!Program.SettingManager.TryLoad<PortSetting>(out PortSetting setting))
                setting = PortSetting.Default;
            
            inputPortSettingUC.PortInfo = setting.AppPort;
            printerPortSettingUC.PortInfo = setting.PrinterPort;

            SetEditable(false);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            // 수정모드인 경우 포트설정 저장
            if (isEditing)
            {
                PortSetting portSetting = new PortSetting()
                {
                    AppPort = inputPortSettingUC.PortInfo,
                    PrinterPort = printerPortSettingUC.PortInfo
                };

                Program.SettingManager.Save(portSetting);
            }

            SetEditable(!isEditing);
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 수정상태 설정
        /// </summary>
        /// <param name="editable">수정 가능여부</param>
        private void SetEditable(bool editable)
        { 
            inputPortSettingUC.SetEditable(editable);
            printerPortSettingUC.SetEditable(editable);

            buttonEdit.Text = editable ? "저장" : "수정";

            isEditing = editable;


        }





    }
}
