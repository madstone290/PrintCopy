
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
            this.printerPortSettingUC = new SimPrinter.DeskTop.PortSettingUC();
            this.inputPortSettingUC = new SimPrinter.DeskTop.PortSettingUC();
            this.useLabeSettingEdit = new System.Windows.Forms.CheckBox();
            this.useOrderSettingEdit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(402, 367);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 74);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "닫기";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(276, 367);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(120, 74);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "저장";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // printerPortSettingUC
            // 
            this.printerPortSettingUC.GroupTitle = "일반 프린터";
            this.printerPortSettingUC.Location = new System.Drawing.Point(276, 12);
            this.printerPortSettingUC.Name = "printerPortSettingUC";
            this.printerPortSettingUC.Padding = new System.Windows.Forms.Padding(10);
            this.printerPortSettingUC.Size = new System.Drawing.Size(258, 258);
            this.printerPortSettingUC.TabIndex = 1;
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
            // useLabeSettingEdit
            // 
            this.useLabeSettingEdit.AutoSize = true;
            this.useLabeSettingEdit.Location = new System.Drawing.Point(12, 285);
            this.useLabeSettingEdit.Name = "useLabeSettingEdit";
            this.useLabeSettingEdit.Size = new System.Drawing.Size(100, 16);
            this.useLabeSettingEdit.TabIndex = 5;
            this.useLabeSettingEdit.Text = "라벨설정 사용";
            this.useLabeSettingEdit.UseVisualStyleBackColor = true;
            // 
            // useOrderSettingEdit
            // 
            this.useOrderSettingEdit.AutoSize = true;
            this.useOrderSettingEdit.Location = new System.Drawing.Point(12, 316);
            this.useOrderSettingEdit.Name = "useOrderSettingEdit";
            this.useOrderSettingEdit.Size = new System.Drawing.Size(100, 16);
            this.useOrderSettingEdit.TabIndex = 6;
            this.useOrderSettingEdit.Text = "주문설정 사용";
            this.useOrderSettingEdit.UseVisualStyleBackColor = true;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 453);
            this.Controls.Add(this.useOrderSettingEdit);
            this.Controls.Add(this.useLabeSettingEdit);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.printerPortSettingUC);
            this.Controls.Add(this.inputPortSettingUC);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PortSettingUC inputPortSettingUC;
        private PortSettingUC printerPortSettingUC;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.CheckBox useLabeSettingEdit;
        private System.Windows.Forms.CheckBox useOrderSettingEdit;
    }
}