﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="them.aspx.cs" Inherits="btlltweb.qlsinhvien.them" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/Icon/fontawesome-free-5.15.4-web/css/all.min.css">
    <link rel="stylesheet" href="~/File CSS/phu.css"/>
    <link rel="stylesheet" href="~/File CSS/them.css"/>
</head>
<  <body style="display: grid;">
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
                                <a href="../trangchu.aspx" class="navbar__link">
                                    <i class="fas fa-home"></i>
                                    Trang chủ
                                </a>
                            </li>

                            <li class="navbar__list-item ">
                                <a href="../QLsinhvien.aspx" class="navbar__link">
                                    <i class="fas fa-user"></i>
                                    QL Sinh Viên
                                </a>
                            </li>

                            <li class="navbar__list-item ">
                                <a href="../QLMonhoc.aspx" class="navbar__link">
                                    <i class="fas fa-book"></i>
                                    QL Môn Học
                                </a>
                            </li>

                            <li class="navbar__list-item navbar__menu-open">
                               <a href="../QLlophoc.aspx" class="navbar__link">
                                    <i class="fas fa-briefcase"></i>
                                    QL Lớp Học
                                </a>
                            </li>   

                            <li class="navbar__list-item ">
                                <a href="../QLgiaovien.aspx" class="navbar__link">
                                    <i class="fas fa-school"></i>
                                    QL Giáo Viên 
                                </a>
                            </li>

                            <li class="navbar__list-item ">
                                <a href="../QLdiem.aspx" class="navbar__link">
                                    <i class="fas fa-marker"></i>
                                    QL Điểm
                                </a>
                            </li>
                        </ul>
                    </nav>  
                </div>
               
                  <div id="content__body" class="thang">
                     
         
                      <h1 class="h1">Thêm Sinh Viên</h1>
       <form id="form1" runat="server" >
             <div class="form-group">
        <label asp-for="MaSinhVien">Mã Sinh Viên</label>
        <asp:TextBox ID="Msv" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label asp-for="HoVaTen">Họ Và Tên</label>
        <asp:TextBox ID="hvt" runat="server" class="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label asp-for="NgaySinh">Ngày sinh</label>
       <asp:TextBox ID="ns" runat="server" class="form-control" type="date" ></asp:TextBox>
    </div>
    <div class="form-group">
        <label asp-for="GioiTinh">Giới tính</label>
        <asp:DropDownList ID="gt" runat="server"  class="form-control">
            <asp:ListItem Selected="True">Nam</asp:ListItem>
            <asp:ListItem>Nữ</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="form-group">
        <label asp-for="QueQuan">Quê Quán</label>
        <asp:TextBox ID="qq" runat="server" class="form-control" ></asp:TextBox>
    </div>
    <div class="form-group">
        <label asp-for="SDT">SĐT</label>
        <asp:TextBox ID="sdt" runat="server" class="form-control" ></asp:TextBox>
    </div>
    <div class="form-group">
        <label asp-for="Email">Email</label>
        <asp:TextBox ID="email" runat="server" class="form-control" ></asp:TextBox>
    </div>
    <div class="form-group">
        <label asp-for="MaLop">Mã lớp</label>
        <asp:DropDownList ID="ml" runat="server"  class="form-control"></asp:DropDownList>
    </div>
    <div class="btn-group">
           
            <asp:Button ID="Button1" runat="server" Text="Thêm Sinh Viên " Width="173px" OnClick="Button1_Click" Style="background-color:#2851b2 ; text-align:center; color : white; padding : 5px ;  margin: 20px; "/>
     
            <asp:Button ID="Button2" runat="server" Text="Thoát " Width="173px" OnClick="Button2_Click" Style="background-color:#2851b2 ; text-align:center; color : white; padding : 5px ;  margin: 20px; "/>
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
