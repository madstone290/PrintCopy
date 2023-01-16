
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.customLabelListView1 = new SimPrinter.DeskTop.Views.CustomLabelListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.generalSettingView1 = new SimPrinter.DeskTop.GeneralSettingView();
            this.orderView1 = new SimPrinter.DeskTop.Views.OrderView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Gulim", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.orderView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "주문목록";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.customLabelListView1);
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(976, 534);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "라벨출력";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // customLabelListView1
            // 
            this.customLabelListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customLabelListView1.FontSize = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.customLabelListView1.LabelPrinter = null;
            this.customLabelListView1.Location = new System.Drawing.Point(3, 3);
            this.customLabelListView1.Name = "customLabelListView1";
            this.customLabelListView1.Size = new System.Drawing.Size(970, 528);
            this.customLabelListView1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.generalSettingView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(976, 534);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "설정";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // generalSettingView1
            // 
            this.generalSettingView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.generalSettingView1.Location = new System.Drawing.Point(3, 3);
            this.generalSettingView1.Name = "generalSettingView1";
            this.generalSettingView1.Size = new System.Drawing.Size(970, 528);
            this.generalSettingView1.TabIndex = 0;
            // 
            // orderView1
            // 
            this.orderView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderView1.Location = new System.Drawing.Point(3, 3);
            this.orderView1.Name = "orderView1";
            this.orderView1.Size = new System.Drawing.Size(970, 528);
            this.orderView1.TabIndex = 0;
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
            this.tabPage5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage4;
        private GeneralSettingView generalSettingView1;
        private System.Windows.Forms.TabPage tabPage5;
        private Views.CustomLabelListView customLabelListView1;
        private Views.OrderView orderView1;
    }
}

