using SimPrinter.Core;
using SimPrinter.DeskTop.Models;
using SimPrinter.DeskTop.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SimPrinter.DeskTop.Views
{
    public partial class OrderView : UserControl
    {
        private readonly BindingList<OrderViewModel> orderBindingList = new BindingList<OrderViewModel>();

        /// <summary>
        /// 주문ID로 라벨 인쇄
        /// </summary>
        public Action<Guid> PrintLabel { get; set; }

        public OrderView()
        {
            InitializeComponent();

            orderBindingList.AllowNew = false;

            orderGridView.ReadOnly = true;
            orderGridView.AutoGenerateColumns = false;
            orderGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            orderGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            orderGridView.DataSource = orderBindingList;
            orderGridView.CellDoubleClick += OrderGridView_CellDoubleClick;

            printLabelBtn.Click += PrintLabelBtn_Click;

        }

        private void PrintLabelBtn_Click(object sender, EventArgs e)
        {
            if (orderGridView.SelectedRows.Count == 0)
            {
                MessageBoxEx.Show("주문을 먼저 선택하세요");
                return;
            }

            OrderViewModel selectedOrder = orderGridView.SelectedRows[orderGridView.SelectedRows.Count - 1].DataBoundItem as OrderViewModel;
            PrintLabel?.Invoke(selectedOrder.Id);
        }

        private void OrderGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            OrderViewModel selectedOrder = orderGridView.Rows[e.RowIndex].DataBoundItem as OrderViewModel;
            if (selectedOrder == null)
                return;

            PrintLabel?.Invoke(selectedOrder.Id);
        }

        public void AddOrder(OrderViewModel order)
        {
            orderBindingList.Add(order);
        }

        public void OpenView(IEnumerable<OrderViewModel> orders)
        {
            foreach (var order in orders)
                orderBindingList.Add(order);

            // 전역설정
            GeneralSetting setting = Program.SettingManager.Load<GeneralSetting>();
            ApplySetting(setting);

            // 그리드 설정
            GridSetting gridSetting = Program.SettingManager.Load<GridSetting>();
            if (gridSetting.OrderGridViewColumnWidth != null)
            {
                for (int i = 0; i < gridSetting.OrderGridViewColumnWidth.Length; i++)
                {
                    orderGridView.Columns[i].Width = gridSetting.OrderGridViewColumnWidth[i];
                }
            }
        }

        public void CloseView()
        {
            // 그리드 설정 저장
            int[] columnWidths = new int[orderGridView.Columns.Count];
            int index = 0;
            foreach (DataGridViewColumn col in orderGridView.Columns)
            {
                columnWidths[index++] = col.Width;
            }

            GridSetting gridSetting = new GridSetting();
            gridSetting.OrderGridViewColumnWidth = columnWidths;

            Program.SettingManager.Save(gridSetting);
        }

        /// <summary>
        /// 설정을 적용한다
        /// </summary>
        /// <param name="setting"></param>
        public void ApplySetting(GeneralSetting setting)
        {
            Font font = new Font(DataGridView.DefaultFont.FontFamily, setting.FontSize);

            orderGridView.ColumnHeadersDefaultCellStyle.Font = font;
            orderGridView.DefaultCellStyle.Font = font;
        }
    }
}
