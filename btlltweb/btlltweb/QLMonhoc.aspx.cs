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
    public partial class QLMonhoc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
                conn.Open();
                OleDbDataAdapter ad = new OleDbDataAdapter("Select * From MON_HOC", conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                dgvMonHoc.DataSource = tb;
                dgvMonHoc.DataBind();
                cbomonhoc.DataSource = tb;
                cbomonhoc.DataTextField = "TenMonHoc";
                cbomonhoc.DataValueField = "MaMonHoc";
                cbomonhoc.DataBind();
                conn.Close();
                 LoadMonHocDropdown();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("Select * From MON_HOC", conn);
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
            OleDbDataAdapter ad = new OleDbDataAdapter("Select * From MON_HOC", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dgvMonHoc.DataSource = tb;
            dgvMonHoc.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("qlmonhoc/them.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("qlmonhoc/sua.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("qlmonhoc/xoa.aspx");
        }
        private void LoadMonHocDropdown()
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT MaMonHoc, TenMonHoc FROM MON_HOC";
                using (OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn))
                {
                    DataTable tb = new DataTable();
                    ad.Fill(tb);

                    // Thêm mục trống vào DropDownList
                    DataRow emptyRow = tb.NewRow();
                    emptyRow["MaMonHoc"] = DBNull.Value;
                    emptyRow["TenMonHoc"] = "--Chọn môn học--";
                    tb.Rows.InsertAt(emptyRow, 0);

                    cbomonhoc.DataSource = tb;
                    cbomonhoc.DataTextField = "TenMonHoc";
                    cbomonhoc.DataValueField = "MaMonHoc";
                    cbomonhoc.DataBind();
                }
            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT MON_HOC.MaMonHoc, MON_HOC.TenMonHoc, MON_HOC.SoTinChi FROM MON_HOC WHERE 1=1";
                List<OleDbParameter> parameters = new List<OleDbParameter>();

                if (!string.IsNullOrWhiteSpace(txtMamonhoc.Text))
                {
                    sql += " AND MON_HOC.MaMonHoc = ?";
                    parameters.Add(new OleDbParameter("@MaMonHoc", txtMamonhoc.Text.Trim()));
                }

                if (!string.IsNullOrWhiteSpace(txtsotinchi.Text))
                {
                    int soTinChi;
                    if (int.TryParse(txtsotinchi.Text, out soTinChi))
                    {
                        sql += " AND MON_HOC.SoTinChi = ?";
                        parameters.Add(new OleDbParameter("@SoTinChi", soTinChi));
                    }
                }

                if (cbomonhoc.SelectedIndex > 0) // Bỏ qua mục trống
                {
                    sql += " AND MON_HOC.TenMonHoc = ?";
                    parameters.Add(new OleDbParameter("@TenMonHoc", cbomonhoc.SelectedItem.Text));
                }

                OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
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