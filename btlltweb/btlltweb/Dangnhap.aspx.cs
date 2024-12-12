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
    public partial class Dangnhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private int Login(string sql)
        {
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            using (OleDbConnection con = new OleDbConnection(connectionString))
            {
                OleDbCommand cmd = new OleDbCommand(sql, con);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message; 
                }
                return dt.Rows.Count;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM TAI_KHOAN WHERE TaiKhoan = '" + txtUser.Text + "' AND MatKhau='" + txtPass.Text + "'";
            int maxrow = Login(sql);

            if (maxrow > 0)
            {
                Session["User"] = txtUser.Text;
                Response.Redirect("trangchu.aspx");
            }
            else
            {
                lblMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
        }

        protected void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.TextMode = chkShowPassword.Checked ? TextBoxMode.SingleLine : TextBoxMode.Password;
        }
    }
    
}