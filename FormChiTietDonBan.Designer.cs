
namespace CuaHangBanSach
{
    partial class FormChiTietDonBan
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
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnInPhieuBan = new System.Windows.Forms.Button();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.nmrDonGia = new System.Windows.Forms.NumericUpDown();
            this.nmrSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cmbTenSach = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.btonXoa = new System.Windows.Forms.Button();
            this.btonSua = new System.Windows.Forms.Button();
            this.btonThem = new System.Windows.Forms.Button();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.dgvCTHDB = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTongTienHoaDon = new System.Windows.Forms.TextBox();
            this.txtTongSoMatHang = new System.Windows.Forms.TextBox();
            this.errLoi = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtMaHoaDonBan = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLoi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtMaHoaDonBan);
            this.panel3.Controls.Add(this.btnInPhieuBan);
            this.panel3.Controls.Add(this.lblMaHoaDon);
            this.panel3.Controls.Add(this.nmrDonGia);
            this.panel3.Controls.Add(this.nmrSoLuong);
            this.panel3.Controls.Add(this.cmbTenSach);
            this.panel3.Controls.Add(this.lblDonGia);
            this.panel3.Controls.Add(this.btonXoa);
            this.panel3.Controls.Add(this.btonSua);
            this.panel3.Controls.Add(this.btonThem);
            this.panel3.Controls.Add(this.lblSoLuong);
            this.panel3.Controls.Add(this.lblTenSach);
            this.panel3.Location = new System.Drawing.Point(113, 653);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1032, 195);
            this.panel3.TabIndex = 7;
            // 
            // btnInPhieuBan
            // 
            this.btnInPhieuBan.BackColor = System.Drawing.Color.DarkGray;
            this.btnInPhieuBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInPhieuBan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnInPhieuBan.Location = new System.Drawing.Point(816, 125);
            this.btnInPhieuBan.Name = "btnInPhieuBan";
            this.btnInPhieuBan.Size = new System.Drawing.Size(179, 54);
            this.btnInPhieuBan.TabIndex = 25;
            this.btnInPhieuBan.Text = "In phiếu bán";
            this.btnInPhieuBan.UseVisualStyleBackColor = false;
            this.btnInPhieuBan.Click += new System.EventHandler(this.btnInPhieuBan_Click);
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Location = new System.Drawing.Point(12, 24);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(132, 25);
            this.lblMaHoaDon.TabIndex = 23;
            this.lblMaHoaDon.Text = "Mã hoá đơn:";
            // 
            // nmrDonGia
            // 
            this.nmrDonGia.Location = new System.Drawing.Point(679, 69);
            this.nmrDonGia.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmrDonGia.Name = "nmrDonGia";
            this.nmrDonGia.Size = new System.Drawing.Size(215, 31);
            this.nmrDonGia.TabIndex = 22;
            // 
            // nmrSoLuong
            // 
            this.nmrSoLuong.Location = new System.Drawing.Point(295, 69);
            this.nmrSoLuong.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmrSoLuong.Name = "nmrSoLuong";
            this.nmrSoLuong.Size = new System.Drawing.Size(250, 31);
            this.nmrSoLuong.TabIndex = 21;
            // 
            // cmbTenSach
            // 
            this.cmbTenSach.FormattingEnabled = true;
            this.cmbTenSach.Location = new System.Drawing.Point(603, 18);
            this.cmbTenSach.Name = "cmbTenSach";
            this.cmbTenSach.Size = new System.Drawing.Size(287, 33);
            this.cmbTenSach.TabIndex = 20;
            this.cmbTenSach.SelectedIndexChanged += new System.EventHandler(this.cmbTenSach_SelectedIndexChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.Location = new System.Drawing.Point(581, 69);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(92, 25);
            this.lblDonGia.TabIndex = 19;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // btonXoa
            // 
            this.btonXoa.BackColor = System.Drawing.Color.DarkGray;
            this.btonXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonXoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btonXoa.Location = new System.Drawing.Point(603, 125);
            this.btonXoa.Name = "btonXoa";
            this.btonXoa.Size = new System.Drawing.Size(128, 54);
            this.btonXoa.TabIndex = 14;
            this.btonXoa.Text = "Xoá";
            this.btonXoa.UseVisualStyleBackColor = false;
            this.btonXoa.Click += new System.EventHandler(this.btonXoa_Click);
            // 
            // btonSua
            // 
            this.btonSua.BackColor = System.Drawing.Color.DarkGray;
            this.btonSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonSua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btonSua.Location = new System.Drawing.Point(359, 125);
            this.btonSua.Name = "btonSua";
            this.btonSua.Size = new System.Drawing.Size(128, 54);
            this.btonSua.TabIndex = 13;
            this.btonSua.Text = "Sửa";
            this.btonSua.UseVisualStyleBackColor = false;
            this.btonSua.Click += new System.EventHandler(this.btonSua_Click);
            // 
            // btonThem
            // 
            this.btonThem.BackColor = System.Drawing.Color.DarkGray;
            this.btonThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btonThem.Location = new System.Drawing.Point(72, 125);
            this.btonThem.Name = "btonThem";
            this.btonThem.Size = new System.Drawing.Size(128, 54);
            this.btonThem.TabIndex = 12;
            this.btonThem.Text = "Thêm";
            this.btonThem.UseVisualStyleBackColor = false;
            this.btonThem.Click += new System.EventHandler(this.btonThem_Click);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoLuong.Location = new System.Drawing.Point(178, 75);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(103, 25);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSach.Location = new System.Drawing.Point(492, 21);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(107, 25);
            this.lblTenSach.TabIndex = 1;
            this.lblTenSach.Text = "Tên sách:";
            // 
            // dgvCTHDB
            // 
            this.dgvCTHDB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTHDB.Location = new System.Drawing.Point(113, 137);
            this.dgvCTHDB.Name = "dgvCTHDB";
            this.dgvCTHDB.RowHeadersWidth = 82;
            this.dgvCTHDB.RowTemplate.Height = 33;
            this.dgvCTHDB.Size = new System.Drawing.Size(1553, 478);
            this.dgvCTHDB.TabIndex = 6;
            this.dgvCTHDB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTHDB_CellClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(844, 52);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 37);
            this.lblTitle.TabIndex = 8;
            // 
            // txtTongTienHoaDon
            // 
            this.txtTongTienHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienHoaDon.Location = new System.Drawing.Point(1162, 760);
            this.txtTongTienHoaDon.Name = "txtTongTienHoaDon";
            this.txtTongTienHoaDon.ReadOnly = true;
            this.txtTongTienHoaDon.Size = new System.Drawing.Size(504, 38);
            this.txtTongTienHoaDon.TabIndex = 9;
            // 
            // txtTongSoMatHang
            // 
            this.txtTongSoMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSoMatHang.Location = new System.Drawing.Point(1162, 668);
            this.txtTongSoMatHang.Name = "txtTongSoMatHang";
            this.txtTongSoMatHang.ReadOnly = true;
            this.txtTongSoMatHang.Size = new System.Drawing.Size(504, 35);
            this.txtTongSoMatHang.TabIndex = 10;
            // 
            // errLoi
            // 
            this.errLoi.ContainerControl = this;
            // 
            // txtMaHoaDonBan
            // 
            this.txtMaHoaDonBan.Location = new System.Drawing.Point(150, 18);
            this.txtMaHoaDonBan.Name = "txtMaHoaDonBan";
            this.txtMaHoaDonBan.ReadOnly = true;
            this.txtMaHoaDonBan.Size = new System.Drawing.Size(256, 31);
            this.txtMaHoaDonBan.TabIndex = 26;
            // 
            // FormChiTietDonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1823, 882);
            this.Controls.Add(this.txtTongSoMatHang);
            this.Controls.Add(this.txtTongTienHoaDon);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvCTHDB);
            this.Name = "FormChiTietDonBan";
            this.Text = "FormChiTietDonBan";
            this.Load += new System.EventHandler(this.FormChiTietDonBan_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errLoi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Button btonXoa;
        private System.Windows.Forms.Button btonSua;
        private System.Windows.Forms.Button btonThem;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.DataGridView dgvCTHDB;
        private System.Windows.Forms.NumericUpDown nmrDonGia;
        private System.Windows.Forms.NumericUpDown nmrSoLuong;
        private System.Windows.Forms.ComboBox cmbTenSach;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.TextBox txtTongTienHoaDon;
        private System.Windows.Forms.TextBox txtTongSoMatHang;
        private System.Windows.Forms.Button btnInPhieuBan;
        private System.Windows.Forms.ErrorProvider errLoi;
        private System.Windows.Forms.TextBox txtMaHoaDonBan;
    }
}