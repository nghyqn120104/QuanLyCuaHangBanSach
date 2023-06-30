
namespace CuaHangBanSach
{
    partial class FormInHoaDonBan
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
            this.crpInHoaDon = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crpInHoaDon
            // 
            this.crpInHoaDon.ActiveViewIndex = -1;
            this.crpInHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crpInHoaDon.Cursor = System.Windows.Forms.Cursors.Default;
            this.crpInHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpInHoaDon.Location = new System.Drawing.Point(0, 0);
            this.crpInHoaDon.Name = "crpInHoaDon";
            this.crpInHoaDon.Size = new System.Drawing.Size(1500, 982);
            this.crpInHoaDon.TabIndex = 0;
            // 
            // FormInHoaDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 982);
            this.Controls.Add(this.crpInHoaDon);
            this.Name = "FormInHoaDonBan";
            this.Text = "FormInHoaDonBan";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crpInHoaDon;
    }
}