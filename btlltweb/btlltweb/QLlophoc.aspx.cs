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
    public partial class QLlophoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
                conn.Open();
                OleDbDataAdapter ad = new OleDbDataAdapter("Select * From LOP_HOC", conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                dgvMonHoc.DataSource = tb;
                dgvMonHoc.DataBind();
                cbotenlop.DataSource = tb;
                cbotenlop.DataTextField = "TenLop";
                cbotenlop.DataValueField = "MaLop";
                cbotenlop.DataBind();
                conn.Close();
                LoadTenLopDropdown();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("Select * From LOP_HOC", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dgvMonHoc.DataSource = tb;
            dgvMonHoc.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("qllophoc/them.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("qllophoc/sua.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("qllophoc/xoa.aspx");
        }
        private void LoadTenLopDropdown()
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlwwinform\qlysinhvien.mdb";
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
                    emptyRow["TenLop"] = "--Chọn tên lớp--";
                    tb.Rows.InsertAt(emptyRow, 0);
                    cbotenlop.DataSource = tb;
                    cbotenlop.DataTextField = "TenLop";
                    cbotenlop.DataValueField = "MaLop";
                    cbotenlop.DataBind();

                }
            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlwwinform\qlysinhvien.mdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT LOP_HOC.MaLop, LOP_HOC.TenLop, LOP_HOC.Khoa, LOP_HOC.NamVao FROM LOP_HOC WHERE 1=1";
                List<OleDbParameter> parameters = new List<OleDbParameter>();

                if (!string.IsNullOrWhiteSpace(ml.Text))
                {
                    sql += " AND LOP_HOC.MaLop = ?";
                    parameters.Add(new OleDbParameter("@MaLop", ml.Text.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(khoa.Text))
                {
                    sql += " AND LOP_HOC.Khoa = ?";
                    parameters.Add(new OleDbParameter("@Khoa", khoa.Text.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(namvao.Text))
                {
                    if (int.TryParse(namvao.Text, out int namVao))
                    {
                        sql += " AND LOP_HOC.NamVao = ?";
                        parameters.Add(new OleDbParameter("@NamVao", namVao));
                    }
                    else
                    {
                        // Handle invalid input for NamVao (e.g., show error message)
                    }
                }

                if (cbotenlop.SelectedIndex > 0) // Bỏ qua mục trống
                {
                    sql += " AND LOP_HOC.TenLop = ?";
                    parameters.Add(new OleDbParameter("@TenLop", cbotenlop.SelectedItem.Text));
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("Select * From LOP_HOC", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dgvMonHoc.DataSource = tb;
            dgvMonHoc.DataBind();
        }
    }
}