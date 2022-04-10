<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Digitalcard.aspx.cs" Inherits="Digitalcard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-125314689-2"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-125314689-2');
</script>

    <!--
		Basic
	-->
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Digital Cards</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="Digital Card" />
    <meta name="keywords" content="vcard, resposnive, resume, personal, card, cv, cards, portfolio" />
    <meta name="author" content="beshleyua" />

    <link rel="stylesheet" href="newassets/css/bootstrap.min.css">
    <!--
		Load Fonts
	-->
    <link href="https://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">
    <link rel="stylesheet" href="../css/all.css" />

    <!--
		Load CSS
	-->
    <link rel="stylesheet" href="../vcard/css/basic.css" />
    <link rel="stylesheet" href="../vcard/css/layout.css" />
    <link rel="stylesheet" href="../vcard/css/blogs.css" />
    <link rel="stylesheet" href="../vcard/css/ionicons.css" />
    <link rel="stylesheet" href="../vcard/css/magnific-popup.css" />
    <link rel="stylesheet" href="../vcard/css/animate.css" />
    <link rel="stylesheet" href="../vcard/css/gradient.css" />

    <!--
		Template Colors
	-->

    <asp:Literal ID="Ltrtheme" runat="server"></asp:Literal>
    <%-- <link rel="stylesheet" href="../css/template-colors/blue.css" />
    <link rel="stylesheet" href="../css/template-colors/orange.css" />
    <link rel="stylesheet" href="../css/template-colors/pink.css" />
    <link rel="stylesheet" href="../css/template-colors/purple.css" />
    <link rel="stylesheet" href="../css/template-colors/red.css" />
    <link rel="stylesheet" href="../css/template-colors/green.css" />--%>
    <%--<link rel="stylesheet" href="css/template-dark/dark.css">--%>

    <!--[if lt IE 9]>
	<script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script>
	<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->

    <!--
		Favicons
	-->
    <link rel="shortcut icon" href="../vcard/images/title.png">

    <%--<link rel="stylesheet" href="css/template-dark/dark.css">--%>
</head>

