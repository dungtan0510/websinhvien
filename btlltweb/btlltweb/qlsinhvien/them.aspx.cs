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
    public partial class them : System.Web.UI.Page
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
                OleDbDataAdapter ad1 = new OleDbDataAdapter("Select * From LOP_HOC", conn);
                DataTable tb1 = new DataTable();
                ad1.Fill(tb1);
                ml.DataSource = tb1;
                ml.DataTextField = "MaLop";
                ml.DataValueField = "MaLop";
                ml.DataBind();
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"INSERT INTO SINH_VIEN (MaSinhVien,HoVaTen,NgaySinh,GioiTinh,QueQuan,SDT,Email,MaLop) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", Msv.Text, hvt.Text, ns.Text, gt.SelectedValue, qq.Text, sdt.Text, email.Text, ml.SelectedValue);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            string script = "alert('Sinh viên đã được thêm');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../QLsinhvien.aspx");
        }
    }
}