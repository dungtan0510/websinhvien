using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace btlltweb.qlsinhvien
{
    public partial class xoa : System.Web.UI.Page
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
                Msv.DataSource = tb;
                Msv.DataTextField = "MaSinhVien";
                Msv.DataValueField = "MaSinhVien";
                Msv.DataBind();
                conn.Close();
            }
        }

        protected void Msv_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"Select * From SINH_VIEN where MaSinhVien ='{0}'", Msv.SelectedValue);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            if (tb.Rows.Count > 0)
            {
                hvt.Text = tb.Rows[0]["HoVaTen"].ToString();
                ns.Text = tb.Rows[0]["NgaySinh"].ToString();
                gt.Text = tb.Rows[0]["GioiTinh"].ToString();
                qq.Text = tb.Rows[0]["QueQuan"].ToString();
                sdt.Text = tb.Rows[0]["SDT"].ToString();
                email.Text = tb.Rows[0]["Email"].ToString();
                ml.Text = tb.Rows[0]["MaLop"].ToString();
            }
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"delete from SINH_VIEN where MaSinhVien='{0}'", Msv.SelectedValue);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            string script = "alert('Sinh viên đã được xóa');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../QLsinhvien.aspx");
        }
    }
}