using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace btlltweb
{
    public partial class QLgiaovien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
                conn.Open();
                OleDbDataAdapter ad = new OleDbDataAdapter("Select * From GIAO_VIEN", conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                dgvMonHoc.DataSource = tb;
                dgvMonHoc.DataBind();
                conn.Close();

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("Select * From GIAO_VIEN", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dgvMonHoc.DataSource = tb;
            dgvMonHoc.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("Select * From GIAO_VIEN", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dgvMonHoc.DataSource = tb;
            dgvMonHoc.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("qlgiaovien/them.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("qlgiaovien/sua.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("qlgiaovien/xoa.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlwwinform\qlysinhvien.mdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT GIAO_VIEN.MaGiaoVien, GIAO_VIEN.HoVaTen, GIAO_VIEN.NgaySinh, GIAO_VIEN.GioiTinh, GIAO_VIEN.SDT, GIAO_VIEN.Email
                               FROM GIAO_VIEN WHERE 1=1";

                List<OleDbParameter> parameters = new List<OleDbParameter>();

                if (!string.IsNullOrWhiteSpace(txtMaGiaoVien.Text))
                {
                    sql += " AND GIAO_VIEN.MaGiaoVien = ?";
                    parameters.Add(new OleDbParameter("@MaGiaoVien", txtMaGiaoVien.Text.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    sql += " AND GIAO_VIEN.HoVaTen LIKE ?";
                    parameters.Add(new OleDbParameter("@HoVaTen", "%" + txtHoTen.Text.Trim() + "%"));
                }

                if (!string.IsNullOrWhiteSpace(date1.Text) && !string.IsNullOrWhiteSpace(date2.Text))
                {
                    DateTime dateStart, dateEnd;
                    if (DateTime.TryParse(date1.Text, out dateStart) && DateTime.TryParse(date2.Text, out dateEnd))
                    {
                        sql += " AND GIAO_VIEN.NgaySinh BETWEEN ? AND ?";
                        parameters.Add(new OleDbParameter("@NgaySinhStart", dateStart));
                        parameters.Add(new OleDbParameter("@NgaySinhEnd", dateEnd));
                    }
                }

                using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn))
                {
                    foreach (var param in parameters)
                    {
                        ad.SelectCommand.Parameters.Add(param);
                    }

                    DataTable tb = new DataTable();
                    ad.Fill(tb);
                    dgvMonHoc.DataSource = tb;
                    dgvMonHoc.DataBind();
                }
            }
        }
    }
}