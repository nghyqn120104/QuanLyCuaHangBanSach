
namespace CuaHangBanSach
{
    partial class FormInHoaDonNhap
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
            this.crpInHoaDonNhap = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crpInHoaDonNhap
            // 
            this.crpInHoaDonNhap.ActiveViewIndex = -1;
            this.crpInHoaDonNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpInHoaDonNhap.Cursor = System.Windows.Forms.Cursors.Default;
            this.crpInHoaDonNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpInHoaDonNhap.Location = new System.Drawing.Point(0, 0);
            this.crpInHoaDonNhap.Name = "crpInHoaDonNhap";
            this.crpInHoaDonNhap.Size = new System.Drawing.Size(1500, 982);
            this.crpInHoaDonNhap.TabIndex = 0;
            // 
            // FormInHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 982);
            this.Controls.Add(this.crpInHoaDonNhap);
            this.Name = "FormInHoaDonNhap";
            this.Text = "FormInHoaDonNhap";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpInHoaDonNhap;
    }
}