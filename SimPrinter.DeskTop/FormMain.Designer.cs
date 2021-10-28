
namespace SimPrinter.DeskTop
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.binaryGridView = new System.Windows.Forms.DataGridView();
            this.orderNumberCol_Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawHexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderHexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textGridView = new System.Windows.Forms.DataGridView();
            this.oderNumberCol_Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printLabelBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.binaryGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Gulim", 12F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.orderGridView);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 531);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "주문목록";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.binaryGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(976, 531);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "시리얼 데이터";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // binaryGridView
            // 
            this.binaryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.binaryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumberCol_Serial,
            this.rawHexColumn,
            this.orderHexColumn});
            this.binaryGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binaryGridView.Location = new System.Drawing.Point(3, 3);
            this.binaryGridView.Name = "binaryGridView";
            this.binaryGridView.RowTemplate.Height = 23;
            this.binaryGridView.Size = new System.Drawing.Size(970, 525);
            this.binaryGridView.TabIndex = 0;
            // 
            // orderNumberCol_Serial
            // 
            this.orderNumberCol_Serial.DataPropertyName = "OrderNumber";
            this.orderNumberCol_Serial.HeaderText = "주문번호";
            this.orderNumberCol_Serial.Name = "orderNumberCol_Serial";
            // 
            // rawHexColumn
            // 
            this.rawHexColumn.DataPropertyName = "RawHex";
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rawHexColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.rawHexColumn.HeaderText = "원본 데이터";
            this.rawHexColumn.Name = "rawHexColumn";
            this.rawHexColumn.Width = 500;
            // 
            // orderHexColumn
            // 
            this.orderHexColumn.DataPropertyName = "OrderHex";
            this.orderHexColumn.HeaderText = "주문 데이터";
            this.orderHexColumn.Name = "orderHexColumn";
            this.orderHexColumn.Width = 500;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(976, 531);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "텍스트 데이터";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textGridView
            // 
            this.textGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.textGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oderNumberCol_Text,
            this.textColumn});
            this.textGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textGridView.Location = new System.Drawing.Point(3, 3);
            this.textGridView.Name = "textGridView";
            this.textGridView.RowTemplate.Height = 23;
            this.textGridView.Size = new System.Drawing.Size(970, 525);
            this.textGridView.TabIndex = 1;
            // 
            // oderNumberCol_Text
            // 
            this.oderNumberCol_Text.DataPropertyName = "OrderNumber";
            this.oderNumberCol_Text.HeaderText = "주문번호";
            this.oderNumberCol_Text.Name = "oderNumberCol_Text";
            // 
            // textColumn
            // 
            this.textColumn.DataPropertyName = "Text";
            this.textColumn.HeaderText = "주문 데이터";
            this.textColumn.Name = "textColumn";
            this.textColumn.Width = 500;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.printLabelBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 44);
            this.panel1.TabIndex = 2;
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
            this.orderGridView.Location = new System.Drawing.Point(3, 47);
            this.orderGridView.Name = "orderGridView";
            this.orderGridView.RowTemplate.Height = 23;
            this.orderGridView.Size = new System.Drawing.Size(970, 481);
            this.orderGridView.TabIndex = 3;
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
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.addressColumn.DefaultCellStyle = dataGridViewCellStyle6;
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
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.productDetailColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.productDetailColumn.HeaderText = "제품상세";
            this.productDetailColumn.Name = "productDetailColumn";
            this.productDetailColumn.Width = 300;
            // 
            // memoColumn
            // 
            this.memoColumn.DataPropertyName = "Memo";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.memoColumn.DefaultCellStyle = dataGridViewCellStyle8;
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormMain";
            this.Text = "심프린터";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.binaryGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView binaryGridView;
        private System.Windows.Forms.DataGridView textGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn oderNumberCol_Text;
        private System.Windows.Forms.DataGridViewTextBoxColumn textColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberCol_Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn rawHexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderHexColumn;
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

