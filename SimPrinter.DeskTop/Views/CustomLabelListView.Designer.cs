
namespace SimPrinter.DeskTop.Views
{
    partial class CustomLabelListView
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printBtn = new System.Windows.Forms.Button();
            this.labelTextEdit = new System.Windows.Forms.RichTextBox();
            this.labelGridView = new System.Windows.Forms.DataGridView();
            this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.printBtn);
            this.panel1.Controls.Add(this.labelTextEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 176);
            this.panel1.TabIndex = 3;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(325, 58);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 1;
            this.printBtn.Text = "발행";
            this.printBtn.UseVisualStyleBackColor = true;
            // 
            // labelTextEdit
            // 
            this.labelTextEdit.Location = new System.Drawing.Point(3, 3);
            this.labelTextEdit.Name = "labelTextEdit";
            this.labelTextEdit.Size = new System.Drawing.Size(316, 163);
            this.labelTextEdit.TabIndex = 0;
            this.labelTextEdit.Text = "";
            // 
            // labelGridView
            // 
            this.labelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.labelGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCol,
            this.textCol,
            this.printCol});
            this.labelGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGridView.Location = new System.Drawing.Point(0, 176);
            this.labelGridView.Name = "labelGridView";
            this.labelGridView.RowTemplate.Height = 23;
            this.labelGridView.Size = new System.Drawing.Size(861, 406);
            this.labelGridView.TabIndex = 4;
            // 
            // idCol
            // 
            this.idCol.HeaderText = "순번";
            this.idCol.Name = "idCol";
            // 
            // textCol
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.textCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.textCol.HeaderText = "본문";
            this.textCol.Name = "textCol";
            this.textCol.Width = 300;
            // 
            // printCol
            // 
            this.printCol.HeaderText = "출력";
            this.printCol.Name = "printCol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "폰크 크기";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(399, 12);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 4;
            // 
            // CustomLabelListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelGridView);
            this.Controls.Add(this.panel1);
            this.Name = "CustomLabelListView";
            this.Size = new System.Drawing.Size(861, 582);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.RichTextBox labelTextEdit;
        private System.Windows.Forms.DataGridView labelGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn textCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn printCol;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}
