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
    public partial class QLsinhvien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
                conn.Open();
                OleDbDataAdapter ad = new OleDbDataAdapter("Select * From SINH_VIEN", conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                dgvMonHoc.DataSource = tb;
                dgvMonHoc.DataBind();
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * From LOP_HOC", conn);
                DataTable tb1 = new DataTable();
                ad1.Fill(tb1);
                cboLop.DataSource = tb1;
                cboLop.DataTextField = "TenLop";
                cboLop.DataValueField = "MaLop";
                cboLop.DataBind();
                conn.Close();
                LoadLopDropdown();
            }
           
            }
        
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("Select * From SINH_VIEN", conn);
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
            OleDbDataAdapter ad = new OleDbDataAdapter("Select * From SINH_VIEN", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dgvMonHoc.DataSource = tb;
            dgvMonHoc.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("qlsinhvien/them.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("qlsinhvien/sua.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("qlsinhvien/xoa.aspx");
        }
        private void LoadLopDropdown()
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT MaLop, TenLop FROM LOP_HOC";
                using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn))
                {
                    DataTable tb = new DataTable();
                    ad.Fill(tb);

                    // Thêm mục trống vào DataTable
                    DataRow emptyRow = tb.NewRow();
                    emptyRow["MaLop"] = DBNull.Value;
                    emptyRow["TenLop"] = "--Chọn lớp--";
                    tb.Rows.InsertAt(emptyRow, 0);

                    cboLop.DataSource = tb;
                    cboLop.DataTextField = "TenLop";
                    cboLop.DataValueField = "MaLop";
                    cboLop.DataBind();
                }
            }
        }


        protected void Button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT SINH_VIEN.MaSinhVien, SINH_VIEN.HoVaTen, SINH_VIEN.NgaySinh, SINH_VIEN.GioiTinh, SINH_VIEN.QueQuan, SINH_VIEN.SDT, SINH_VIEN.Email, LOP_HOC.TenLop, LOP_HOC.MaLop
                       FROM LOP_HOC INNER JOIN SINH_VIEN ON LOP_HOC.MaLop = SINH_VIEN.MaLop
                       WHERE 1=1";

                List<OleDbParameter> parameters = new List<OleDbParameter>();

                if (!string.IsNullOrWhiteSpace(txtMaSinhVien.Text))
                {
                    sql += " AND SINH_VIEN.MaSinhVien = ?";
                    parameters.Add(new OleDbParameter("@MaSinhVien", txtMaSinhVien.Text.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(txtHoTen.Text))
                {
                    sql += " AND SINH_VIEN.HoVaTen LIKE ?";
                    parameters.Add(new OleDbParameter("@HoVaTen", "%" + txtHoTen.Text.Trim() + "%"));
                }

                if (!string.IsNullOrWhiteSpace(date1.Text) && !string.IsNullOrWhiteSpace(date2.Text))
                {
                    DateTime dateStart, dateEnd;
                    if (DateTime.TryParse(date1.Text, out dateStart) && DateTime.TryParse(date2.Text, out dateEnd))
                    {
                        sql += " AND SINH_VIEN.NgaySinh BETWEEN ? AND ?";
                        parameters.Add(new OleDbParameter("@NgaySinhStart", dateStart.ToString("MM/dd/yyyy")));
                        parameters.Add(new OleDbParameter("@NgaySinhEnd", dateEnd.ToString("MM/dd/yyyy")));
                    }
                }

                if (cboLop.SelectedIndex >= 0)
                {
                    sql += " AND LOP_HOC.MaLop = ?";
                    parameters.Add(new OleDbParameter("@MaLop", cboLop.SelectedValue));
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