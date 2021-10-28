
namespace SimPrinter.DeskTop
{
    partial class FormSetting
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.labelPrinterPortSettingUC = new SimPrinter.DeskTop.PortSettingUC();
            this.normalPrinterPortSettingUC = new SimPrinter.DeskTop.PortSettingUC();
            this.inputPortSettingUC = new SimPrinter.DeskTop.PortSettingUC();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(666, 276);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 74);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "닫기";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(540, 276);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(120, 74);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "저장";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // labelPrinterPortSettingUC
            // 
            this.labelPrinterPortSettingUC.GroupTitle = "라벨 프린터";
            this.labelPrinterPortSettingUC.Location = new System.Drawing.Point(540, 12);
            this.labelPrinterPortSettingUC.Name = "labelPrinterPortSettingUC";
            this.labelPrinterPortSettingUC.Padding = new System.Windows.Forms.Padding(10);
            this.labelPrinterPortSettingUC.Size = new System.Drawing.Size(258, 258);
            this.labelPrinterPortSettingUC.TabIndex = 2;
            // 
            // normalPrinterPortSettingUC
            // 
            this.normalPrinterPortSettingUC.GroupTitle = "일반 프린터";
            this.normalPrinterPortSettingUC.Location = new System.Drawing.Point(276, 12);
            this.normalPrinterPortSettingUC.Name = "normalPrinterPortSettingUC";
            this.normalPrinterPortSettingUC.Padding = new System.Windows.Forms.Padding(10);
            this.normalPrinterPortSettingUC.Size = new System.Drawing.Size(258, 258);
            this.normalPrinterPortSettingUC.TabIndex = 1;
            // 
            // inputPortSettingUC
            // 
            this.inputPortSettingUC.GroupTitle = "입력 포트";
            this.inputPortSettingUC.Location = new System.Drawing.Point(12, 12);
            this.inputPortSettingUC.Name = "inputPortSettingUC";
            this.inputPortSettingUC.Padding = new System.Windows.Forms.Padding(10);
            this.inputPortSettingUC.Size = new System.Drawing.Size(258, 258);
            this.inputPortSettingUC.TabIndex = 0;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 361);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.labelPrinterPortSettingUC);
            this.Controls.Add(this.normalPrinterPortSettingUC);
            this.Controls.Add(this.inputPortSettingUC);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설정";
            this.ResumeLayout(false);

        }

        #endregion

        private PortSettingUC inputPortSettingUC;
        private PortSettingUC normalPrinterPortSettingUC;
        private PortSettingUC labelPrinterPortSettingUC;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonEdit;
    }
}