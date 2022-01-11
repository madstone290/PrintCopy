
namespace SimPrinter.DeskTop.Views
{
    partial class UserSettingView
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pizzaGridView = new System.Windows.Forms.DataGridView();
            this.sideDishGridView = new System.Windows.Forms.DataGridView();
            this.noPrintGridView = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.Button();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noPrintColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sideDishColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pizzaGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideDishGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPrintGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 31);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.noPrintGridView);
            this.panel1.Controls.Add(this.sideDishGridView);
            this.panel1.Controls.Add(this.pizzaGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 419);
            this.panel1.TabIndex = 4;
            // 
            // pizzaGridView
            // 
            this.pizzaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pizzaGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn});
            this.pizzaGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.pizzaGridView.Location = new System.Drawing.Point(0, 0);
            this.pizzaGridView.Name = "pizzaGridView";
            this.pizzaGridView.RowTemplate.Height = 23;
            this.pizzaGridView.Size = new System.Drawing.Size(240, 419);
            this.pizzaGridView.TabIndex = 0;
            // 
            // sideDishGridView
            // 
            this.sideDishGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sideDishGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sideDishColumn});
            this.sideDishGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideDishGridView.Location = new System.Drawing.Point(240, 0);
            this.sideDishGridView.Name = "sideDishGridView";
            this.sideDishGridView.RowTemplate.Height = 23;
            this.sideDishGridView.Size = new System.Drawing.Size(240, 419);
            this.sideDishGridView.TabIndex = 1;
            // 
            // noPrintGridVIew
            // 
            this.noPrintGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.noPrintGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noPrintColumn});
            this.noPrintGridView.Dock = System.Windows.Forms.DockStyle.Left;
            this.noPrintGridView.Location = new System.Drawing.Point(480, 0);
            this.noPrintGridView.Name = "noPrintGridVIew";
            this.noPrintGridView.RowTemplate.Height = 23;
            this.noPrintGridView.Size = new System.Drawing.Size(240, 419);
            this.noPrintGridView.TabIndex = 2;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(3, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "수정";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameColumn.DataPropertyName = "Name";
            this.nameColumn.HeaderText = "피자이름";
            this.nameColumn.Name = "nameColumn";
            // 
            // noPrintColumn
            // 
            this.noPrintColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.noPrintColumn.DataPropertyName = "Name";
            this.noPrintColumn.HeaderText = "미출력";
            this.noPrintColumn.Name = "noPrintColumn";
            // 
            // sideDishColumn
            // 
            this.sideDishColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sideDishColumn.DataPropertyName = "Name";
            this.sideDishColumn.HeaderText = "사이드메뉴";
            this.sideDishColumn.Name = "sideDishColumn";
            // 
            // UserSettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "UserSettingView";
            this.Text = "UserSettingView";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pizzaGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideDishGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noPrintGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView pizzaGridView;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView noPrintGridView;
        private System.Windows.Forms.DataGridView sideDishGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noPrintColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sideDishColumn;
    }
}