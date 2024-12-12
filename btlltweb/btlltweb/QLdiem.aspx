<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QLdiem.aspx.cs" Inherits="btlltweb.QLdiem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/Icon/fontawesome-free-5.15.4-web/css/all.min.css"/>
    <link rel="stylesheet" href="~/File CSS/qlsinhvien.css"/>
    <link rel="stylesheet" href="~/File CSS/phu.css"/>
</head>
    <body style="display: grid;">
    <header id="header">
        <div class="header__web">
            <div class="grid">
                <ul class="header__list">
                    <li class="header__list-item">
                        <a href="/baocao/File HTML/index.html" class="header__link"> 
                            <img width="100%" height="120px" style="border-radius:30%;"  src="/baocao/Ảnh/logodaihocthudo.jpg" alt="" class="header__img"/>
                        </a>
                    </li>

                    <li class="header__list-item">
                        <div class="header__slogan">
                            <div class="header__slogan1">
                                Quản Lý Sinh viên
                            </div>

                            <div class="header__slogan2">
                                Trường đại học thủ đô Hà Nội
                            </div>
                        </div>
                    </li>

                    <li class="header__list-item">
                        <div class="header__search">
                            <input type="text" placeholder="Tìm kiếm" class="header__input">
                            <button class="header__btn">Tìm</button>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </header>

        <main id="main">
        <div class="main__web">
            <div class="grid">
                <div id="menu__mega">
                        <nav class="main__menu">
                        <ul class="navbar__list">
                            <li class="navbar__list-item ">
                                <a href="trangchu.aspx" class="navbar__link">
                                    <i class="fas fa-home"></i>
                                    Trang chủ
                                </a>
                            </li>

                            <li class="navbar__list-item ">
                                <a href="QLsinhvien.aspx" class="navbar__link">
                                    <i class="fas fa-user"></i>
                                    QL Sinh Viên
                                </a>
                            </li>

                            <li class="navbar__list-item ">
                                <a href="QLMonhoc.aspx" class="navbar__link">
                                    <i class="fas fa-book"></i>
                                    QL Môn Học
                                </a>
                            </li>

                            <li class="navbar__list-item navbar__menu-open">
                               <a href="QLlophoc.aspx" class="navbar__link">
                                    <i class="fas fa-briefcase"></i>
                                    QL Lớp Học
                                </a>
                            </li>   

                            <li class="navbar__list-item ">
                                <a href="QLgiaovien.aspx" class="navbar__link">
                                    <i class="fas fa-school"></i>
                                    QL Giáo Viên 
                                </a>
                            </li>

                            <li class="navbar__list-item ">
                                <a href="QLdiem.aspx" class="navbar__link">
                                    <i class="fas fa-marker"></i>
                                    QL Điểm
                                </a>
                            </li>
                        </ul>
                    </nav>  
                </div>
                  <asp:Label ID="Label1" runat="server" Text="Danh sách điểm" Width="100%" Style="background-color:#2851b2 ; text-align:center; color : white; padding : 5px ; margin-top:20px;  " ></asp:Label>
                  <div id="content__body">
       <form id="form1" runat="server">
           <div class="trai1">
            <asp:GridView ID="dgvMonHoc" runat="server" Height="305px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="4" Style =" margin-top: 10px; margin-bottom:10px; " Width="100%" AutoGenerateColumns="False" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="MaSinhVien" HeaderText="Mã Sinh Viên" SortExpression="MaSinhVien" />
                    <asp:BoundField DataField="HoVaTen" HeaderText="Họ Và Tên" SortExpression="HoVaTen" />
                    <asp:BoundField DataField="MaMonHoc" HeaderText="Mã Môn Học" SortExpression="MaMonHoc" />
                    <asp:BoundField DataField="LanHoc" HeaderText="Lần Học" SortExpression="LanHoc" />
                    <asp:BoundField DataField="LanThi" HeaderText="Lần Thi" SortExpression="LanThi" />
                    <asp:BoundField DataField="Diem" HeaderText="Điểm" SortExpression="Diem" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
             </asp:GridView>         
             
            <asp:Button ID="Button1" runat="server" Text="Nạp Điểm " Width="173px" OnClick="Button1_Click" Style="background-color:#2851b2 ; text-align:center; color : white; padding : 5px ;  margin: 20px; "/>
     
            <asp:Button ID="Button2" runat="server" Text="Nhập Diểm " Width="173px" OnClick="Button2_Click" Style="background-color:#2851b2 ; text-align:center; color : white; padding : 5px ;  margin: 20px; "/>
       
            <asp:Button ID="Button3" runat="server" Text="Sửa Điểm " Width="173px" OnClick="Button3_Click" Style="background-color:#2851b2 ; text-align:center; color : white; padding : 5px ;  margin: 20px; "/>
           
            <asp:Button ID="Button4" runat="server" Text="Xóa Điểm " Width="173px" OnClick="Button4_Click" Style="background-color:#2851b2 ; text-align:center; color : white; padding : 5px ;  margin: 20px; "/>
           </div>
<div class="phai">
    <div class="timkiem">
        <asp:Button ID="Button6" runat="server" Text="Danh Sách Khen Thưởng " Width="173px" OnClick="Button6_Click" Style="background-color:#2851b2 ; text-align:center; color : white; padding : 5px;    margin: 20px; "/>
    </div>
     <div class="timkiem">
        <asp:Button ID="Button7" runat="server" Text="Danh Sách Kỉ Luật " Width="173px" OnClick="Button7_Click" Style="background-color:#2851b2 ; text-align:center; color : white; padding : 5px;    margin: 20px; "/>
    </div>

    <div class="timkiem">
        <asp:Button ID="Button5" runat="server" Text="Xuất File " Width="173px" OnClick="Button5_Click" Style="background-color:#2851b2; text-align:center; color : white; padding : 5px;  &nbsp; margin: 20px; height: 35px;"/>
    </div>
</div>
        </form>
        
               
         
            </div>
        </div>  
          </div>
    </main>


    <footer id="footer">
        <div class="footer__main">
            <div class="grid">
                <div class="footer__item">
                    <ul id="list">
                        <li class="footer__gif">
                            <img  height="120px" src="/baocao/Ảnh/gifs2.gif" alt="" class="img__gif">
                        </li>
                      
                        <li>
                            <div class="footer__icon">
                                <a href="">
                                    <i class="fab fa-facebook-square"></i>
                                </a>

                                <a href="">
                                    <i class="fab fa-instagram-square"></i>
                                </a>

                                <a href="">
                                    <i class="fab fa-youtube"></i>
                                </a>
                            </div>
                        </li>

                    </ul>
                </div>
            </div>
        </div>
    </footer>
</body>
</html>
