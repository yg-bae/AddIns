
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
            this.GrpDockPosition = new System.Windows.Forms.GroupBox();
            this.LblNote_Dock = new System.Windows.Forms.Label();
            this.RdoDockRight = new System.Windows.Forms.RadioButton();
            this.RdoDockLeft = new System.Windows.Forms.RadioButton();
            this.GrpOkCancel = new System.Windows.Forms.GroupBox();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.GrpDockPosition.SuspendLayout();
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
            // GrpDockPosition
            // 
            this.GrpDockPosition.Controls.Add(this.LblNote_Dock);
            this.GrpDockPosition.Controls.Add(this.RdoDockRight);
            this.GrpDockPosition.Controls.Add(this.RdoDockLeft);
            this.GrpDockPosition.Location = new System.Drawing.Point(12, 45);
            this.GrpDockPosition.Name = "GrpDockPosition";
            this.GrpDockPosition.Size = new System.Drawing.Size(223, 60);
            this.GrpDockPosition.TabIndex = 7;
            this.GrpDockPosition.TabStop = false;
            this.GrpDockPosition.Text = "표시위치";
            // 
            // LblNote_Dock
            // 
            this.LblNote_Dock.AutoSize = true;
            this.LblNote_Dock.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblNote_Dock.Location = new System.Drawing.Point(3, 41);
            this.LblNote_Dock.Name = "LblNote_Dock";
            this.LblNote_Dock.Size = new System.Drawing.Size(141, 12);
            this.LblNote_Dock.TabIndex = 2;
            this.LblNote_Dock.Text = "※ 다음번 실행 시 적용됨";
            // 
            // RdoDockRight
            // 
            this.RdoDockRight.AutoSize = true;
            this.RdoDockRight.Location = new System.Drawing.Point(50, 17);
            this.RdoDockRight.Name = "RdoDockRight";
            this.RdoDockRight.Size = new System.Drawing.Size(59, 16);
            this.RdoDockRight.TabIndex = 1;
            this.RdoDockRight.Text = "오른쪽";
            this.RdoDockRight.UseVisualStyleBackColor = true;
            // 
            // RdoDockLeft
            // 
            this.RdoDockLeft.AutoSize = true;
            this.RdoDockLeft.Checked = true;
            this.RdoDockLeft.Location = new System.Drawing.Point(3, 17);
            this.RdoDockLeft.Name = "RdoDockLeft";
            this.RdoDockLeft.Size = new System.Drawing.Size(47, 16);
            this.RdoDockLeft.TabIndex = 0;
            this.RdoDockLeft.TabStop = true;
            this.RdoDockLeft.Text = "왼쪽";
            this.RdoDockLeft.UseVisualStyleBackColor = true;
            // 
            // GrpOkCancel
            // 
            this.GrpOkCancel.Controls.Add(this.BtnOk);
            this.GrpOkCancel.Controls.Add(this.BtnCancel);
            this.GrpOkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrpOkCancel.Location = new System.Drawing.Point(0, 182);
            this.GrpOkCancel.Name = "GrpOkCancel";
            this.GrpOkCancel.Size = new System.Drawing.Size(247, 42);
            this.GrpOkCancel.TabIndex = 8;
            this.GrpOkCancel.TabStop = false;
            // 
            // BtnOk
            // 
            this.BtnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnOk.Location = new System.Drawing.Point(94, 17);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 22);
            this.BtnOk.TabIndex = 8;
            this.BtnOk.Text = "확인";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCancel.Location = new System.Drawing.Point(169, 17);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 22);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "취소";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmOption
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(247, 224);
            this.ControlBox = false;
            this.Controls.Add(this.GrpOkCancel);
            this.Controls.Add(this.GrpDockPosition);
            this.Controls.Add(this.ChkAlwaysShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmOption";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Option";
            this.Shown += new System.EventHandler(this.FrmOption_Shown);
            this.GrpDockPosition.ResumeLayout(false);
            this.GrpDockPosition.PerformLayout();
            this.GrpOkCancel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox GrpDockPosition;
        private System.Windows.Forms.GroupBox GrpOkCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        public System.Windows.Forms.CheckBox ChkAlwaysShow;
        public System.Windows.Forms.RadioButton RdoDockRight;
        public System.Windows.Forms.RadioButton RdoDockLeft;
        private System.Windows.Forms.Label LblNote_Dock;
    }
}