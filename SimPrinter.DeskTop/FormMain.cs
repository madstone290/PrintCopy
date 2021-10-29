using SimPrinter.Core;
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
    public partial class FormMain : Form
    {
        private readonly SettingManager settingManager = Program.SettingManager;
        private readonly Worker worker;

        private readonly BindingList<OrderViewModel> orderBindingList = new BindingList<OrderViewModel>();
        private readonly BindingList<BinaryDataModel> binaryBindingList = new BindingList<BinaryDataModel>();
        private readonly BindingList<TextDataModel> textBindingList = new BindingList<TextDataModel>();


        public FormMain()
        {
            InitializeComponent();

            orderBindingList.AllowNew = false;
            binaryBindingList.AllowNew = false;
            textBindingList.AllowNew = false;

            orderGridView.AutoGenerateColumns = false;
            orderGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            orderGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            orderGridView.DataSource = orderBindingList;

            binaryGridView.AutoGenerateColumns = false;
            binaryGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            binaryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            binaryGridView.DataSource = binaryBindingList;

            textGridView.AutoGenerateColumns = false;
            textGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            textGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            textGridView.DataSource = textBindingList;

            printLabelBtn.Click += PrintLabelBtn_Click;
            settingManager.SettingSaved += SettingManager_SettingSaved;
            orderBindingList.Add(new OrderViewModel() { Address = "sdfsdf", ProductDetail = "dfdfe아항ㅎ너ㅏㄴㅇ1개=\r\n아나가거 2개" });
        }



        public FormMain(Worker worker) : this()
        {
            this.worker = worker;
            this.worker.OrderCreated += Worker_OrderCreated;
        }

        private void Worker_OrderCreated(object sender, Core.EventArgs.OrderArgs e)
        {
            var order = OrderViewModel.FromOrderModel(e.Order);

            this.UseUIThread(() =>
            {
                orderBindingList.Add(order);

                binaryBindingList.Add(new BinaryDataModel()
                {
                    OrderNumber = e.Order.OrderNumber,
                    RawHex = e.RawHex,
                    OrderHex = e.OrderHex
                });

                textBindingList.Add(new TextDataModel()
                {
                    OrderNumber = e.Order.OrderNumber,
                    Text = e.OrderText,
                });
            });
        }

        private void PrintLabelBtn_Click(object sender, EventArgs e)
        {
            if (orderGridView.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("주문을 먼저 선택하세요");
                return;
            }

            OrderViewModel selectedOrder = orderGridView.SelectedRows[orderGridView.SelectedRows.Count - 1].DataBoundItem as OrderViewModel;
            worker.PrintLabel(selectedOrder.Id);
        }


        private void SettingManager_SettingSaved(object sender, object e)
        {
            if (e is GeneralSetting setting)
            {
                ApplySetting(setting);
            }
        }
 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            worker.Restore(DateTime.Today);

            foreach (var order in worker.Orders)
                orderBindingList.Add(OrderViewModel.FromOrderModel(order));

            // TODO load gridview settings
            GeneralSetting setting = settingManager.Load<GeneralSetting>();
            ApplySetting(setting);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // TODO save gridview settings
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            DialogResult result = MessageBoxEx.Show(this, "종료하시겠습니까?", "확인", MessageBoxButtons.YesNo);

            e.Cancel = result != DialogResult.Yes;
        }

        private void ApplySetting(GeneralSetting setting)
        {
            Font parentFont = tabControl1.Font;
            foreach (DataGridViewColumn column in orderGridView.Columns)
            {
                column.DefaultCellStyle.Font = new Font(parentFont.FontFamily, setting.FontSize);
            }

            foreach (DataGridViewColumn column in binaryGridView.Columns)
            {
                column.DefaultCellStyle.Font = new Font(parentFont.FontFamily, setting.FontSize);
            }

            foreach (DataGridViewColumn column in textGridView.Columns)
            {
                column.DefaultCellStyle.Font = new Font(parentFont.FontFamily, setting.FontSize);
            }
        }




    }
}
