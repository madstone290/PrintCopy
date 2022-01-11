using SimPrinter.DeskTop.Views;
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
    public partial class FormStart : Form
    {
        /// <summary>
        /// 프로그램 시작여부
        /// </summary>
        public bool Start { get; private set; }

        /// <summary>
        /// 초기화 동작
        /// </summary>
        public Action InitializeAction { get; set; }

        public FormStart()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            buttonStart.Click += ButtonStart_Click;
            btnSysSetting.Click += ButtonSysSetting_Click;
            btnUserSetting.Click+= BtnUserSetting_Click;
            buttonClose.Click += ButtonClose_Click;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeAction.Invoke();

                Start = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonSysSetting_Click(object sender, EventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.ShowDialog();
        }

        private void BtnUserSetting_Click(object sender, EventArgs e)
        {
            UserSettingView view = new UserSettingView();
            view.ShowDialog();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Start = false;
            Close();
        }

    }
}
