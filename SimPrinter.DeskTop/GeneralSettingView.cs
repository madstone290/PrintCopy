using SimPrinter.DeskTop.Models;
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
    public partial class GeneralSettingView : UserControl
    {
        private readonly SettingManager settingManager = Program.SettingManager;

        private bool isEditing;

        public GeneralSettingView()
        {
            InitializeComponent();
            
            SetEditable(false);

            editBtn.Click += EditBtn_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            if (DesignMode)
                return;

            GeneralSetting generalSetting = settingManager.Load<GeneralSetting>();
            fontSizeEdit.Value = Convert.ToDecimal(generalSetting.FontSize);
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                //TODO 설정저장
                GeneralSetting generalSetting = new GeneralSetting();
                generalSetting.FontSize = Convert.ToSingle(fontSizeEdit.Value);

                settingManager.Save(generalSetting);
            }

            SetEditable(!isEditing);
        }

   
        /// <summary>
        /// 수정상태 설정
        /// </summary>
        /// <param name="isEditing">수정상태</param>
        private void SetEditable(bool isEditing)
        {
            editBtn.Text = isEditing ? "저장" : "수정";

            this.isEditing = isEditing;

            fontSizeEdit.Enabled = isEditing;


        }
    }
}
