
namespace CuaHangBanSach
{
    partial class FormTimKiemSach
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTheLoai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.lblTenTacGia = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtTenTacGia = new System.Windows.Forms.TextBox();
            this.dgvTimSach = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimSach)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(623, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm Sách";
            // 
            // cmbTheLoai
            // 
            this.cmbTheLoai.FormattingEnabled = true;
            this.cmbTheLoai.Location = new System.Drawing.Point(674, 138);
            this.cmbTheLoai.Name = "cmbTheLoai";
            this.cmbTheLoai.Size = new System.Drawing.Size(230, 33);
            this.cmbTheLoai.TabIndex = 1;
            this.cmbTheLoai.SelectedIndexChanged += new System.EventHandler(this.cmbTheLoai_SelectedIndexChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimKiem.Location = new System.Drawing.Point(674, 215);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 61);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(134, 136);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(107, 25);
            this.lblTenSach.TabIndex = 4;
            this.lblTenSach.Text = "Tên sách:";
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Location = new System.Drawing.Point(567, 141);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(95, 25);
            this.lblTheLoai.TabIndex = 5;
            this.lblTheLoai.Text = "Thể loại:";
            // 
            // lblTenTacGia
            // 
            this.lblTenTacGia.AutoSize = true;
            this.lblTenTacGia.Location = new System.Drawing.Point(968, 141);
            this.lblTenTacGia.Name = "lblTenTacGia";
            this.lblTenTacGia.Size = new System.Drawing.Size(125, 25);
            this.lblTenTacGia.TabIndex = 6;
            this.lblTenTacGia.Text = "Tên tác giả:";
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(247, 136);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(314, 31);
            this.txtTenSach.TabIndex = 7;
            // 
            // txtTenTacGia
            // 
            this.txtTenTacGia.Location = new System.Drawing.Point(1099, 138);
            this.txtTenTacGia.Name = "txtTenTacGia";
            this.txtTenTacGia.Size = new System.Drawing.Size(286, 31);
            this.txtTenTacGia.TabIndex = 8;
            // 
            // dgvTimSach
            // 
            this.dgvTimSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimSach.Location = new System.Drawing.Point(139, 311);
            this.dgvTimSach.Name = "dgvTimSach";
            this.dgvTimSach.RowHeadersWidth = 82;
            this.dgvTimSach.RowTemplate.Height = 33;
            this.dgvTimSach.Size = new System.Drawing.Size(1246, 212);
            this.dgvTimSach.TabIndex = 9;
            // 
            // FormTimKiemSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 562);
            this.Controls.Add(this.dgvTimSach);
            this.Controls.Add(this.txtTenTacGia);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.lblTenTacGia);
            this.Controls.Add(this.lblTheLoai);
            this.Controls.Add(this.lblTenSach);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cmbTheLoai);
            this.Controls.Add(this.label1);
            this.Name = "FormTimKiemSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm sách";
            this.Load += new System.EventHandler(this.FormTimKiemSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTheLoai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.Label lblTenTacGia;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtTenTacGia;
        private System.Windows.Forms.DataGridView dgvTimSach;
    }
}