
namespace SimPrinter.DeskTop
{
    partial class GeneralSettingView
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
            this.editBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.fontSizeEdit = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeEdit)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // editBtn
            // 
            this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editBtn.Location = new System.Drawing.Point(683, 3);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(60, 30);
            this.editBtn.TabIndex = 9;
            this.editBtn.Text = "저장";
            this.editBtn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.fontSizeEdit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 504);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "폰트 크기";
            // 
            // fontSizeEdit
            // 
            this.fontSizeEdit.Location = new System.Drawing.Point(94, 14);
            this.fontSizeEdit.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.fontSizeEdit.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fontSizeEdit.Name = "fontSizeEdit";
            this.fontSizeEdit.Size = new System.Drawing.Size(120, 21);
            this.fontSizeEdit.TabIndex = 9;
            this.fontSizeEdit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.editBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 468);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(746, 36);
            this.panel2.TabIndex = 12;
            // 
            // GeneralSettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GeneralSettingView";
            this.Size = new System.Drawing.Size(746, 504);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeEdit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown fontSizeEdit;
    }
}
