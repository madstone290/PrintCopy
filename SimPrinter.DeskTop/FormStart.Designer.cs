
namespace SimPrinter.DeskTop
{
    partial class FormStart
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.btnSysSetting = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.btnUserSetting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("굴림", 15F);
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(150, 70);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "시작";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // btnSysSetting
            // 
            this.btnSysSetting.Font = new System.Drawing.Font("굴림", 15F);
            this.btnSysSetting.Location = new System.Drawing.Point(168, 12);
            this.btnSysSetting.Name = "btnSysSetting";
            this.btnSysSetting.Size = new System.Drawing.Size(150, 70);
            this.btnSysSetting.TabIndex = 3;
            this.btnSysSetting.Text = "시스템 설정";
            this.btnSysSetting.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("굴림", 15F);
            this.buttonClose.Location = new System.Drawing.Point(480, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(150, 70);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "닫기";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // btnUserSetting
            // 
            this.btnUserSetting.Font = new System.Drawing.Font("굴림", 15F);
            this.btnUserSetting.Location = new System.Drawing.Point(324, 12);
            this.btnUserSetting.Name = "btnUserSetting";
            this.btnUserSetting.Size = new System.Drawing.Size(150, 70);
            this.btnUserSetting.TabIndex = 5;
            this.btnUserSetting.Text = "사용자 설정";
            this.btnUserSetting.UseVisualStyleBackColor = true;
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 121);
            this.Controls.Add(this.btnUserSetting);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.btnSysSetting);
            this.Controls.Add(this.buttonStart);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 160);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 160);
            this.Name = "FormStart";
            this.Text = "심프린터";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button btnSysSetting;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button btnUserSetting;
    }
}