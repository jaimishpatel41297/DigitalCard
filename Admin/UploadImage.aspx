<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="UploadImage.aspx.cs" Inherits="Admin_UploadImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="jumbotron-1">
        <div class="jumbotron jumbotron-fluid">
            <div class="container-fluid">
                <!-- <button class="btn btn-rounded btn-primary btn-outline">Message</button>
                <button class="btn btn-rounded btn-primary btn-outline">Follow</button> -->
                <h5>Digital BCards</h5>
                <ol class="breadcrumb icon-home icon-angle-right no-bg">
                    <li>
                        <a href="Profile.aspx">Dashboard </a>
                    </li>
                    <li class="active">Display Photo</li>
                </ol>
                <!--   <button type="button" class="btn btn-raised btn-info bmd-btn-fab" data-toggle="dropdown">
                <i class="fa fa-ellipsis-v"></i>
            </button> -->

            </div>
        </div>
    </div>




    <div class="col-xs-12 main">
        <div class="page-on-top">
            <!-- forms/validation -->
            <form method="post" id="form" enctype="multipart/form-data">
                <div class="row m-b-20  rwupload">

                    <div class="col-xl-12 col-xs-12 sharedbg shte">            
                    <h4><a href="profile.html"><button class="btn btn-primary btn" style="width: 100%;background-color:#d49100 !important;color:#fff !important;    font-size: 19px;">Your Profile Picture</button></a></h4>
                </div>

                    <div class="col-xs-12 col-xl-12">
                        <div class="widget">



                            <div class="alert alert-success alert-dismissable" id="divSuccess" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                Success ! Data Successfully Inserted..
                            </div>
                            <div class="alert alert-danger alert-dismissable" id="divError" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                Failure !
                            </div>

                            <div class="row" style="overflow-x: hidden;margin-top: 30px;">
                                <div class="col-xl-6 ">

                                    <!-- <div class="cropme" style="width: 200px; height: 200px;"></div> -->
                                    <input type="hidden" name="crop_me_img" id="crop_me_img">

                                    <div class="row" style="display: inline-block;">

                                        <asp:FileUpload ID="File" runat="server" />
                                        <%--<input type="file" name="upload_image" onchange="checkfile( this )" id="upload_image" />--%>

                                        <hr>
                                        <div id="div2">
                                            <!-- <h4 class="modal-title">Upload & Crop Image</h4> -->
                                            
                                            <%--<div id="image_demo" style="width: 350px; max-width: 100%; margin-top: 30px">--%>
                                               <%--<img src="img/bg1234.jpg" alt="" height=280>--%>
                                                
                                            </div>
                                            <!-- <button type="button" id="abc" class="btn btn-primary button button-blue crop_image crimg">Crop</button> -->
                                        </div>
                                        <div id="div3">
                                            <div class="col-xs-12 col-xl-11 uploadleft ">
                                                <div class="form-group bmd-form-group">
                                                    <!-- <label class="bmd-label-static  ">Image</label> -->

                                                    <asp:Literal runat="server" ID="Ltrimage"></asp:Literal>
                                                    
                                                    <%--<img class="uploadcard " width="180" height="190" src="img/bg1234.jpg" style="padding-top: 0%;">--%>
                                                </div>
                                            </div>

                                        </div>


                                    </div>

                                </div>

                            </div>


                        </div>
                        <div class="col-xs-12 col-xl-12">

                            <div class="row  btntop  textcen1">

                                <div class="col-xl-2 col-xs-12 col-sm-4 sub1 ">

                                    <a href="#">
                                        <asp:Button ID="Button1" runat="server" class="btn btn-primary btnsz btn1" Text="Upload" OnClick="lbSubmit_Click" />
                                        <%--<button type="button" id="abc" class="btn btn-primary btnsz1  button button-blue crop_image crimg">Submit</button>

                                        <button class="btn btn-primary   btnsz1 " id="sub_check" type="submit" style="display: none;" name="add_am">Submit</button></a>--%>
                                </div>
                                <%--<div class="col-xl-3 col-xs-12 col-sm-4">
                                    <a href="../Default.aspx" target="_blank">
                                        <button class="btn btn-primary   btnsz1 " type="button" name="">Preview Card</button></a>
                                </div>--%>
                                <div class="col-xl-2 col-xs-12 col-sm-4">
                                    <a href="ContactDetail.aspx">
                                        <button class="btn btn-primary  btnsz1 " type="button" name="">Next</button></a>

                                    <!-- <a href="#" data-toggle="modal" data-target="#myModal"><button class="btn btn-primary" >Create</button></a> -->

                                </div>

                            </div>

                        </div>



                    </div>
                    <!-- forms/validation -->
                </div>
        </div>






    </div>








</asp:Content>

