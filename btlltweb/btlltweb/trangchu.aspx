<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trangchu.aspx.cs" Inherits="btlltweb.trangchu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/Icon/fontawesome-free-5.15.4-web/css/all.min.css">
    <link rel="stylesheet" href="~/File CSS/main.css"/>
    <link rel="stylesheet" href="~/File CSS/phu.css"/>
    <title>Quản lý sinh viên</title>
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
                            <li class="navbar__list-item ">
                                 <form id="form1" runat="server">
                                 <div>
                                  <a href="" class="navbar__link">
                                <asp:Button ID="Button2" runat="server" Text="Đăng Xuất" OnClick="btnLogout_Click"  Style="background-color:white ; text-align:center; color : black;  border-radius:5%;"/>
                                 </a>
    
                                 </div>
                                 
                            </li>
                               <li class="navbar__list-item ">
                               
                                      <h2>Chào mừng  <asp:Label ID="lblUser" runat="server"></asp:Label></h2>
                                
                               </form>
                            </li>
                        </ul>
                    </nav>  
                </div>
   
                <div id="content1">
                    <div id="pro">
                        <div class="main__pro">
                            <div class="main__pro-display">
                                <div class="main__pro-wrap">
                                    <div class="main__pro-img">
                                        <img height="500px" width="1520px" src="/baocao/Ảnh/noibat1.jpg" alt="">
                                    </div>

                                    <div class="main__pro-img">
                                        <img height="500px"  width="1520px" src="/baocao/Ảnh/noibat2.jpg" alt="">
                                    </div>

                                    <div class="main__pro-img">
                                        <img height="500px"  width="1520px" src="/baocao/Ảnh/noibat3.jpg" alt="">
                                    </div>

                                    <div class="main__pro-img">
                                        <img height="500px"  width="1520px" src="/baocao/Ảnh/noibat4.jpg" alt="">
                                    </div>

                                    <div class="main__pro-img">
                                        <img height="500px"  width="1520px" src="/baocao/Ảnh/noibat5.jpg" alt="">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="main__left">
                        <div class="content__left">
                            <img width="200px" height="300px" src="/baocao/Ảnh/gif.gif" alt="" class="content__img">
                        </div>
                    </div>

                    <div id="main__right">
                        <div class="content__box">
                            <div class="img__content">
                                <img width="500px" height="500px" src="/baocao/Ảnh/noidungchinh1.jpg" alt="" class="img__main1">

                                <div class="content__p">
                                    <h2>Trường Đại học Thủ đô Hà Nội </h2>
                                    <p>Trường Đại học Thủ đô Hà Nội (tiếng Anh: Hanoi Metropolitan University) 
                                        là trường đại học công lập đầu tiên do UBND thành phố Hà Nội trực tiếp quản lý 
                                        thành lập ngày 31 tháng 12 năm 2014.
                                    </p>

                                    <a href="/baocao/File HTML/muangay.html#h2"><button class="content__btn">Truy cập</button></a>
                                </div>
                            </div>          
                        </div>
                    </div>

                    <div id="content2">
                        <div class="item__box">
                            <h2>Tin tức và sự kiện</h2>
                            
                            <ul class="list__new">
                                <li class="list__new-item">
                                    <img width="300px" height="250px" src="/baocao/Ảnh/newss1.jpg" alt="" class="img__item">
                                    <p id="p__text">Hội Trợ Khoa Học</p>
                                    <a href="/baocao/File HTML/File Item/item7.html">
                                        <button id="item_btn">Tìm hiểu thêm</button>
                                    </a>
                                </li>

                                <li class="list__new-item">
                                    <img width="300px" height="250px" src="/baocao/Ảnh/newss2.jpg" alt="" class="img__item">
                                    <p id="p__text">Lễ Trao Học Bổng</p>
                                    <a href="/baocao/File HTML/File Item/item8.html">
                                        <button id="item_btn">Tìm hiểu thêm</button>
                                    </a>
                                </li>

                                <li class="list__new-item">
                                    <img width="300px" height="250px" src="/baocao/Ảnh/newss3.jpg" alt="" class="img__item">
                                    <p id="p__text">Hội nghị</p>
                                    <a href="/baocao/File HTML/File Item/item9.html">
                                        <button id="item_btn">Tìm hiểu thêm</button>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div> 

                    <div id="main__left2">
                        <div class="content__box2">
                            <div class="img__content2">
                                <img width="500px" height="500px" src="/baocao/Ảnh/noidungchinh2.png" alt="" class="img__main2">

                                <div class="content__p">
                                    <h2>Khoa khoa học tự nhiên và công nghệ</h2>
                                    <p>
                        Sáng 12/4, Khoa Khoa học Tự nhiên và Công nghệ đã tổ chức seminar chuyên môn Nâng cao hiệu quả giảng dạy học phần Tin học.
Tham dự seminar có TS.Hoàng Thị Mai, Trưởng khoa, TS.Trương Đức Phương phó Trưởng khoa, các giảng viên tham gia giảng dạy học phần Tin học trong toàn
Tại buổi seminar, các thành viên tham dự đã nêu tình hình chung đặc điểm giảng viên tham gia giảng dạy, sinh viên tham gia học tập, kết quả đánh giá của sinh viên trong năm học 2020-2021. Các vấn đề về đề thi; những thuận lợi khó khăn trong giảng dạy cũng được bàn luận, trao đổi. Trên cơ sở đó, Khoa sẽ nghiên cứu xây dựng nội dung học phần, đưa ra những định hướng trong năm tới trên nền tảng kiến thức của sinh viên.
                                    </p>
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
