<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="Admin_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="jumbotron-1">
        <div class="jumbotron jumbotron-fluid">
            <div class="container-fluid">
                <!-- <button class="btn btn-rounded btn-primary btn-outline">Message</button>
                <button class="btn btn-rounded btn-primary btn-outline">Follow</button> -->
                <!-- <h1 class="display-3">Welcome</h1> -->

                <div class="row">
                    <ol class="breadcrumb icon-home icon-angle-right no-bg">
                        <li style="padding-left: 10px;">
                            <a href="#">Create / Update Your Card</a>
                        </li>
                        <%--<br>
                    <li style="padding-left: 10px;margin-top: 30px;">
                        <a href="#">
                        >> WelCome Pratik</a>
                    </li>--%>
                        <!-- <li class="active">
                        Geographic </li> -->
                    </ol>
                    <!-- <div class="col-xl-1  col-md-2 col-sm-2 col-xs-4 bgcolor" style="">
                    <div class="cd-imgbox">
                    <div class="qrimg ">
                    <center><img src="https://chart.googleapis.com/chart?cht=qr&chl=Hello+World&chs=160x160&chld=L|0"
                    class="qr-code img-thumbnail img-responsive"></center>
                    </div>
                    </div>
                    </div> -->
                </div>

            </div>
        </div>
    </div>


    <div class="col-xs-12 main">
        <div class="page-on-top" style="height: 505px;">
            <!-- forms/validation -->
            <div class="row">
                <div class="col-xl-12 col-xs-12 sharedbg shte">
                    <h4><a href="profile.html">
                        <button class="btn btn-primary btn" style="width: 100%; background-color: #d49100 !important; color: #fff !important; font-size: 19px;">Your Digital Card </button>
                    </a></h4>
                </div>
                <!-- <div class="col-xl-1 col-xs-2">
                        <i class="fa fa-edit shared" > </i>
                    </div> -->
            </div>
            <div class="row">
                <div class="col-xs-6 col-sm-4 col-xl-4">
                    <a href="AboutMe.aspx">
                        <div class="text-widget-1 ">
                            <div class="row flex-items-xs-middle bg-blue-900">
                                <div class="col-xs-4 bg-blue-700 color-white">
                                    <i class="material-icons call" style="margin-top: 0%;">person</i>
                                </div>
                                <div class="col-xs-8">
                                    <div class="title" style="color: white; margin-top: -0%;">About Me</div>
                                    <div class="subtitle"><span></span><span class="counter-1"></span></div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>

                <div class="col-xs-6 col-sm-4 col-xl-4">
                    <a href="UploadImage.aspx">
                        <div class="text-widget-1 color-white">
                            <div class="row flex-items-xs-middle bg-blue-900">
                                <div class="col-xs-4 bg-blue-700">
                                    <i class="material-icons call" style="margin-top: -0%;">portrait</i>
                                </div>
                                <div class="col-xs-8">
                                    <div class="title" style="margin-top: -0%;">Profile Photo</div>
                                    <div class="subtitle"><span></span><span class="counter-1"></span></div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-xs-6 col-sm-4 col-xl-4">
                    <a href="ContactDetail.aspx">
                        <div class="text-widget-1 color-white">
                            <div class="row flex-items-xs-middle bg-blue-900">
                                <div class="col-xs-4 bg-blue-700">
                                    <i class="material-icons call" style="margin-top: -0%;">contact_mail</i>
                                </div>
                                <div class="col-xs-8">
                                    <div class="title" style="margin-top: -0%;">Contact Info</div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>


                <div class="col-xs-6 col-sm-4 col-xl-4">
                    <a href="Company.aspx">

                        <div class="text-widget-1 color-white">
                            <div class="row flex-items-xs-middle bg-blue-900">
                                <div class="col-xs-4 bg-blue-700">
                                    <i class="fa fa-building-o call" style="margin-top: -0%;"></i>
                                </div>
                                <div class="col-xs-8">
                                    <div class="title" style="margin-top: -0%;">Company</div>

                                </div>
                            </div>
                        </div>
                    </a>
                </div>

                <div class="col-xs-6 col-sm-4 col-xl-4">
                    <a href="SocialLink.aspx">

                        <div class="text-widget-1 color-white">
                            <div class="row flex-items-xs-middle bg-blue-900">
                                <div class="col-xs-4 bg-blue-700">
                                    <i class="material-icons call" style="margin-top: -0%;">share</i>
                                </div>
                                <div class="col-xs-8">
                                    <div class="title" style="margin-top: -0%;">Social Links</div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>

                <div class="col-xs-6 col-sm-4 col-xl-4">
                    <a href="Services.aspx">

                        <div class="text-widget-1 color-white">
                            <div class="row flex-items-xs-middle bg-blue-900">
                                <div class="col-xs-4 bg-blue-700">
                                    <i class="material-icons call" style="margin-top: -0%;">web</i>
                                </div>
                                <div class="col-xs-8">
                                    <div class="title" style="margin-top: -0%;">Services</div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>

               <%-- <div class="col-xs-6 col-sm-4 col-xl-4">
                    <a href="SocialLink.aspx">

                        <div class="text-widget-1 color-white">
                            <div class="row flex-items-xs-middle bg-blue-900">
                                <div class="col-xs-4 bg-blue-700">

                                    <i class="material-icons addindex">share</i>
                                    <%-- <i class="material-icons" style="margin-top: -0%;">share</i>--%>
                                </div>
                                <div class="col-xs-8">
                                    <div class="title" style="margin-top: -0%;">Offer </div>
                                </div>
                            </div>
                        </div>
                    </a>
                </div>--%>
         
                <%--<div class="col-xs-6 col-sm-4 col-xl-4">
                                <a href="payment_link.html">

                                <div class="text-widget-1 color-white">
                                    <div class="row flex-items-xs-middle bg-blue-900">
                                        <div class="col-xs-4 bg-blue-700">
                                            <i class="fa fa-link call"></i>
                                        </div>
                                        <div class="col-xs-8">
                                            <div class="title">Payment Link</div>
                                            </div>
                                    </div>
                                </div>
                                 </a>
                            </div>--%>

                <%--<div class="col-xs-6 col-sm-4 col-xl-4">
                                <a href="gallery.html">

                                <div class="text-widget-1 color-white">
                                    <div class="row flex-items-xs-middle bg-blue-900">
                                        <div class="col-xs-4 bg-blue-700">
                                            <i class="material-icons call">photo_library</i>
                                        </div>
                                        <div class="col-xs-8">
                                            <div class="title">Product Album</div>
                                            </div>
                                    </div>
                                </div>
                                 </a>
                            </div>--%>

                <%--<div class="col-xs-6 col-sm-4 col-xl-4">
                                <a href="offer.html">

                                <div class="text-widget-1 color-white">
                                    <div class="row flex-items-xs-middle bg-blue-900">
                                        <div class="col-xs-4 bg-blue-700">
                                            <i class="material-icons call">class</i>
                                        </div>
                                        <div class="col-xs-8">
                                            <div class="title">Offers</div>
                                            </div>
                                    </div>
                                </div>
                                 </a>
                            </div>--%>


                <%--<div class="col-xs-6 col-sm-4 col-xl-4">
                                <a href="key_clients.html">

                                <div class="text-widget-1 color-white">
                                    <div class="row flex-items-xs-middle bg-blue-900">
                                        <div class="col-xs-4 bg-blue-700">
                                           <i class="fa fa-certificate  call"></i>
                                        </div>
                                        <div class="col-xs-8">
                                            <div class="title" >Key Clients</div>
                                        </div>
                                    </div>
                                </div>
                                 </a>
                            </div>--%>

                <%--<div class="col-xs-6 col-sm-4 col-xl-4">
                                <a href="all_memberships.html">

                                <div class="text-widget-1 color-white">
                                    <div class="row flex-items-xs-middle bg-blue-900">
                                        <div class="col-xs-4 bg-blue-700">
                                           <i class="fa fa-user-plus call"></i>
                                        </div>
                                        <div class="col-xs-8">
                                            <div class="title" >Membership</div>
                                        </div>
                                    </div>
                                </div>
                                 </a>
                            </div>--%>
            </div>
            <hr>
            <br>
            <div class="row">
                <!-- <div class="col-xl-2 col-xs-12 col-sm-3">
                        <a href="vcard_theme.php"><button class="btn btn-primary" type="button" name="">card Theme</button></a>
                    </div> -->
                <div class="col-xl-2 col-xs-6 col-sm-4">
                    <a href="theme.aspx">
                        <button type="button" class="btn btn-primary btnsz1">Theme</button>
                    </a>
                </div>
                <%--<div class="col-xl-3 col-xs-6 col-sm-4 textcen">
                    <a href="../Default.aspx" target="_blank">
                        <button class="btn btn-primary btnsz1" type="button" name="">Preview Card</button></a>
                </div>--%>
                <%--<div class="col-xl-2 col-xs-6 col-sm-4">
                        <a href="index.html"><button class="btn btn-primary btnsz1" type="button" name="">Dashboard</button></a></div>--%>
            </div>


            <!-- <div class="col-xs-12 col-sm-6 col-xl-4">
                            <a href="manage-tag.php">
                            <div class="text-widget-1 color-white">
                                <div class="row flex-items-xs-middle bg-blue-900">
                                    <div class="col-xs-4 bg-blue-700">
                                        <i class="material-icons" style="font-size: 50px;">local_offer</i>
                                    </div>
                                    <div class="col-xs-8">
                                        <div class="title">Manage Tag</div>
                                        <div class="subtitle"><span class="counter-2">0</span></div>
                                    </div>
                                </div>
                            </div>
                        </div> -->


            <!-- forms/validation -->
        </div>
    </div>

    <!-- build:js js/vendor.js -->
    <script src="bower_components/jquery/dist/jquery.min.js"></script>
    <script src="bower_components/lodash/dist/lodash.min.js"></script>
    <script src="components/scripts/modernizr.js"></script>
    <script src="bower_components/tether/dist/js/tether.js"></script>
    <script src="bower_components/jquery-storage-api/jquery.storageapi.min.js"></script>

    <script src="bower_components/mousetrap/mousetrap.js"></script>
    <script src="bower_components/bootstrap-material-design/dist/bootstrap-material-design.iife.js"></script>

    <script src="bower_components/fakeLoader/fakeLoader.min.js"></script>

    <script src="https://maps.googleapis.com/maps/api/js?v=3.exp&amp;libraries=weather,visualization,panoramio&amp;key=AIzaSyDRuAzjz4dLpeQnvW4D8qZ7mX-G0pAZEcI"></script>
    <!-- build:js js/main.js -->
    <script src="scripts/functions.js"></script>
    <script src="scripts/colors.js"></script>
    <script src="scripts/app.js"></script>
    <script src="scripts/elements/left-sidebar.js"></script>
    <script src="scripts/elements/navbar-1.js"></script>
    <script src="scripts/elements/navbar-2.js"></script>
    <script src="scripts/elements/navbar-3.js"></script>

    <script src="scripts/icons/material-design-icons.js"></script>
    <script src="scripts/icons/font-awesome.js"></script>
    <script src="scripts/icons/flags.js"></script>
    <script src="scripts/icons/ionicons.js"></script>
    <script src="scripts/icons/weather-icons.js"></script>

    <script src="scripts/pages/index.js"></script>
    <!-- endbuild -->
    <div class="right-sidebar-backdrop"></div>
    <script type="text/javascript">

        function AllowNumbersOnly(e) {
            var code = (e.which) ? e.which : e.keyCode;
            if (code > 31 && (code < 48 || code > 57)) {
                e.preventDefault();
            }
        }

        // $(document).ready(function(){
        //     $(".qr-code").attr("src", "https://chart.googleapis.com/chart?cht=qr&chl=" + 'Bcard.php?zxc=' + "&chs=160x160&chld=L|0");
        // });

    </script>
    <!-- endbuild -->






</asp:Content>

