using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanSach
{
    public partial class FormTimKiemSach : Form
    {
        DataProvider dataProvider= new DataProvider();
        private string TheLoai;
        public FormTimKiemSach()
        {
            InitializeComponent();
        }

        private void ChonTheLoai()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select * from tblTheLoai");
            dt = dataProvider.execQuery(query.ToString());
            cmbTheLoai.DisplayMember = "sTheLoai";
            cmbTheLoai.ValueMember = "sMaLoai";
            cmbTheLoai.DataSource = dt;
        }

        private void cmbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox theLoai = sender as ComboBox;
            TheLoai = theLoai.SelectedValue.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text == "")
            {
                if(cmbTheLoai.Text == "")
                {
                    DataTable dt = new DataTable("Tìm");
                    StringBuilder query = new StringBuilder("select sMaSach[Mã sách]");
                    query.Append(",sTheLoai[Thể loại]");
                    query.Append(",sTenSach[Tên sách]");
                    query.Append(",fDonGia[Đơn giá]");
                    query.Append(",sTenTG[Tên tác giả]");
                    query.Append(",iSoLuong[Số lượng]");
                    query.Append(" from tblSach,tblTheLoai");
                    query.Append(" where tblSach.sMaLoai=tblTheLoai.sMaLoai and sTenTG=N'" + txtTenTacGia.Text + "'");
                    dt = dataProvider.execQuery(query.ToString());
                    dgvTimSach.DataSource = dt;
                }else if (txtTenTacGia.Text == "")
                {
                    DataTable dt = new DataTable("Kiếm");
                    StringBuilder query = new StringBuilder("select sMaSach[Mã sách]");
                    query.Append(",sTheLoai[Thể loại]");
                    query.Append(",sTenSach[Tên sách]");
                    query.Append(",fDonGia[Đơn giá]");
                    query.Append(",sTenTG[Tên tác giả]");
                    query.Append(",iSoLuong[Số lượng]");
                    query.Append(" from tblSach,tblTheLoai");
                    query.Append(" where tblSach.sMaLoai=tblTheLoai.sMaLoai and sTheLoai=N'"+cmbTheLoai.Text+"'");
                    dt = dataProvider.execQuery(query.ToString());
                    dgvTimSach.DataSource = dt;
                }
                else
                {
                    DataTable dt = new DataTable("Sách");
                    StringBuilder query = new StringBuilder("select sMaSach[Mã sách]");
                    query.Append(",sTheLoai[Thể loại]");
                    query.Append(",sTenSach[Tên sách]");
                    query.Append(",fDonGia[Đơn giá]");
                    query.Append(",sTenTG[Tên tác giả]");
                    query.Append(",iSoLuong[Số lượng]");
                    query.Append(" from tblSach,tblTheLoai");
                    query.Append(" where tblSach.sMaLoai=tblTheLoai.sMaLoai and sTheLoai=N'" + cmbTheLoai.Text + "' and sTenTG=N'" + txtTenTacGia.Text + "'");
                    dt = dataProvider.execQuery(query.ToString());
                    dgvTimSach.DataSource = dt;
                }
            }
            else
            {
                DataTable dt = new DataTable("Bảng");
                StringBuilder query = new StringBuilder("select sMaSach[Mã sách]");
                query.Append(",sTheLoai[Thể loại]");
                query.Append(",sTenSach[Tên sách]");
                query.Append(",fDonGia[Đơn giá]");
                query.Append(",sTenTG[Tên tác giả]");
                query.Append(",iSoLuong[Số lượng]");
                query.Append(" from tblSach,tblTheLoai");
                query.Append(" where tblSach.sMaLoai=tblTheLoai.sMaLoai and sTenSach=N'" + txtTenSach.Text + "'");
                dt = dataProvider.execQuery(query.ToString());
                dgvTimSach.DataSource = dt;
            }
        }

        private void FormTimKiemSach_Load(object sender, EventArgs e)
        {
            ChonTheLoai();
        }
    }
}
