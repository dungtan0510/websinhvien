using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace btlltweb.qllophoc
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
                OleDbDataAdapter ad = new OleDbDataAdapter("Select * From LOP_HOC", conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                ml.DataSource = tb;
                ml.DataTextField = "MaLop";
                ml.DataValueField = "MaLop";
                ml.DataBind();
                conn.Close();
            }
        }

        protected void Msv_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"Select * From LOP_HOC where MaLop ='{0}'", ml.SelectedValue);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            if (tb.Rows.Count > 0)
            {
                tl.Text = tb.Rows[0]["TenLop"].ToString();
                khoa.Text = tb.Rows[0]["Khoa"].ToString();
                namvao.Text = tb.Rows[0]["NamVao"].ToString();

            }
            conn.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"delete from LOP_HOC where MaLop='{0}'", ml.SelectedValue);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            string script = "alert('Lớp Học đã được xóa');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../QLlophoc.aspx");
        }
    }
}