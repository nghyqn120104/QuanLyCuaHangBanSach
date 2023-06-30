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
    public partial class FormMain : Form
    {
        DataProvider dataProvider = new DataProvider();
        string StrCon = @"Data Source=DESKTOP-HT298IF\SQLEXPRESS;Initial Catalog=QUANLYCUAHANGBANSACH;Integrated Security=True";
        private string MaLoai;

        public FormMain()
        {
            InitializeComponent();
        }

        private void CapNhatAll()
        {
            HienThiDuLieuSach();
            HienThiDuLieuTheLoai();
            ChonTheLoai();
            HienDuLieuHoaDonBan();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DuLieuSach();
            DuLieuTheLoai();
            DuLieuHoaDonBan();
            DuLieuHoaDonNhap();
        }

        // *Sách*
        private void DuLieuSach()
        {
            HienThiDuLieuSach();
            ChonTheLoai();
        }

        // Hiện thông tin về sách
        private void HienThiDuLieuSach()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select sMaSach[Mã sách]");
            query.Append(",sTheLoai[Thể loại]");
            query.Append(",sTenSach[Tên sách]");
            query.Append(",fDonGia[Đơn giá]");
            query.Append(",sTenTG[Tên tác giả]");
            query.Append(",iSoLuong[Số lượng]");
            query.Append(" from tblSach,tblTheLoai");
            query.Append(" where tblSach.sMaLoai=tblTheLoai.sMaLoai");
            dt = dataProvider.execQuery(query.ToString());
            DgvSach.DataSource = dt;
        }

        // Hiện ra thể loại để chọn
        private void ChonTheLoai()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select * from tblTheLoai");
            dt = dataProvider.execQuery(query.ToString());
            cmbTheLoai.DisplayMember = "sTheLoai";
            cmbTheLoai.ValueMember = "sMaLoai";
            cmbTheLoai.DataSource = dt;
        }

        // Sự kiện khi người dùng chọn vào 1 dòng dữ liệu bất lì
        private void DgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;

            if (rowID < 0)
            {
                rowID = 0;
            }

            if (rowID == DgvSach.Rows.Count - 1)
            {
                rowID -= 1;
            }

            DataGridViewRow row = DgvSach.Rows[rowID];
            txtMaSach.Text = row.Cells[0].Value.ToString();
            cmbTheLoai.Text = row.Cells[1].Value.ToString();
            txtTenSach.Text = row.Cells[2].Value.ToString();
            nmrDonGia.Value = Convert.ToInt32(row.Cells[3].Value);
            txtTenTacGia.Text = row.Cells[4].Value.ToString();
            nmrSoLuong.Value = (int)row.Cells[5].Value;
        }

        // Nút thêm của Dữ liệu sách
        private void btnThem_Click(object sender, EventArgs e)
        {
            errloi.SetError(txtMaSach, "");
            errloi.SetError(txtTenSach, "");
            errloi.SetError(txtTenTacGia, "");
            errloi.SetError(nmrDonGia, "");
            errloi.SetError(nmrSoLuong, "");

            if (txtMaSach.Text == "")
            {
                errloi.SetError(txtMaSach, "Chưa nhập mã sách");
                return;
            }

            if (txtTenSach.Text == "")
            {
                errloi.SetError(txtTenSach, "Bạn chưa nhập tên sách");
                return;
            }

            if (txtTenTacGia.Text == "")
            {
                errloi.SetError(txtTenTacGia, "Bạn chưa nhập tên tác giả");
                return;
            }

            if (nmrSoLuong.Value == 0)
            {
                errloi.SetError(nmrSoLuong, "Hãy nhập số lượng");
                return;
            }

            if (nmrDonGia.Value == 0)
            {
                errloi.SetError(nmrDonGia, "Hãy nhập giá sách");
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(StrCon))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("select * from tblSach where sMaSach= '" + txtMaSach.Text + "'", sqlCon);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    errloi.SetError(txtMaSach, "Mã sách này đã bị trùng");
                    return;
                }
            }

            StringBuilder query = new StringBuilder("exec ThemSach");
            query.Append(" @MaSach= '" + txtMaSach.Text + "'");
            query.Append(",@MaLoai= " + MaLoai);
            query.Append(",@TenSach= N'" + txtTenSach.Text + "'");
            query.Append(",@DonGia= " + nmrDonGia.Value);
            query.Append(",@TenTacGia= N'" + txtTenTacGia.Text + "'");
            query.Append(",@SoLuong= " + nmrSoLuong.Value);

            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienThiDuLieuSach();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hỗ trợ cho việc thêm dữ liệu sách bằng thể loại thay vì mã thể loại
        private void cmbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox theLoai = sender as ComboBox;
            MaLoai = theLoai.SelectedValue.ToString();
        }

        // Nút sửa dữ liệu sách
        private void btnSua_Click(object sender, EventArgs e)
        {
            errloi.SetError(txtMaSach, "");
            errloi.SetError(txtTenSach, "");
            errloi.SetError(txtTenTacGia, "");
            errloi.SetError(nmrDonGia, "");
            errloi.SetError(nmrSoLuong, "");

            if (txtMaSach.Text == "")
            {
                errloi.SetError(txtMaSach, "Chưa nhập mã sách");
                return;
            }

            if (txtTenSach.Text == "")
            {
                errloi.SetError(txtTenSach, "Bạn chưa nhập tên sách");
                return;
            }

            if (txtTenTacGia.Text == "")
            {
                errloi.SetError(txtTenTacGia, "Bạn chưa nhập tên tác giả");
                return;
            }

            if (nmrSoLuong.Value == 0)
            {
                errloi.SetError(nmrSoLuong, "Hãy nhập số lượng");
                return;
            }

            if (nmrDonGia.Value == 0)
            {
                errloi.SetError(nmrDonGia, "Hãy nhập giá sách");
                return;
            }

            StringBuilder query = new StringBuilder("exec SuaThongTinSach");
            query.Append(" @MaSach= '" + txtMaSach.Text + "'");
            query.Append(",@TenSach= N'" + txtTenSach.Text + "'");
            query.Append(",@DonGia= " + nmrDonGia.Value);
            query.Append(",@TenTacGia= N'" + txtTenTacGia.Text + "'");
            query.Append(",@MaLoai= " + MaLoai);
            query.Append(",@SoLuong= " + nmrSoLuong.Value);

            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienThiDuLieuSach();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // nút xoá dữ liệu sách
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắn chắn muốn xoá không ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            StringBuilder query = new StringBuilder("exec XoaDuLieuSach");
            query.Append(" @MaSach= '" + txtMaSach.Text + "'");

            int kq = dataProvider.execNonQuery(query.ToString());
            if (res == DialogResult.Yes)
            {
                HienThiDuLieuSach();
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không xoá được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // *Thể loại*
        private void DuLieuTheLoai()
        {
            HienThiDuLieuTheLoai();
        }

        // Hiện dữ liệu thể loại
        private void HienThiDuLieuTheLoai()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select sMaLoai[Mã thể loại],sTheLoai[Thể loại] from tblTheLoai");
            dt = dataProvider.execQuery(query.ToString());
            dgvTheLoai.DataSource = dt;
        }

        private void dgvTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowID = e.RowIndex;

            if (rowID < 0)
            {
                rowID = 0;
            }

            if (rowID == dgvTheLoai.RowCount - 1)
            {
                rowID -= 1;
            }

            DataGridViewRow row = dgvTheLoai.Rows[rowID];
            txtMaTheLoai.Text = row.Cells[0].Value.ToString();
            txtTheLoai.Text = row.Cells[1].Value.ToString();
        }

        private void butTheLoai_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec ThemTheLoaiSach");
            query.Append(" @MaTheLoai= '" + txtMaTheLoai.Text + "'");
            query.Append(",@TheLoai= N'" + txtTheLoai.Text + "'");
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                CapNhatAll();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butSua_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec SuaDuLieuTheLoai");
            query.Append(" @MaTheLoai= '" + txtMaTheLoai.Text + "'");
            query.Append(",@TheLoai=N'" + txtTheLoai.Text + "'");
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                CapNhatAll();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butXoa_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec XoaDuLieuTheLoai");
            query.Append(" @MaTheLoai= '" + txtMaTheLoai.Text + "'");
            query.Append(",@TheLoai=N'" + txtTheLoai.Text + "'");
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                CapNhatAll();
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không xoá được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // *Hoá đơn bán*
        private void DuLieuHoaDonBan()
        {
            HienDuLieuHoaDonBan();
        }

        private void HienDuLieuHoaDonBan()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select sSoHD[Mã hoá đơn]");
            query.Append(",dNgaylapHD[Ngày lập hoá đơn]");
            query.Append(",sTenKH[Tên khách hàng]");
            query.Append(",sSoDT[Số điện thoại khách hàng]");
            query.Append(",sTenNV[Tên nhân viên]");
            query.Append(" from tblHoaDon");
            dt = dataProvider.execQuery(query.ToString());
            dgvHoaDonBan.DataSource = dt;
        }

        private void dgvHoaDonBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;

            if (rowId < 0)
            {
                rowId = 0;
            }

            if (rowId == dgvHoaDonBan.RowCount - 1)
            {
                rowId -= 1;
            }

            DataGridViewRow row = dgvHoaDonBan.Rows[rowId];
            txtMaHoaDonBanSach.Text = row.Cells[0].Value.ToString();
            dtpNgayLapHoaDonBan.Value = DateTime.Parse(row.Cells[1].Value.ToString());
            txtTenKH.Text = row.Cells[2].Value.ToString();
            txtSDT.Text = row.Cells[3].Value.ToString();
            txtTenNV.Text = row.Cells[4].Value.ToString();
        }

        private void btonThem_Click(object sender, EventArgs e)
        {
            errloi.SetError(txtMaHoaDonBanSach, "");
            errloi.SetError(dtpNgayLapHoaDonBan, "");
            errloi.SetError(txtTenKH, "");
            errloi.SetError(txtTenNV, "");
            errloi.SetError(txtSDT, "");

            DateTime dtnow = DateTime.Now;
            if (txtMaHoaDonBanSach.Text == "")
            {
                errloi.SetError(txtMaHoaDonBanSach, "Bạn chưa nhập mã hoá đơn");
                return;
            }

            if(dtpNgayLapHoaDonBan.Value > dtnow)
            {
                errloi.SetError(dtpNgayLapHoaDonBan, "Ngày nhập không được lớn hơn ngày hiện tại ");
                return;
            }

            if (txtSDT.Text == "")
            {
                errloi.SetError(txtSDT, "Hãy nhập số đt");
                return;
            }

            if (txtTenKH.Text == "")
            {
                errloi.SetError(txtTenKH, "Hãy nhập tên khách hàng");
                return;
            }

            if (txtTenNV.Text == "")
            {
                errloi.SetError(txtTenNV, "Hãy nhập tên nhân viên");
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(StrCon))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("select * from tblHoaDon where sSoHD= '" + txtMaHoaDonBanSach.Text + "'", sqlCon);
                using(SqlDataReader reader= sqlCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        errloi.SetError(txtMaHoaDonBanSach, "Mã sách này đã bị trùng");
                        return;
                    }
                }
            }

            StringBuilder query = new StringBuilder("exec Them_Hoa_Don_Ban");
            query.Append(" @MaHoaDon= '" + txtMaHoaDonBanSach.Text + "'");
            query.Append(",@NgayLapHD= '" + dtpNgayLapHoaDonBan.Value + "'");
            query.Append(",@TenKhachHang= N'" + txtTenKH.Text + "'");
            query.Append(",@SoDT= '" + txtSDT.Text + "'");
            query.Append(",@TenNhanVien= N'" + txtTenNV.Text + "'");
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuHoaDonBan();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btonSua_Click(object sender, EventArgs e)
        {
            errloi.SetError(txtMaHoaDonBanSach, "");
            errloi.SetError(dtpNgayLapHoaDonBan, "");
            errloi.SetError(txtTenKH, "");
            errloi.SetError(txtTenNV, "");
            errloi.SetError(txtSDT, "");

            DateTime dtnow = DateTime.Now;
            if (txtMaHoaDonBanSach.Text == "")
            {
                errloi.SetError(txtMaHoaDonBanSach, "Bạn chưa nhập mã hoá đơn");
                return;
            }

            if (dtpNgayLapHoaDonBan.Value > dtnow)
            {
                errloi.SetError(dtpNgayLapHoaDonBan, "Ngày nhập không được lớn hơn ngày hiện tại ");
                return;
            }

            if (txtSDT.Text == "")
            {
                errloi.SetError(txtSDT, "Hãy nhập số đt");
                return;
            }

            if (txtTenKH.Text == "")
            {
                errloi.SetError(txtTenKH, "Hãy nhập tên khách hàng");
                return;
            }

            if (txtTenNV.Text == "")
            {
                errloi.SetError(txtTenNV, "Hãy nhập tên nhân viên");
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(StrCon))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("select * from tblHoaDon where sSoHD= '" + txtMaHoaDonBanSach.Text + "'", sqlCon);
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        errloi.SetError(txtMaHoaDonBanSach, "Mã sách này đã bị trùng");
                        return;
                    }
                }
            }

            StringBuilder query = new StringBuilder("exec Sua_Hoa_Don_Ban");
            query.Append(" @MaHoaDon= '" + txtMaHoaDonBanSach.Text + "'");
            query.Append(",@NgayLapHD= '" + dtpNgayLapHoaDonBan.Value + "'");
            query.Append(",@TenKhachHang= N'" + txtTenKH.Text + "'");
            query.Append(",@SoDT= '" + txtSDT.Text + "'");
            query.Append(",@TenNhanVien= N'" + txtTenNV.Text + "'");
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuHoaDonBan();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btonXoa_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec Xoa_Hoa_Don_Ban");
            query.Append(" @MaHoaDon= '" + txtMaHoaDonBanSach.Text + "'");
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuHoaDonBan();
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không xoá được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        // *Hoá đơn nhập*
        private void DuLieuHoaDonNhap()
        {
            HienDuLieuHoaDonNhap();
        }

        private void HienDuLieuHoaDonNhap()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select sSoHDN[Mã hoá đơn]");
            query.Append(",dNgayNhap[Ngày nhập hàng]");
            query.Append(",sTenNCC[Tên nhà cung cấp]");
            query.Append(",sTenNV[Tên nhân viên]");
            query.Append(" from tblDonNhap");
            dt = dataProvider.execQuery(query.ToString());
            dgvHoaDonNhap.DataSource = dt;
        }

        private void bton_Them_Click(object sender, EventArgs e)
        {
            errloi.SetError(txtMaHoaDonNhap, "");
            errloi.SetError(dtpNgayLapHoaDonNhap, "");
            errloi.SetError(txtTenNCC, "");
            errloi.SetError(textNV, "");

            DateTime dtnow = DateTime.Now;
            if (txtMaHoaDonNhap.Text == "")
            {
                errloi.SetError(txtMaHoaDonNhap, "Bạn chưa nhập mã hoá đơn");
                return;
            }

            if (dtpNgayLapHoaDonNhap.Value > dtnow)
            {
                errloi.SetError(dtpNgayLapHoaDonNhap, "Ngày nhập không được lớn hơn ngày hiện tại ");
                return;
            }

            if (txtTenNCC.Text == "")
            {
                errloi.SetError(txtTenNCC, "Hãy nhập tên nhà cung cấp");
                return;
            }

            if (textNV.Text == "")
            {
                errloi.SetError(textNV, "Hãy nhập tên nhân viên");
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(StrCon))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("select * from tblDonNhap where sSoHDN= '" + txtMaHoaDonNhap.Text + "'", sqlCon);
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        errloi.SetError(txtMaHoaDonNhap, "Mã sách này đã bị trùng");
                        return;
                    }
                }
            }

            StringBuilder query = new StringBuilder("exec Them_Hoa_Don_Nhap");
            query.Append(" @MaHoaDon= '" + txtMaHoaDonNhap.Text + "'");
            query.Append(",@NgayNhapHang= '" + dtpNgayLapHoaDonNhap.Value + "'");
            query.Append(",@TenNhaCungCap= N'" + txtTenNCC.Text + "'");
            query.Append(",@TenNhanVien= N'" + textNV.Text + "'");
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuHoaDonNhap();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không thêm được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;

            if (rowId < 0)
            {
                rowId = 0;
            }

            if (rowId == dgvHoaDonNhap.RowCount - 1)
            {
                rowId -= 1;
            }

            DataGridViewRow row = dgvHoaDonNhap.Rows[rowId];
            txtMaHoaDonNhap.Text = row.Cells[0].Value.ToString();
            dtpNgayLapHoaDonNhap.Value = DateTime.Parse(row.Cells[1].Value.ToString());
            txtTenNCC.Text = row.Cells[2].Value.ToString();
            textNV.Text = row.Cells[3].Value.ToString();
        }

        private void bton_Sua_Click(object sender, EventArgs e)
        {
            errloi.SetError(txtMaHoaDonNhap, "");
            errloi.SetError(dtpNgayLapHoaDonNhap, "");
            errloi.SetError(txtTenNCC, "");
            errloi.SetError(textNV, "");

            DateTime dtnow = DateTime.Now;
            if (txtMaHoaDonNhap.Text == "")
            {
                errloi.SetError(txtMaHoaDonNhap, "Bạn chưa nhập mã hoá đơn");
                return;
            }

            if (dtpNgayLapHoaDonNhap.Value > dtnow)
            {
                errloi.SetError(dtpNgayLapHoaDonNhap, "Ngày nhập không được lớn hơn ngày hiện tại ");
                return;
            }

            if (txtTenNCC.Text == "")
            {
                errloi.SetError(txtTenNCC, "Hãy nhập tên nhà cung cấp");
                return;
            }

            if (textNV.Text == "")
            {
                errloi.SetError(textNV, "Hãy nhập tên nhân viên");
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(StrCon))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("select * from tblDonNhap where sSoHDN= '" + txtMaHoaDonNhap.Text + "'", sqlCon);
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        errloi.SetError(txtMaHoaDonNhap, "Mã sách này đã bị trùng");
                        return;
                    }
                }
            }

            StringBuilder query = new StringBuilder("exec Sua_Hoa_Don_Nhap");
            query.Append(" @MaHoaDon= '" + txtMaHoaDonNhap.Text + "'");
            query.Append(",@NgayNhapHang= '" + dtpNgayLapHoaDonNhap.Value + "'");
            query.Append(",@TenNhaCungCap=N'" + txtTenNCC.Text + "'");
            query.Append(",@TenNhanVien=N'" + textNV.Text + "'");
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuHoaDonNhap();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không sửa được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bton_Xoa_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("exec Xoa_Hoa_Don_Nhap");
            query.Append(" @MaHoaDon= '" + txtMaHoaDonNhap.Text + "'");
            int kq = dataProvider.execNonQuery(query.ToString());
            if (kq > 0)
            {
                HienDuLieuHoaDonNhap();
                MessageBox.Show("Xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Không xoá được", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            FormTimKiemSach timSach = new FormTimKiemSach();
            timSach.ShowDialog();
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            errloi.SetError(txtMaHoaDonBanSach, "");
            if (txtMaHoaDonBanSach.Text == "")
            {
                errloi.SetError(txtMaHoaDonBanSach, "Bạn chưa nhập mã hoá đơn nên chưa thể xem chi tiết");
                return;
            }
            FormChiTietDonBan ctdb = new FormChiTietDonBan(txtMaHoaDonBanSach.Text);
            ctdb.ShowDialog();
        }

        private void btonXemChiTiet_Click(object sender, EventArgs e)
        {
            errloi.SetError(txtMaHoaDonNhap, "");
            if (txtMaHoaDonNhap.Text == "")
            {
                errloi.SetError(txtMaHoaDonNhap, "Bạn chưa nhập mã hoá đơn nên chưa thể xem chi tiết");
                return;
            }
            FormChiTietDonNhap ctdb = new FormChiTietDonNhap(txtMaHoaDonNhap.Text);
            ctdb.ShowDialog();
        }
    }
}
