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

            orderGridView.ReadOnly = true;
            orderGridView.AutoGenerateColumns = false;
            orderGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            orderGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            orderGridView.DataSource = orderBindingList;
            orderGridView.RowHeaderMouseDoubleClick += OrderGridView_RowHeaderMouseDoubleClick;
            orderGridView.CellDoubleClick += OrderGridView_CellDoubleClick;


            printLabelBtn.Click += PrintLabelBtn_Click;
            settingManager.SettingSaved += SettingManager_SettingSaved;
           
        }

        public FormMain(Worker worker) : this()
        {
            this.worker = worker;
            this.worker.OrderCreated += Worker_OrderCreated;

            this.customLabelListView1.LabelPrinter = worker.LabelPrinter;
        }

        private void OrderGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            OrderViewModel selectedOrder = orderGridView.Rows[e.RowIndex].DataBoundItem as OrderViewModel;
            if (selectedOrder == null)
                return;

            worker.PrintLabel(selectedOrder.Id);
        }

        private void OrderGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderViewModel selectedOrder = orderGridView.Rows[e.RowIndex].DataBoundItem as OrderViewModel;
            if (selectedOrder == null)
                return;

            worker.PrintLabel(selectedOrder.Id);
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

            // 전역설정
            GeneralSetting setting = settingManager.Load<GeneralSetting>();
            ApplySetting(setting);

            // 그리드 설정
            GridSetting gridSetting = settingManager.Load<GridSetting>();
            if(gridSetting.OrderGridViewColumnWidth != null)
            {
                for(int i = 0; i < gridSetting.OrderGridViewColumnWidth.Length; i++)
                {
                    orderGridView.Columns[i].Width = gridSetting.OrderGridViewColumnWidth[i];
                }
            }
           
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // 그리드 설정 저장
            int[] columnWidths = new int[orderGridView.Columns.Count];
            int index = 0;
            foreach (DataGridViewColumn col in orderGridView.Columns)
            {
                columnWidths[index++] = col.Width;
            }

            GridSetting gridSetting = new GridSetting();
            gridSetting.OrderGridViewColumnWidth = columnWidths;

            settingManager.Save(gridSetting);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            DialogResult result = MessageBoxEx.Show(this, "종료하시겠습니까?", "확인", MessageBoxButtons.YesNo);

            e.Cancel = result != DialogResult.Yes;
        }

        /// <summary>
        /// 설정을 적용한다
        /// </summary>
        /// <param name="setting"></param>
        private void ApplySetting(GeneralSetting setting)
        {
            Font font = new Font(DataGridView.DefaultFont.FontFamily, setting.FontSize);

            orderGridView.ColumnHeadersDefaultCellStyle.Font = font;
            orderGridView.DefaultCellStyle.Font = font;
        }




    }
}
