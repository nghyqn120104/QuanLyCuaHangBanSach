using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanSach
{
    public partial class FormChiTietDonNhap : Form
    {
        DataProvider dataProvider= new DataProvider();
        private string tenSach;
        public FormChiTietDonNhap(string maHoaDon)
        {
            InitializeComponent();
            HienDuLieuTongQuat(maHoaDon);
        }

        private void HienDuLieuTongQuat(string maHoaDon)
        {
            lblTitle.Text = "Chi tiết mã hoá đơn " + maHoaDon;
            txtMaHoaDon.Text = maHoaDon;
            HienDuLieuChiTietDonNhap(maHoaDon);
            HienThiTongTienHoaDon(maHoaDon);
            HienThiTongSoLuongMatHang(maHoaDon);
        }

        private void HienThiTongSoLuongMatHang(string maHoaDon)
        {
            StringBuilder query = new StringBuilder("select count(*) from tblChiTiet_HD_NhapSach where sSoHDN= '" + maHoaDon + "'");
            int tongSoLuongMatHang= Convert.ToInt32(dataProvider.execScaler(query.ToString()));
            txtTongSoMatHang.Text = "Tổng số lượng mặt hàng trong hoá đơn là: " + tongSoLuongMatHang;
        }

        private void HienThiTongTienHoaDon(string maHoaDon)
        {
            StringBuilder query = new StringBuilder("select sum(fSoLuongNhap*fGiaNhap) from tblChiTiet_HD_NhapSach where sSoHDN= '" + maHoaDon + "'");
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

        private void HienDuLieuChiTietDonNhap(string maHoaDon)
        {
            DataTable dt= new DataTable();
            StringBuilder query= new StringBuilder("exec CTHDNhapSach");
            query.Append(" @MaHoaDon='" + maHoaDon + "'");
            dt=dataProvider.execQuery(query.ToString());
            dgvCTHDN.DataSource=dt;
        }

        public void HienDuLieuTenSach()
        {
            DataTable dt= new DataTable();
            StringBuilder query = new StringBuilder("select * from tblSach");
            dt = dataProvider.execQuery(query.ToString());
            cmbTenSach.DisplayMember = "sTenSach";
            cmbTenSach.ValueMember = "sMaSach";
            cmbTenSach.DataSource=dt;
        }

        private void cmbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox TenSach = sender as ComboBox;
            tenSach = TenSach.SelectedValue.ToString();
        }

        private void FormChiTietDonNhap_Load(object sender, EventArgs e)
        {
            HienDuLieuTenSach();
        }

        private void btonThem_Click(object sender, EventArgs e)
        {
            errLoi.SetError(nmrDonGia, "");
            errLoi.SetError(nmrSoLuong, "");
            if (nmrDonGia.Value == 0)
            {
                errLoi.SetError(nmrDonGia, "Bạn chưa đặt giá nhập sách");
                return;
            }

            if(nmrSoLuong.Value== 0)
            {
                errLoi.SetError(nmrSoLuong, "Bạn chưa đặt số lượng nhập sách");
                return;
            }

            StringBuilder query = new StringBuilder("exec ThemCTDN");
            query.Append(" @MaHoaDon ='" + txtMaHoaDon.Text + "'");
            query.Append(",@MaSach= " + tenSach);
            query.Append(",@SoLuongNhap =" + nmrSoLuong.Value);
            query.Append(",@GiaNhap= " + nmrDonGia.Value);
            int kq= dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuTongQuat(txtMaHoaDon.Text);
                MessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Lỗi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // @MaHoaDon nvarchar(20),@MaSach nvarchar(20),@SoLuongNhap float,@GiaNhap float

        private void btonSua_Click(object sender, EventArgs e)
        {
            errLoi.SetError(nmrDonGia, "");
            errLoi.SetError(nmrSoLuong, "");
            if (nmrDonGia.Value == 0)
            {
                errLoi.SetError(nmrDonGia, "Bạn chưa đặt giá nhập sách");
                return;
            }

            if (nmrSoLuong.Value == 0)
            {
                errLoi.SetError(nmrSoLuong, "Bạn chưa đặt số lượng nhập sách");
                return;
            }

            StringBuilder query= new StringBuilder("exec SuaCTDN");
            query.Append(" @MaHoaDon ='" + txtMaHoaDon.Text + "'");
            query.Append(",@MaSach= " + tenSach);
            query.Append(",@SoLuongNhap =" + nmrSoLuong.Value);
            query.Append(",@GiaNhap= " + nmrDonGia.Value);
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuTongQuat(txtMaHoaDon.Text);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Lỗi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btonXoa_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec XoaCTDN");
            query.Append(" @MaHoaDon ='" + txtMaHoaDon.Text + "'");
            query.Append(",@MaSach= " + tenSach);
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuTongQuat(txtMaHoaDon.Text);
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Lỗi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCTHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID= e.RowIndex;
            if(rowID <0)
            {
                rowID= 0;
            }

            if(rowID == dgvCTHDN.Rows.Count-1)
            {
                rowID -= 1;
            }

            DataGridViewRow row= dgvCTHDN.Rows[rowID];
            cmbTenSach.Text= row.Cells[1].Value.ToString();
            nmrDonGia.Value = Convert.ToInt32(row.Cells[3].Value);
            nmrSoLuong.Value = Convert.ToInt32(row.Cells[2].Value);
        }

        private void btnInPhieuBan_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("exec InCTDN");
            query.Append(" @maHoaDon= " + txtMaHoaDon.Text);
            dt = dataProvider.execQuery(query.ToString());
            ReportInHoaDonNhap report = new ReportInHoaDonNhap();
            report.SetDataSource(dt);
            FormInHoaDonNhap form = new FormInHoaDonNhap(report);
            form.ShowDialog();
        }
    }
}
