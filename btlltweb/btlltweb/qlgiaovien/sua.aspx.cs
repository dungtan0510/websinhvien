using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
namespace btlltweb.qlgiaovien
{
    public partial class sua : System.Web.UI.Page
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
                Mgv.DataSource = tb;
                Mgv.DataTextField = "MaGiaoVien";
                Mgv.DataValueField = "MaGiaoVien";
                Mgv.DataBind();
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"UPDATE GIAO_VIEN SET HoVaTen = '{0}' , NgaySinh = '{1}' , GioiTinh = '{2}' , SDT = '{3}' , Email = '{4}'  where MaGiaoVien ='{5}'", hvt.Text, ns.Text, gt.Text, sdt.Text, email.Text, Mgv.SelectedValue);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            string script = "alert('Giáo viên đã được sửa');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../QLgiaovien.aspx");
        }

        protected void Msv_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = string.Format(@"Select * From GIAO_VIEN where MaGiaoVien ='{0}'", Mgv.SelectedValue);
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            if (tb.Rows.Count > 0)
            {
                hvt.Text = tb.Rows[0]["HoVaTen"].ToString();
                ns.Text = tb.Rows[0]["NgaySinh"].ToString();
                gt.Text = tb.Rows[0]["GioiTinh"].ToString();
                sdt.Text = tb.Rows[0]["SDT"].ToString();
                email.Text = tb.Rows[0]["Email"].ToString();

            }
            conn.Close();
        }
    }
}