<body>

    <div class="page">

        <div class="theme_panel">
            <div class="toggle_bts">
                <a class="toggle-theme-panel" href="#">
                    <i class="ion ion-android-settings"></i>
                </a>
            </div>

            <div class="theme_menu">
                <h4>Color Switcher</h4>
                <div class="segment">
                    <ul class="theme layout_style">
                        <li>
                            <a title="theme-green" href="#" data-color="green" style="background-color: rgba(46, 202, 127, 1);"></a>
                        </li>
                        <li>
                            <a title="theme-blue" href="#" data-color="blue" style="background-color: rgba(8, 86, 193, 1);"></a>
                        </li>
                        <li>
                            <a title="theme-orange" href="#" data-color="orange" style="background-color: rgba(255, 152, 0, 1);"></a>
                        </li>
                        <li>
                            <a title="theme-pink" href="#" data-color="pink" style="background-color: rgba(255, 94, 148, 1);"></a>
                        </li>
                        <li>
                            <a title="theme-purple" href="#" data-color="purple" style="background-color: rgba(196, 70, 218, 1);"></a>
                        </li>
                        <li>
                            <a title="theme-red" href="#" data-color="red" style="background-color: rgba(232, 103, 107, 1);"></a>
                        </li>
                    </ul>
                </div>
                <div class="clear"></div>
                <h4>Dark/Light Version</h4>
                <ul class="theme demo_list dark_style">
                    <li style="width: 50%;"><a href="#" data-dark="dark"><strong>Dark</strong></a></li>
                    <li style="width: 50%;"><a href="#" data-dark="light"><strong>Light</strong></a></li>
                </ul>

                <%--<div class="clear"></div>
				<a href="https://themeforest.net/item/ryan-vcard-resume-cv-template/21584603?ref=beshleyua" class="buy-btn"><i class="ion ion-android-cart"></i>Buy Template</a>--%>
            </div>
        </div>

        <!-- preloader -->
        <div class="preloader">
            <div class="centrize full-width">
                <div class="vertical-center">
                    <div class="spinner">
                        <div class="double-bounce1"></div>
                        <div class="double-bounce2"></div>
                    </div>
                </div>
            </div>
        </div>

        <!-- background -->
        <div class="background gradient">
            <ul class="bg-bubbles">
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
                <li></li>
            </ul>
        </div>

        <!--
			Container
		-->
        <div class="container opened" data-animation-in="fadeInLeft" data-animation-out="fadeOutLeft">

            <!--
				Header
			-->
            <header class="header">

                <!-- menu -->
                <div class="top-menu">
                    <ul>
                        <li class="active">
                            <a href="#about-card">
                                <span class="icon ion-person"></span>
                                <span class="link">About</span>
                            </a>
                        </li>
                        <li>
                            <a href="#resume-card">
                                <span class="icon ion-android-list"></span>
                                <span class="link">Service</span>
                            </a>
                        </li>
                        <li>
                            <a href="#resume-card">
                                <span class="icon ion-android-list"></span>
                                <span class="link">Offers</span>
                            </a>
                        </li>
                        <li>
                            <a href="#contacts-card">
                                <span class="icon ion-at"></span>
                                <span class="link">Contact</span>
                            </a>
                        </li>
                    </ul>
                </div>

            </header>

            <!--
				Card - Started
			-->

            <div class="card-started" id="home-card">

                <!--
					Profile
				-->
                <div class="profile">


                    <!-- profile image -->
                    <div class="slide" style="background-image: url(https://beshley.com/vcard/images/bg.jpg);"></div>

                    <!-- profile photo -->

                    <asp:Literal runat="server" ID="Ltrimage"></asp:Literal>

                    <%--<div class="image">
						<img src="../vcard/images/img.jpg" alt="" / style="height: 140px;">
					</div>--%>

                    <!-- profile titles -->
                    <asp:Literal runat="server" ID="Ltrbasic"></asp:Literal>

                    <%--<div class="title">Arpit Shah</div>
					<div class="subtitle">CEO - IT futurz</div>--%>

                    <!-- profile socials -->
                    <div class="social">
                        <asp:Literal runat="server" ID="Ltrsocial"></asp:Literal>

                        <%--<a target="_blank" href="https://dribbble.com/"><span class="fab fa-facebook"></span></a>
						<a target="_blank" href="https://twitter.com/"><span class="fab fa-instagram"></span></a>
						<a target="_blank" href="https://github.com/"><span class="fab fa-twitter"></span></a>--%>
                    </div>


                    <!-- profile buttons -->
                    <div class="lnks">

                        <a href="#" data-toggle="modal" data-target="#myModal1" class="lnk discover">
                            <span class="text">Share Card</span>
                            <span class="ion ion-share"></span>

                        </a>

                        <a href="#" runat="server" class="lnk" style="float: initial;" id="save1">

                            <%--<asp:Button ID="Button1" runat="server" class="btn btn-primary btnsz btn1" Text="Submit" OnClick="lbVcf_Click" />--%>

                            <span class="text">Save My Card</span>
                            <span class="ion ion-archive"></span>
                        </a>

                    </div>

                </div>

            </div>

            <!-- 
				Card - About
			-->
            <div class="card-inner animated active" id="about-card">
                <div class="card-wrap">

                    <!-- 
						About 
					-->
                    <div class="content about">

                        <!-- title -->
                        <div class="title">About Me</div>

                        <!-- content -->
                        <div class="row">
                            <div class="col col-d-12 col-t-12 col-m-12 border-line-v">
                                <asp:Literal runat="server" ID="Ltrabout"></asp:Literal>

                                <%--	<div class="text-box">
									<p>
										I am Arpit Shah.
									</p>
								</div>
								<div class="info-list">
									<ul>
										<li><strong>Company Name . . .</strong> 30</li>
                                        <br>
										<li><strong>Website  . . . . . . . . . . . .</strong> INDIA</li>
										<%--<li><strong>Freelance . . . . .</strong> Available</li>
										<li><strong>Address . . . . .</strong> Gujarat, India</li>--%>
                                <%--</ul>--%>
                                <%--</div>--%>
                            </div>
                            <div class="clear"></div>
                        </div>

                    </div>

                    <!--
						Services
					-->
                    <div class="content services">

                        <!-- title -->
                        <div class="title">My Services</div>

                        <!-- content -->
                        <div class="row service-items border-line-v">

                            <!-- service item -->
                            <div class="col col-d-6 col-t-6 col-m-12 border-line-h">
                                <div class="service-item">
                                    <div class="icon"><span class="ion ion-briefcase"></span></div>

                                    <div class="name">Web Development</div>
                                    <p>
                                        Modern and mobile-ready website that will help you 
										reach all of your marketing.
								
                                    </p>
                                </div>
                            </div>

                            <!-- service item -->
                            <%--<div class="col col-d-6 col-t-6 col-m-12 border-line-h">
								<div class="service-item">
									<div class="icon"><span class="ion ion-music-note"></span></div>
									<div class="name">Music Writing</div>
									<p>
										Music copying, transcription, arranging and composition services.
									</p>
								</div>
							</div>--%>

                            <!-- service item -->
                            <%--<div class="col col-d-6 col-t-6 col-m-12">
								<div class="service-item">
									<div class="icon"><span class="ion ion-speakerphone"></span></div>
									<div class="name">Advetising</div>
									<p>
										Advertising services include television, radio, print, mail and web.
									</p>
								</div>
							</div>--%>

                            <!-- service item -->
                            <%--<div class="col col-d-6 col-t-6 col-m-12">
								<div class="service-item">
									<div class="icon"><span class="ion ion-ios-game-controller-b"></span></div>
									<div class="name">Game Development</div>
									<p>
										Developing memorable and unique mobile android, ios games.
									</p>
								</div>
							</div>--%>

                            <div class="clear"></div>
                        </div>

                    </div>

                    <!--
						Price Tables
					-->
                    <%--<div class="content pricing">

						<!-- title -->
						<div class="title">Pricing</div>

						<!-- content -->
						<div class="row pricing-items">

							<!-- pricing item -->
							<div class="col col-d-6 col-t-6 col-m-12 border-line-v">
								<div class="pricing-item">
									<div class="icon"><i class="ion ion-speedometer speed-basic"></i></div>
									<div class="name">Basic</div>
									<div class="amount">
										<span class="dollar">$</span>
										<span class="number">22</span>
										<span class="period">hour</span>
									</div>
									<div class="feature-list">
										<ul>
											<li>Web Development</li>
											<li>Advetising</li>
											<li>Game Development</li>
											<li class="disable">Music Writing</li>
											<li class="disable">Photography <strong>new</strong></li>
										</ul>
									</div>
									<div class="lnks">
										<a href="#" class="lnk">
											<span class="text">Buy Basic</span>
											<i class="ion ion-speedometer speed-basic"></i>
										</a>
									</div>
								</div>
							</div>

							<!-- pricing item -->
							<div class="col col-d-6 col-t-6 col-m-12 border-line-v">
								<div class="pricing-item">
									<div class="icon"><i class="ion ion-speedometer"></i></div>
									<div class="name">Pro</div>
									<div class="amount">
										<span class="dollar">$</span>
										<span class="number">48</span>
										<span class="period">hour</span>
									</div>
									<div class="feature-list">
										<ul>
											<li>Web Development</li>
											<li>Advetising</li>
											<li>Game Development</li>
											<li>Music Writing</li>
											<li>Photography <strong>new</strong></li>
										</ul>
									</div>
									<div class="lnks">
										<a href="#" class="lnk">
											<span class="text">Buy Pro</span>
											<i class="ion ion-speedometer"></i>
										</a>
									</div>
								</div>
							</div>

							<div class="clear"></div>
						</div>

					</div>--%>

                    <!--
						Fun Fact
					-->
                    <%--<div class="content fuct">

						<!-- title -->
						<div class="title">Fun Fact</div>

						<!-- content -->
						<div class="row fuct-items">

							<!-- fuct item -->
							<div class="col col-d-3 col-t-3 col-m-6 border-line-v">
								<div class="fuct-item">
									<div class="icon"><span class="ion ion-disc"></span></div>
									<div class="name">80 Albumes Listened</div>
								</div>
							</div>

							<!-- fuct item -->
							<div class="col col-d-3 col-t-3 col-m-6 border-line-v">
								<div class="fuct-item">
									<div class="icon"><span class="ion ion-trophy"></span></div>
									<div class="name">15 Awards Won</div>
								</div>
							</div>

							<!-- fuct item -->
							<div class="col col-d-3 col-t-3 col-m-6 border-line-v">
								<div class="fuct-item">
									<div class="icon"><span class="ion ion-coffee"></span></div>
									<div class="name">1 000 Cups of coffee</div>
								</div>
							</div>

							<!-- fuct item -->
							<div class="col col-d-3 col-t-3 col-m-6 border-line-v">
								<div class="fuct-item">
									<div class="icon"><span class="ion ion-flag"></span></div>
									<div class="name">10 Countries Visited</div>
								</div>
							</div>

							<div class="clear"></div>
						</div>

					</div>--%>

                    <!--
						Clients
					-->
                    <%--<div class="content clients">

						<!-- title -->
						<div class="title">Clients</div>

						<!-- content -->
						<div class="row client-items">

							<!-- client item -->
							<div class="col col-d-3 col-t-3 col-m-6 border-line-v">
								<div class="client-item">
									<div class="image">
										<a target="_blank" href="https://www.google.com/">
											<img src="https://beshley.com/vcard/images/clients/client_1.png" alt="" />
										</a>
									</div>
								</div>
							</div>

							<!-- client item -->
							<div class="col col-d-3 col-t-3 col-m-6 border-line-v">
								<div class="client-item">
									<div class="image">
										<a target="_blank" href="https://www.google.com/">
											<img src="https://beshley.com/vcard/images/clients/client_2.png" alt="" />
										</a>
									</div>
								</div>
							</div>

							<!-- client item -->
							<div class="col col-d-3 col-t-3 col-m-6 border-line-v">
								<div class="client-item">
									<div class="image">
										<a target="_blank" href="https://www.google.com/">
											<img src="https://beshley.com/vcard/images/clients/client_3.png" alt="" />
										</a>
									</div>
								</div>
							</div>

							<!-- client item -->
							<div class="col col-d-3 col-t-3 col-m-6 border-line-v">
								<div class="client-item">
									<div class="image">
										<a target="_blank" href="https://www.google.com/">
											<img src="https://beshley.com/vcard/images/clients/client_4.png" alt="" />
										</a>
									</div>
								</div>
							</div>

							<div class="clear"></div>
						</div>

					</div>--%>
                </div>
            </div>

            <!--
				Card - Resume
			-->
            <div class="card-inner" id="resume-card">
                <div class="card-wrap">

                    <!--
						Conacts Info
					-->
                    <div class="content contacts">

                        <!-- title -->
                        <div class="title">Company Details</div>

                        <!-- content -->
                        <div class="row">
                            <div class="col col-d-12 col-t-12 col-m-12 border-line-v">
                                <asp:Literal runat="server" ID="Ltrcompany"></asp:Literal>

                                <%--<div class="info-list">
									<ul>
										<li><strong><i class="fas fa-map-marker-alt"></i>&nbsp;Address</strong><br> O/1,Madhulika apartment,opp. Milk palace,bhatar road,Surat</li>
                                        <br>
                                        <br>
										<li><strong><i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Email </strong><br> info@itfururz.com</li>
                                        <br>
                                        <br>
										<li><strong><i class="fa fa-phone" aria-hidden="true"></i>&nbsp;Phone </strong><br> +91 9879208321</li>
                                        <br>
                                        <br>
										<li><strong><i class="fa fa-at" aria-hidden="true"></i>&nbsp;URL</strong><br> https://www.Itfuturz.com/</li>
									</ul>
								</div>
                                <br></br>
                                <div>
                                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3720.443610832449!2d72.81322061501521!3d21.174529485919535!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3be04f6b3a98a7b1%3A0xb4d6fd6d223cbb4f!2sIt+Futurz!5e0!3m2!1sen!2sin!4v1541490459924" width="350" height="300" frameborder="0" style="border:0" allowfullscreen></iframe>


								</div>--%>
                            </div>
                            <div class="clear"></div>
                        </div>

                    </div>



                </div>
            </div>



            <!--
				Card - Blog
			-->
            <%--<div class="card-inner blog" id="blog-card">
				<div class="card-wrap">

					<!--
						Blog
					-->
					<div class="content blog">

						<!-- title -->
						<div class="title">Latest Posts</div>

						<!-- content -->
						<div class="row border-line-v">

							<!-- blog item -->
							<div class="col col-d-12 col-t-12 col-m-12 border-line-h">
								<div class="box-item">
									<div class="image">
										<a href="https://beshley.com/vcard/blog-post.html">
											<img src="https://beshley.com/vcard/images/blog/blog1.jpg" alt="" />
											<span class="info">
												<span class="ion ion-document-text"></span>
											</span>
											<span class="date"><strong>20</strong>Jun</span>
										</a>
									</div>
									<div class="desc">
										<a href="https://beshley.com/vcard/blog-post.html" class="name">By spite about do of do allow blush</a>
										<div class="category">Design</div>
									</div>
								</div>
							</div>

							<!-- blog item -->
							<div class="col col-d-12 col-t-12 col-m-12 border-line-h">
								<div class="box-item">
									<div class="image">
										<a href="https://beshley.com/vcard/blog-post.html">
											<img src="https://beshley.com/vcard/images/blog/blog2.jpg" alt="" />
											<span class="info">
												<span class="ion ion-document-text"></span>
											</span>
											<span class="date"><strong>19</strong>Jun</span>
										</a>
									</div>
									<div class="desc">
										<a href="https://beshley.com/vcard/blog-post.html" class="name">Two Before Arrow Not Relied</a>
										<div class="category">Coding</div>
									</div>
								</div>
							</div>

							<!-- blog item -->
							<div class="col col-d-12 col-t-12 col-m-12 border-line-h">
								<div class="box-item">
									<div class="image">
										<a href="https://beshley.com/vcard/blog-post.html">
											<img src="https://beshley.com/vcard/images/blog/blog3.jpg" alt="" />
											<span class="info">
												<span class="ion ion-document-text"></span>
											</span>
											<span class="date"><strong>20</strong>Jun</span>
										</a>
									</div>
									<div class="desc">
										<a href="https://beshley.com/vcard/blog-post.html" class="name">By spite about do of do allow blush</a>
										<div class="category">Travel</div>
									</div>
								</div>
							</div>

							<div class="clear"></div>
						</div>

					</div>

				</div>
			</div>--%>

            <!--
				Card - Contacts
			-->
            <div class="card-inner contacts" id="contacts-card">
                <div class="card-wrap">

                    <!--
						Conacts Info
					-->
                    <div class="content contacts">

                        <!-- title -->
                        <div class="title">Get in Touch</div>

                        <!-- content -->
                        <div class="row">
                            <div class="col col-d-12 col-t-12 col-m-12 border-line-v">

                                <div class="info-list">
                                    <asp:Literal runat="server" ID="Ltrcontact"></asp:Literal>
                                    <%--<ul>
										<li><strong><i class="fa fa-phone" aria-hidden="true"></i>&nbsp;Mobile</strong><br> +91 9879208321</li>
                                        <br>
                                        <br>
										<li><strong><i class="fa fa-envelope" aria-hidden="true"></i>&nbsp;Email </strong><br> info@itfuturz.com</li>
                                        <br>
                                        <br>
										<li><strong><i class="fab fa-whatsapp"></i>&nbsp;Whatsapp </strong><br> +91 9879208321</li>
                                        <br>
                                        <br>
										<li><strong><i class="fab fa-facebook"></i>&nbsp;Facebook</strong><br>https://www.fb.com/ITFuturz/</li>
									</ul>--%>
                                </div>
                            </div>
                            <div class="clear"></div>
                        </div>

                    </div>


                </div>
            </div>

        </div>
    </div>

    <div class="modal fade" id="myModal1" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Share Me</h4>
                </div>
                <div class="modal-body">
                    <center>           <div class="box">
                        <div class="bgtop"><!-- Share This --></div><br>
                        
                        <h6 style="color: #000">Share my Digital BCard in your network.</h6>
                        <br>
                        
                       <%-- <a href="https://api.whatsapp.com/send?text=Hey%2C%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link%20%0Ahttp%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D%20%0A%0A%0ASay%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20.%0A%0A%0A"> <i class="fab fa-whatsapp-square" style="font-size: 35px;"></i></a>--%>
                        <a href="" data-toggle="modal" data-target="#myModal3"> <i class="fab fa-whatsapp-square" style="font-size: 35px;"></i></a>
                        &nbsp;&nbsp;
                                       
                        <!-- <a href="https://www.facebook.com/sharer/sharer.php?u=Hey,  I am using this Digital Business Card. I loved using it. Have a look at it from the below link 
