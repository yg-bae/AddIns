
namespace AddIns.Code
{
    partial class FrmOption
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
            this.ChkAlwaysShow = new System.Windows.Forms.CheckBox();
            this.GrpDock = new System.Windows.Forms.GroupBox();
            this.RdoDockLeft = new System.Windows.Forms.RadioButton();
            this.RdoDockRight = new System.Windows.Forms.RadioButton();
            this.GrpOkCancel = new System.Windows.Forms.GroupBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.GrpDock.SuspendLayout();
            this.GrpOkCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChkAlwaysShow
            // 
            this.ChkAlwaysShow.AutoSize = true;
            this.ChkAlwaysShow.Location = new System.Drawing.Point(12, 12);
            this.ChkAlwaysShow.Name = "ChkAlwaysShow";
            this.ChkAlwaysShow.Size = new System.Drawing.Size(88, 16);
            this.ChkAlwaysShow.TabIndex = 4;
            this.ChkAlwaysShow.Text = "항상 보이기";
            this.ChkAlwaysShow.UseVisualStyleBackColor = true;
            // 
            // GrpDock
            // 
            this.GrpDock.Controls.Add(this.RdoDockRight);
            this.GrpDock.Controls.Add(this.RdoDockLeft);
            this.GrpDock.Location = new System.Drawing.Point(12, 45);
            this.GrpDock.Name = "GrpDock";
            this.GrpDock.Size = new System.Drawing.Size(231, 53);
            this.GrpDock.TabIndex = 7;
            this.GrpDock.TabStop = false;
            this.GrpDock.Text = "화면표시(도킹)";
            // 
            // RdoDockLeft
            // 
            this.RdoDockLeft.AutoSize = true;
            this.RdoDockLeft.Checked = true;
            this.RdoDockLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.RdoDockLeft.Location = new System.Drawing.Point(3, 17);
            this.RdoDockLeft.Name = "RdoDockLeft";
            this.RdoDockLeft.Size = new System.Drawing.Size(47, 33);
            this.RdoDockLeft.TabIndex = 0;
            this.RdoDockLeft.TabStop = true;
            this.RdoDockLeft.Text = "왼쪽";
            this.RdoDockLeft.UseVisualStyleBackColor = true;
            // 
            // RdoDockRight
            // 
            this.RdoDockRight.AutoSize = true;
            this.RdoDockRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.RdoDockRight.Location = new System.Drawing.Point(50, 17);
            this.RdoDockRight.Name = "RdoDockRight";
            this.RdoDockRight.Size = new System.Drawing.Size(59, 33);
            this.RdoDockRight.TabIndex = 1;
            this.RdoDockRight.Text = "오른쪽";
            this.RdoDockRight.UseVisualStyleBackColor = true;
            // 
            // GrpOkCancel
            // 
            this.GrpOkCancel.Controls.Add(this.BtnOk);
            this.GrpOkCancel.Controls.Add(this.BtnCancel);
            this.GrpOkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrpOkCancel.Location = new System.Drawing.Point(0, 179);
            this.GrpOkCancel.Name = "GrpOkCancel";
            this.GrpOkCancel.Size = new System.Drawing.Size(257, 42);
            this.GrpOkCancel.TabIndex = 8;
            this.GrpOkCancel.TabStop = false;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.Location = new System.Drawing.Point(179, 17);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 22);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "취소";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOk.Location = new System.Drawing.Point(104, 17);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 22);
            this.BtnOk.TabIndex = 8;
            this.BtnOk.Text = "확인";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // FrmOption
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(257, 221);
            this.ControlBox = false;
            this.Controls.Add(this.GrpOkCancel);
            this.Controls.Add(this.GrpDock);
            this.Controls.Add(this.ChkAlwaysShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmOption";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Option";
            this.Shown += new System.EventHandler(this.FrmOption_Shown);
            this.GrpDock.ResumeLayout(false);
            this.GrpDock.PerformLayout();
            this.GrpOkCancel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox GrpDock;
        private System.Windows.Forms.GroupBox GrpOkCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        public System.Windows.Forms.CheckBox ChkAlwaysShow;
        public System.Windows.Forms.RadioButton RdoDockRight;
        public System.Windows.Forms.RadioButton RdoDockLeft;
    }
}