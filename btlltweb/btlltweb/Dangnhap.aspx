<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dangnhap.aspx.cs" Inherits="btlltweb.Dangnhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="/Icon/fontawesome-free-5.15.4-web/css/all.min.css"/>
    <link rel="stylesheet" href="~/File CSS/login.css"/>
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
              
                </div>
          
                  <div id="bgimg">
                    <div class="background">
                        <img class="imgbg" src="/baocao/Ảnh/noidungchinh1.jpg" alt="">
                        <div class="overlay"></div>
                    </div>

                    <div id="bg_login">
                        <div class="container">
                            <div class="container_display">
                                <div class="container_in">
                                    <input type="radio" name="input_tab" id="input_1">
                                    <input type="radio" name="input_tab" id="input_2">
                                
                                    <div class="sign">
                                        <h2>ĐĂNG KÝ</h2>
                                        <div class="container_login">
                                           <form>
                                                <input class="text_login" type="text" placeholder="Email/Tên đăng nhập" required>
                                                <input class="pass_login" type="password" placeholder="Mật khẩu" required>
                                                <input class="pass_login" type="password" placeholder="Nhập lại Mật khẩu" required>
                                                <button class="btn_from" type="submit">Đăng Ký</button>
                                                <div>
                                                    <button id="login_form">
                                                        <a href="">
                                                            Đăng Ký
                                                            <i class="fab fa-google"></i>
                                                        </a>
                                                    </button>
                                                    <button id="login_form">
                                                        <a href="">
                                                            Đăng Ký
                                                            <i class="fab fa-facebook-square"></i>
                                                        </a>
                                                    </button>
                                                </div>
                                            </form>
                                        </div>
                                    </div>

                                    <div class="login">
                                        <h2>ĐĂNG NHẬP</h2>
                                        <div class="container_login">
                                                  <form id="form2" runat="server">
                                               
                                                <asp:TextBox class="text_login" ID="txtUser" runat="server" placeholder="Email/Tên đăng nhập"></asp:TextBox>
                                                <asp:TextBox  class="pass_login" ID="txtPass" runat="server" placeholder="Mật khẩu"  TextMode="Password"></asp:TextBox>
                                                 <asp:CheckBox ID="chkShowPassword" runat="server" Text="Hiển thị mật khẩu" AutoPostBack="true" OnCheckedChanged="chkShowPassword_CheckedChanged"/>
                                                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                                                <asp:Button  class="btn_from" ID="Button1" runat="server" Text="Đăng Nhập" OnClick="Button1_Click" />
                                                <div class="form_p">
                                                    <a href="">
                                                        <input class="check_from" type="checkbox"> Lưu Mật khẩu
                                                    </a>
                                                    <a href="">Quên Mật khẩu</a>
                                                </div>
                                                <div>
                                                    <button id="login_form">
                                                        <a href="">
                                                            <i class="fab fa-google"></i>
                                                            Google
                                                        </a>
                                                    </button>
                                                    <button id="login_form">
                                                        <a href="">
                                                            <i class="fab fa-facebook-square"></i>
                                                            FaceBook
                                                        </a>
                                                    </button>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                                
                                <div class="label_slide">
                                    <label class="label1" for="input_1"></label>
                                    <label class="label2" for="input_2"></label>
                                </div>
                            </div>
                        </div>
               </div>
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
