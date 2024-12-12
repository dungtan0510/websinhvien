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
    public partial class them : System.Web.UI.Page
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
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"INSERT INTO MON_HOC (MaMonHoc,TenMonHoc,SoTinChi) VALUES('{0}','{1}',{2})", Mmh.Text, tmh.Text, stc.Text);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            string script = "alert('Môn Học đã được thêm');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../QLMonhoc.aspx");
        }
    }
}