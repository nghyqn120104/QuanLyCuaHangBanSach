using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanSach
{
    public partial class FormChiTietDonBan : Form
    {
        DataProvider dataProvider = new DataProvider();
        private string tenSach;
        string StrCon = @"Data Source=DESKTOP-HT298IF\SQLEXPRESS;Initial Catalog=QUANLYCUAHANGBANSACH;Integrated Security=True";
        public FormChiTietDonBan(string maHoaDonBan)
        {
            InitializeComponent();
            HienDuLieuTongQuat(maHoaDonBan);
        }

        private void HienDuLieuTongQuat(string maHoaDonBan)
        {
            lblTitle.Text = "Chi tiết hoá đơn " + maHoaDonBan;
            txtMaHoaDonBan.Text = maHoaDonBan;
            HienThiDuLieuCTDB(maHoaDonBan);
            HienThiTongSoMatHang(maHoaDonBan);
            HienThiTongTienHoaDon(maHoaDonBan);
        }

        private void HienThiTongSoMatHang(string maHoaDonBan)
        {
            StringBuilder query = new StringBuilder("select count(*) from tblChiTiet_HD_BanSach where sSoHD = '" + maHoaDonBan + "'");
            int tongSoMatHang = Convert.ToInt32(dataProvider.execScaler(query.ToString()));
            txtTongSoMatHang.Text = "Tổng số lượng mặt hàng trong hoá đơn là: " + tongSoMatHang;
        }

        private void HienThiTongTienHoaDon(string maHoaDonBan)
        {
            StringBuilder query = new StringBuilder("select sum(fSoLuongMua*fDonGia)");
            query.Append(" from tblChiTiet_HD_BanSach ");
            query.Append(" where sSoHD = '" + maHoaDonBan + "'");
            object tongTienHoaDon = dataProvider.execScaler(query.ToString());
            if (tongTienHoaDon == DBNull.Value)
            {
                txtTongTienHoaDon.Text = "Tổng số tiền hoá đơn là: 0";
            }
            else
            {
                tongTienHoaDon = Convert.ToInt32(dataProvider.execScaler(query.ToString()));
                txtTongTienHoaDon.Text = "Tổng số tiền hoá đơn là: " + tongTienHoaDon;
            }
        }

        private void FormChiTietDonBan_Load(object sender, EventArgs e)
        {
            HienDuLieuTenSach();
        }

        private void HienDuLieuTenSach()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select * from tblSach");
            dt = dataProvider.execQuery(query.ToString());
            cmbTenSach.DisplayMember = "sTenSach";
            cmbTenSach.ValueMember = "sMaSach";
            cmbTenSach.DataSource = dt;
        }

        private void HienThiDuLieuCTDB(string maHoaDonBan)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select sSoHD[Mã hoá đơn]");
            query.Append(",sTenSach[Tên sách]");
            query.Append(",fSoLuongMua[Số lượng]");
            query.Append(",tblChiTiet_HD_BanSach.fDonGia[Đơn giá]");
            query.Append(",(fSoLuongMua*tblChiTiet_HD_BanSach.fDonGia)[Thành tiền]");
            query.Append(" from tblSach,tblChiTiet_HD_BanSach");
            query.Append(" where tblSach.sMaSach=tblChiTiet_HD_BanSach.sMaSach and sSoHD='" + maHoaDonBan + "'");
            dt = dataProvider.execQuery(query.ToString());
            dgvCTHDB.DataSource = dt;
        }

        private void cmbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox TenSach = sender as ComboBox;
            tenSach = TenSach.SelectedValue.ToString();
        }

        private void btonThem_Click(object sender, EventArgs e)
        {
            errLoi.SetError(nmrDonGia, "");
            errLoi.SetError(nmrSoLuong, "");

            if (nmrSoLuong.Value == 0)
            {
                errLoi.SetError(nmrSoLuong, "Bạn chưa nhập số lượng sách");
                return;
            }

            if (nmrDonGia.Value == 0)
            {
                errLoi.SetError(nmrDonGia, "Bạn chưa nhập giá sách");
                return;
            }

            StringBuilder query = new StringBuilder("exec ThemChiTietHoaDon");
            query.Append(" @MaHoaDon= " + txtMaHoaDonBan.Text);
            query.Append(",@MaSach= " + tenSach);
            query.Append(",@SoLuongMua= " + nmrSoLuong.Value);
            query.Append(",@DonGia= " + nmrDonGia.Value);
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuTongQuat(txtMaHoaDonBan.Text);
                MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không thêm được", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btonSua_Click(object sender, EventArgs e)
        {
            errLoi.SetError(nmrDonGia, "");
            errLoi.SetError(nmrSoLuong, "");

            if (nmrSoLuong.Value == 0)
            {
                errLoi.SetError(nmrSoLuong, "Bạn chưa nhập số lượng sách");
                return;
            }

            if (nmrDonGia.Value == 0)
            {
                errLoi.SetError(nmrDonGia, "Bạn chưa nhập giá sách");
                return;
            }

            StringBuilder query = new StringBuilder("exec SuaCTHoaDonBan");
            query.Append(" @MaHoaDon= " +txtMaHoaDonBan.Text);
            query.Append(",@MaSach= " + tenSach);
            query.Append(",@SoLuongMua=" + nmrSoLuong.Value);
            query.Append(",@DonGia= " + nmrDonGia.Value);
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuTongQuat(txtMaHoaDonBan.Text);
                MessageBox.Show("Sửa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không sửa được", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btonXoa_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec XoaCTHoaDonBan");
            query.Append(" @MaHoaDon= " + txtMaHoaDonBan.Text);
            query.Append(",@MaSach= " + tenSach);
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuTongQuat(txtMaHoaDonBan.Text);
                MessageBox.Show("Xoá thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không xoá được", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCTHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            if (rowId < 0)
            {
                rowId = 0;
            }

            if (rowId == dgvCTHDB.Rows.Count - 1)
            {
                rowId -= 1;
            }

            DataGridViewRow row = dgvCTHDB.Rows[rowId];
            cmbTenSach.Text = row.Cells[1].Value.ToString();
            nmrSoLuong.Value = Convert.ToInt32(row.Cells[2].Value);
            nmrDonGia.Value = Convert.ToInt32(row.Cells[3].Value);
        }

        private void btnInPhieuBan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("exec HienThiDuLieuCTDB");
            query.Append(" @maHoaDon= "+txtMaHoaDonBan.Text);
            dt = dataProvider.execQuery(query.ToString());
            ReportInHoaDonBan report = new ReportInHoaDonBan();
            report.SetDataSource(dt);
            FormInHoaDonBan form = new FormInHoaDonBan(report);
            form.ShowDialog();
        }
    }
}
