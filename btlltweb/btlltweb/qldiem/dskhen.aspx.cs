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
    public partial class dskhen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = @"SELECT DIEM.MaSinhVien, SINH_VIEN.HoVaTen, MON_HOC.MaMonHoc, DIEM.LanHoc, DIEM.LanThi, DIEM.Diem
                           FROM SINH_VIEN INNER JOIN (MON_HOC INNER JOIN DIEM ON MON_HOC.MaMonHoc = DIEM.MaMonHoc) ON SINH_VIEN.MaSinhVien = DIEM.MaSinhVien Where Diem > 8.5";
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dgvMonHoc.DataSource = tb;
            dgvMonHoc.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = @"SELECT DIEM.MaSinhVien, SINH_VIEN.HoVaTen, MON_HOC.MaMonHoc, DIEM.LanHoc, DIEM.LanThi, DIEM.Diem
                           FROM SINH_VIEN INNER JOIN (MON_HOC INNER JOIN DIEM ON MON_HOC.MaMonHoc = DIEM.MaMonHoc) ON SINH_VIEN.MaSinhVien = DIEM.MaSinhVien Where Diem > 8.5";
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dgvMonHoc.DataSource = tb;
            dgvMonHoc.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../QLdiem.aspx");
        }
    }
}