using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using ClosedXML.Excel;
using System.IO;
namespace btlltweb
{
    public partial class QLdiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
                conn.Open();
                string sql = @"SELECT DIEM.MaSinhVien, SINH_VIEN.HoVaTen, MON_HOC.MaMonHoc, DIEM.LanHoc, DIEM.LanThi, DIEM.Diem
                           FROM SINH_VIEN INNER JOIN (MON_HOC INNER JOIN DIEM ON MON_HOC.MaMonHoc = DIEM.MaMonHoc) ON SINH_VIEN.MaSinhVien = DIEM.MaSinhVien";
                OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                dgvMonHoc.DataSource = tb;
                dgvMonHoc.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=D:\btlltweb\qlysinhvien.mdb";
            conn.Open();
            string sql = @"SELECT DIEM.MaSinhVien, SINH_VIEN.HoVaTen, MON_HOC.MaMonHoc, DIEM.LanHoc, DIEM.LanThi, DIEM.Diem
                           FROM SINH_VIEN INNER JOIN (MON_HOC INNER JOIN DIEM ON MON_HOC.MaMonHoc = DIEM.MaMonHoc) ON SINH_VIEN.MaSinhVien = DIEM.MaSinhVien";
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
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
            string sql = @"SELECT DIEM.MaSinhVien, SINH_VIEN.HoVaTen, MON_HOC.MaMonHoc, DIEM.LanHoc, DIEM.LanThi, DIEM.Diem
                           FROM SINH_VIEN INNER JOIN (MON_HOC INNER JOIN DIEM ON MON_HOC.MaMonHoc = DIEM.MaMonHoc) ON SINH_VIEN.MaSinhVien = DIEM.MaSinhVien";
            OleDbDataAdapter ad = new OleDbDataAdapter(sql, conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            dgvMonHoc.DataSource = tb;
            dgvMonHoc.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("qldiem/them.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("qldiem/sua.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("qldiem/xoa.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("qldiem/dskhen.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("qldiem/dsphat.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (TableCell cell in dgvMonHoc.HeaderRow.Cells)
            {
                dt.Columns.Add(cell.Text);
            }
            foreach (GridViewRow row in dgvMonHoc.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[dt.Rows.Count - 1][i] = row.Cells[i].Text;
                }
            }

            ExportFile(dt, "DanhSach", "Danh Sách Điểm");
        }
        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(sheetName);

                // Tạo phần Tiêu đề
                var titleRange = ws.Range("A1:F1");
                titleRange.Merge().Value = title;
                titleRange.Style.Font.Bold = true;
                titleRange.Style.Font.FontSize = 20;
                titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                titleRange.Style.Font.FontName = "Times New Roman"; // Đặt phông chữ cho tiêu đề

                // Đặt tên cột
                ws.Cell(3, 1).Value = "Mã Sinh Viên";
                ws.Cell(3, 2).Value = "Họ Và Tên";
                ws.Cell(3, 3).Value = "Mã Môn Học";
                ws.Cell(3, 4).Value = "Lần Học";
                ws.Cell(3, 5).Value = "Lần Thi";
                ws.Cell(3, 6).Value = "Điểm";

                var headerRange = ws.Range("A3:F3");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headerRange.Style.Font.FontName = "Times New Roman"; // Đặt phông chữ cho tiêu đề cột

                // Đặt phông chữ cho toàn bộ trang tính
                ws.Style.Font.FontName = "Times New Roman";

                // Thêm dữ liệu từ DataTable vào trang tính
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        ws.Cell(i + 4, j + 1).Value = dataTable.Rows[i][j]?.ToString(); // Chuyển đổi sang chuỗi
                    }
                }

                // Kẻ viền
                var allDataRange = ws.Range("A3:F" + (3 + dataTable.Rows.Count));
                allDataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                allDataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                // Tự động căn chỉnh độ rộng cột
                ws.Columns().AdjustToContents();

                // Xuất file ra trình duyệt
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=" + sheetName + ".xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }

    }
}