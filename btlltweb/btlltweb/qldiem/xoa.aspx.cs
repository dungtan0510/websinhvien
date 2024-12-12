using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace btlltweb.qldiem
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
                msv.DataSource = tb;
                msv.DataTextField = "MaSinhVien";
                msv.DataValueField = "MaSinhVien";
                msv.DataBind();
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * From MON_HOC", conn);
                DataTable tb1 = new DataTable();
                ad1.Fill(tb1);
                Mmh.DataSource = tb1;
                Mmh.DataTextField = "MaMonHoc";
                Mmh.DataValueField = "MaMonHoc";
                Mmh.DataBind();

            }
        }

        protected void Msv_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"Select * From DIEM where MaSinhVien ='{0}' AND MaMonHoc = '{1}'", msv.SelectedValue, Mmh.SelectedValue);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            if (tb.Rows.Count > 0)
            {


                lh.Text = tb.Rows[0]["LanHoc"].ToString();
                lt.Text = tb.Rows[0]["LanThi"].ToString();
                diem.Text = tb.Rows[0]["Diem"].ToString();
            }
            conn.Close();
        }

        protected void Mmh_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"Select * From DIEM where MaSinhVien ='{0}' AND MaMonHoc = '{1}'", msv.SelectedValue, Mmh.SelectedValue);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            if (tb.Rows.Count > 0)
            {


                lh.Text = tb.Rows[0]["LanHoc"].ToString();
                lt.Text = tb.Rows[0]["LanThi"].ToString();
                diem.Text = tb.Rows[0]["Diem"].ToString();
            }
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"delete from DIEM where MaSinhVien='{0}' AND MaMonHoc='{1}'", msv.SelectedValue, Mmh.SelectedValue);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            string script = "alert('Đã xóa điểm thành công');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../QLdiem.aspx");
        }
    }
}