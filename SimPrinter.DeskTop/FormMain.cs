using SimPrinter.Core;
using SimPrinter.DeskTop.Models;
using SimPrinter.DeskTop.Settings;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SimPrinter.DeskTop
{
    public partial class FormMain : Form
    {
        private readonly Worker worker;

        public FormMain()
        {
            InitializeComponent();

            Program.SettingManager.SettingSaved += SettingManager_SettingSaved;
        }

        public FormMain(Worker worker) : this()
        {
            this.worker = worker;
            this.worker.OrderCreated += Worker_OrderCreated;

            this.orderView1.PrintLabel = (orderId) => worker.PrintLabel(orderId);
            this.customLabelListView1.LabelPrinter = worker.LabelPrinter;
        }

    
        private void Worker_OrderCreated(object sender, Core.EventArgs.OrderArgs e)
        {
            this.UseUIThread(() =>
            {
                var order = OrderViewModel.FromOrderModel(e.Order);
                orderView1.AddOrder(order);
            });
        }

        private void SettingManager_SettingSaved(object sender, object e)
        {
            if (e is GeneralSetting setting)
            {
                orderView1.ApplySetting(setting);
            }
        }
 
        protected override void OnLoad(EventArgs e)
        {
            worker.Restore(DateTime.Today);

            orderView1.OpenView(worker.Orders.Select(o => OrderViewModel.FromOrderModel(o)));
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            orderView1.CloseView();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            DialogResult result = MessageBoxEx.Show(this, "종료하시겠습니까?", "확인", MessageBoxButtons.YesNo);

            e.Cancel = result != DialogResult.Yes;
        }





    }
}
