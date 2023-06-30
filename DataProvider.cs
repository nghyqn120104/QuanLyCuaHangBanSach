using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangBanSach
{
    public class DataProvider
    {
        private string StrCon = @"Data Source=DESKTOP-HT298IF\SQLEXPRESS;Initial Catalog=QUANLYCUAHANGBANSACH;Integrated Security=True";

        // Hàm này dùng cho lệnh select dùng để hiện dữ liệu
        public DataTable execQuery(string qry)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(StrCon))
            {
                sqlCon.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(qry, sqlCon);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Fill(data);
            }
            return data;
        }

        // Hàm này dùng cho lệnh insert,delete,update để thêm,xoá,sửa
        public int execNonQuery(string qry)
        {
            int data = 0;
            using (SqlConnection sqlCon = new SqlConnection(StrCon))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(qry,sqlCon);
                data = sqlCmd.ExecuteNonQuery();
            }
            return data;
        }

        // Dùng để truy vấn 1 dòng dữ liệu
        // Dùng để tính tổng các cột, hoá đơn,...
        public object execScaler(string qry)
        {
            object data = 0;
            using (SqlConnection sqlCon = new SqlConnection(StrCon))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(qry, sqlCon);
                data = sqlCmd.ExecuteScalar();
            }
            return data;
        }
    }
}
