namespace SimPrinter.DeskTop.Views
{
    partial class OrderView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.orderGridView = new System.Windows.Forms.DataGridView();
            this.orderNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productDetailColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productTotalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printLabelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderGridView
            // 
            this.orderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumberColumn,
            this.orderTimeColumn,
            this.addressColumn,
            this.contactColumn,
            this.productDetailColumn,
            this.memoColumn,
            this.subTotalColumn,
            this.productTotalColumn,
            this.creditColumn,
            this.billAmountColumn});
            this.orderGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderGridView.Location = new System.Drawing.Point(0, 44);
            this.orderGridView.Name = "orderGridView";
            this.orderGridView.RowTemplate.Height = 23;
            this.orderGridView.Size = new System.Drawing.Size(886, 363);
            this.orderGridView.TabIndex = 5;
            // 
            // orderNumberColumn
            // 
            this.orderNumberColumn.DataPropertyName = "OrderNumber";
            this.orderNumberColumn.HeaderText = "주문번호";
            this.orderNumberColumn.Name = "orderNumberColumn";
            // 
            // orderTimeColumn
            // 
            this.orderTimeColumn.DataPropertyName = "OrderTime";
            this.orderTimeColumn.HeaderText = "주문시간";
            this.orderTimeColumn.Name = "orderTimeColumn";
            this.orderTimeColumn.Width = 180;
            // 
            // addressColumn
            // 
            this.addressColumn.DataPropertyName = "Address";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addressColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.addressColumn.HeaderText = "주소";
            this.addressColumn.Name = "addressColumn";
            this.addressColumn.Width = 300;
            // 
            // contactColumn
            // 
            this.contactColumn.DataPropertyName = "Contact";
            this.contactColumn.HeaderText = "연락처";
            this.contactColumn.Name = "contactColumn";
            this.contactColumn.Width = 150;
            // 
            // productDetailColumn
            // 
            this.productDetailColumn.DataPropertyName = "ProductDetail";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productDetailColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.productDetailColumn.HeaderText = "제품상세";
            this.productDetailColumn.Name = "productDetailColumn";
            this.productDetailColumn.Width = 300;
            // 
            // memoColumn
            // 
            this.memoColumn.DataPropertyName = "Memo";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.memoColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.memoColumn.HeaderText = "메모";
            this.memoColumn.Name = "memoColumn";
            this.memoColumn.Width = 200;
            // 
            // subTotalColumn
            // 
            this.subTotalColumn.DataPropertyName = "SubTotal";
            this.subTotalColumn.HeaderText = "소계";
            this.subTotalColumn.Name = "subTotalColumn";
            this.subTotalColumn.Width = 80;
            // 
            // productTotalColumn
            // 
            this.productTotalColumn.DataPropertyName = "Total";
            this.productTotalColumn.HeaderText = "합계";
            this.productTotalColumn.Name = "productTotalColumn";
            this.productTotalColumn.Width = 80;
            // 
            // creditColumn
            // 
            this.creditColumn.DataPropertyName = "Credit";
            this.creditColumn.HeaderText = "신용카드";
            this.creditColumn.Name = "creditColumn";
            this.creditColumn.Width = 80;
            // 
            // billAmountColumn
            // 
            this.billAmountColumn.DataPropertyName = "BillAmount";
            this.billAmountColumn.HeaderText = "청구금액";
            this.billAmountColumn.Name = "billAmountColumn";
            this.billAmountColumn.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.printLabelBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 44);
            this.panel1.TabIndex = 4;
            // 
            // printLabelBtn
            // 
            this.printLabelBtn.Location = new System.Drawing.Point(5, 3);
            this.printLabelBtn.Name = "printLabelBtn";
            this.printLabelBtn.Size = new System.Drawing.Size(125, 38);
            this.printLabelBtn.TabIndex = 0;
            this.printLabelBtn.Text = "라벨 발행";
            this.printLabelBtn.UseVisualStyleBackColor = true;
            // 
            // OrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.orderGridView);
            this.Controls.Add(this.panel1);
            this.Name = "OrderView";
            this.Size = new System.Drawing.Size(886, 407);
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView orderGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productDetailColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTotalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productTotalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn billAmountColumn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button printLabelBtn;
    }
}
