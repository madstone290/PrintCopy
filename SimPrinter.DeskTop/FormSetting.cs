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

        /// <summary>
        /// 포트설정 관리자
        /// </summary>
        private PortSettingManager portSettingManager = PortSettingManager.Instance;

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
            normalPrinterPortSettingUC.InitDataSource();
           
            portSettingManager.Load();
            inputPortSettingUC.PortSetting = portSettingManager.AppPortSetting;
            normalPrinterPortSettingUC.PortSetting = portSettingManager.PrinterPortSetting;

            SetEditable(false);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            // 수정모드인 경우 포트설정 저장
            if (isEditing)
            {
                portSettingManager.SetPortSettings(inputPortSettingUC.PortSetting,
                                                   normalPrinterPortSettingUC.PortSetting);
                portSettingManager.Save();
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
            normalPrinterPortSettingUC.SetEditable(editable);

            buttonEdit.Text = editable ? "저장" : "수정";

            isEditing = editable;


        }





    }
}