http%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D 


Say goodbye to Cards.  Use Digital Business Cards - You are one click away. . .


                        "><i class="fa fa-facebook facardfb"></i></a> -->

                        <a href="https://www.facebook.com/sharer/sharer.php?u=http://digitalbcards.in/Bcard.php?zxc=&amp;quote=Hey,%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link.Say%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20."><i class="fab fa-facebook" style="font-size: 35px;"></i></a>
                        &nbsp;&nbsp;

                        <%--<a href="https://twitter.com/intent/tweet?text=Hey%2C%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link%20%0Ahttp%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D%20%0A%0A%0ASay%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20.%0A%0A%0A&amp;source=&amp;related=shareaholic"> <i class="fa fa-twitter facardtt"></i></a>--%>

                        <%--<a href="https://plus.google.com/share?url=http://digitalbcards.in/Bcard.php?zxc=">  <i class="fa fa-google-plus facardgp"></i></a>--%>


                       <!--  <a href="https://www.linkedin.com/sharing/share-offsite/?url=Hey%2C%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link%20%0Ahttp%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D%20%0A%0A%0ASay%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20.%0A%0A%0A"> <i class="fa fa-linkedin facardld"></i></a> -->

                         <a href="https://www.linkedin.com/shareArticle?mini=true&amp;url=http://digitalbcards.in/Bcard.php?zxc=&amp;title=Hey%2C%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link%20%0Ahttp%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D%20%0A%0A%0ASay%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20.%0A%0A%0A&amp;source=LinkedIn"> <i class="fab fa-linkedin" style="font-size: 35px;"></i></a>
                        &nbsp;&nbsp;
                      <!--   https://www.linkedin.com/shareArticle?mini=true&url=http://developer.linkedin.com&title=LinkedIn%20Developer%20Network&summary=My%20favorite%20developer%20program&source=LinkedIn -->
                        <!-- <a href="http://pinterest.com/pin/create/button/?url=http%3A%2F%2Fandroappstech.in%2FDigitalbcard.in%2Fbcard_web%2FBcard.php%3Fzxc%3D&media=..%2Fupload%2F"> <img src="images/icon/pin.png" class="center-block"></a>  -->
                        <!-- <a href="https://in.pinterest.com/pin/../upload/"> <img src="images/icon/pin.png" class="center-block"></a>  -->
                        
                        <a href="" data-toggle="modal" data-target="#myModal2"> <i class="fa fa-envelope facardml" style="font-size: 35px;"></i></a>
                    </div></center>
                </div>

            </div>

        </div>
    </div>

    <form runat="server">
        <div class="modal fade" id="myModal2" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" style="height: 72px;">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <%--<h4 class="modal-title">Share Me</h4>--%>
                    </div>
                    <div class="modal-body">
                        <center>           <div class="box">
                        <div class="bgtop"><!-- Share This --></div><br>
                        
                        <h6 style="color: #000">Enter Mobile Number</h6>
                        <br>
                        <asp:TextBox ID="Txtnumber" class="form-control" runat="server" style="width: 285px;"></asp:TextBox>
                            <br><br>
                        <asp:Button ID="lbSubmit" runat="server" class="btn btn-primary btnsz btn1" Text="Send" OnClick="lbSend_Click" style="width: 140px;height: 50px;"/>
                        
                    </div></center>
                    </div>

                </div>

            </div>
        </div>
        <div class="modal fade" id="myModal3" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header" style="height: 72px;">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <%--<h4 class="modal-title">Share Me</h4>--%>
                    </div>
                    <div class="modal-body">
                        <center>           <div class="box">
                        <div class="bgtop"><!-- Share This --></div><br>
                        
                        <h6 style="color: #000">Enter Mobile Number</h6>
                        <br>
                        <asp:TextBox ID="Txtwa" class="form-control" runat="server" style="width: 285px;"></asp:TextBox>
                            <br><br>
                        <asp:Button ID="Button1" runat="server" class="btn btn-primary btnsz btn1" Text="Send" OnClick="lbSendwa_Click" style="width: 140px;height: 50px;"/>
                        
                    </div></center>
                    </div>

                </div>

            </div>
        </div>
    </form>


    <script type="text/javascript" src="newassets/js/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="newassets/js/bootstrap.min.js"></script>
    <script src="../cdnjs.cloudflare.com/ajax/libs/fancybox/3.4.1/jquery.fancybox.js"></script>
    <!--
		jQuery Scripts
	-->
    <script src="https://beshley.com/vcard/js/jquery.min.js"></script>
    <script src="https://beshley.com/vcard/js/jquery.validate.js"></script>
    <script src="https://beshley.com/vcard/js/jquery.magnific-popup.js"></script>
    <script src="https://beshley.com/vcard/js/imagesloaded.pkgd.js"></script>
    <script src="https://beshley.com/vcard/js/masonry.pkgd.js"></script>
    <script src="https://beshley.com/vcard/js/masonry-filter.js"></script>
    <script src="https://beshley.com/vcard/js/jquery.slimscroll.js"></script>



    <!--
		Google map api
	-->
    <script src="https://maps.google.com/maps/api/js?sensor=false"></script>

    <!--
		Main Scripts
	-->
    <script src="https://beshley.com/vcard/js/scripts.js"></script>


</body>

<!-- Mirrored from beshley.com/vcard/index-gradient.html by HTTrack Website Copier/3.x [XR&CO'2014], Thu, 25 Oct 2018 10:01:42 GMT -->
</html>
