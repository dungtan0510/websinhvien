using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace btlltweb.qlmonhoc
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
                OleDbDataAdapter ad = new OleDbDataAdapter("Select * From MON_HOC", conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                Mmh.DataSource = tb;
                Mmh.DataTextField = "MaMonHoc";
                Mmh.DataValueField = "MaMonHoc";
                Mmh.DataBind();
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"delete from MON_HOC where MaMonHoc='{0}'", Mmh.SelectedValue);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            string script = "alert('Môn học đã được xóa');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../QLMonhoc.aspx");
        }

        protected void Msv_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"Select * From MON_HOC where MaMonHoc ='{0}'", Mmh.SelectedValue);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            if (tb.Rows.Count > 0)
            {
                tmh.Text = tb.Rows[0]["TenMonHoc"].ToString();
                stc.Text = tb.Rows[0]["SoTinChi"].ToString();

            }
            conn.Close();
        }
    }
}