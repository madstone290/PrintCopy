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

namespace SimPrinter.DeskTop.Views
{
    public partial class UserSettingView : Form
    {
        /// <summary>
        /// 현재 수정 상태
        /// </summary>
        private bool editable = false;

        private readonly BindingList<ProductViewModel> pizzaList = new BindingList<ProductViewModel>();
        private readonly BindingList<ProductViewModel> sideDishList = new BindingList<ProductViewModel>();
        private readonly BindingList<ProductViewModel> noPrintList = new BindingList<ProductViewModel>();

        public UserSettingView()
        {
            InitializeComponent();

            pizzaGridView.DataSource = pizzaList;
            sideDishGridView.DataSource = sideDishList;
            noPrintGridView.DataSource = noPrintList;

            StartPosition = FormStartPosition.CenterParent;
            btnEdit.Click += BtnEdit_Click;
            Load += UserSettingView_Load;
        }

        private void UserSettingView_Load(object sender, EventArgs e)
        {
            if (!Program.SettingManager.TryLoad<주문설정>(out 주문설정 orderSetting))
            {
                orderSetting = 주문설정.Default;
            }
            foreach (var productName in orderSetting.피자목록 ?? new string[] { })
                pizzaList.Add(new ProductViewModel() { Name = productName });

            foreach (var productName in orderSetting.사이드목록 ?? new string[] { })
                sideDishList.Add(new ProductViewModel() { Name = productName });

            if (!Program.SettingManager.TryLoad<라벨설정>(out 라벨설정 labelSetting))
            {
                labelSetting = 라벨설정.Default;
            }
            foreach (var productName in labelSetting.미출력제품목록 ?? new string[] { })
                noPrintList.Add(new ProductViewModel() { Name = productName });


            SetEditable(false);

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // 수정상태인 경우 현재 설정 저장
            if (editable)
            {
                if (!Program.SettingManager.TryLoad<주문설정>(out 주문설정 orderSetting))
                {
                    orderSetting = 주문설정.Default;
                }

                orderSetting.피자목록 = pizzaList.Select(x => x.Name).ToArray();
                orderSetting.사이드목록 = sideDishList.Select(x => x.Name).ToArray();
                Program.SettingManager.Save(orderSetting);

                if (!Program.SettingManager.TryLoad<라벨설정>(out 라벨설정 labelSetting))
                {
                    labelSetting = 라벨설정.Default;
                }
                labelSetting.미출력제품목록 = noPrintList.Select(x => x.Name).ToArray();
                Program.SettingManager.Save(labelSetting);
            }

            SetEditable(!editable);
        }

        /// <summary>
        /// 수정상태 설정
        /// </summary>
        /// <param name="editable">수정 가능여부</param>
        private void SetEditable(bool editable)
        {
            pizzaGridView.ReadOnly = !editable;
            pizzaGridView.AllowUserToAddRows = editable;
            pizzaGridView.AllowUserToDeleteRows = editable;
            pizzaGridView.CurrentCell = null;

            sideDishGridView.ReadOnly = !editable;
            sideDishGridView.AllowUserToAddRows = editable;
            sideDishGridView.AllowUserToDeleteRows = editable;
            sideDishGridView.CurrentCell = null;

            noPrintGridView.ReadOnly = !editable;
            noPrintGridView.AllowUserToAddRows = editable;
            noPrintGridView.AllowUserToDeleteRows = editable;
            noPrintGridView.CurrentCell = null;

            btnEdit.Text = editable ? "저장" : "수정";

            this.editable = editable;
        }


    }
}
