<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="ContactDetail.aspx.cs" Inherits="Admin_ContactDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="jumbotron-1">
        <div class="jumbotron jumbotron-fluid">
            <div class="container-fluid">
                <!-- <button class="btn btn-rounded btn-primary btn-outline">Message</button>
                <button class="btn btn-rounded btn-primary btn-outline">Follow</button> -->
                <h1 class="display-3">Digital BCards</h1>
                <ol class="breadcrumb icon-home icon-angle-right no-bg">
                    <li>
                        <a href="Profile.aspx">Dashboard                    </a>
                    </li>
                    <li class="active">Contact Info</li>
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
            <form method="post">
                <div class="row m-b-20">

                    <div class="col-xl-12 col-xs-12 sharedbg shte">            
                    <h4><a href="profile.html"><button class="btn btn-primary btn" style="width: 100%;background-color:#d49100 !important;color:#fff !important;    font-size: 19px;">Your Contact Details</button></a></h4>
                </div>

                    <div class="col-xs-12 col-xl-12">
                        <div class="widget">

                            <div class="alert alert-success alert-dismissable" id="divSuccess" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                Success ! Data Successfully Inserted..
                            </div>
                            <div class="alert alert-danger alert-dismissable" id="divError" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                Failure ! Changes Not Done Successfully !
                            </div>
                            <div class="row" style="margin-top: 32px;">
                                <div class="col-xl-6">



                                    <div class="row">

                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Phone</label>
                                                <asp:TextBox ID="Txtmob" class="form-control" runat="server"></asp:TextBox>
                                                <%--<input type="text" class="form-control" id="phone" name="phone" minlength="10" maxlength="10" value="">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Email</label>
                                                <asp:TextBox ID="Txtemail" class="form-control" runat="server"></asp:TextBox>
                                                <%--<input type="email" class="form-control" id="email" name="email" value="">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Whatsapp</label>
                                                <asp:TextBox ID="Txtwhatsapp" class="form-control" runat="server"></asp:TextBox>
                                                <%-- <input type="text" class="form-control" id="whatsapp_no" name="whatsapp_no" value="" minlength="10" maxlength="10">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>
                                        <%-- <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Skype</label>
                                                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                                                <input class="form-control" type="text" id="skype" name="skype" value="">
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>--%>

                                        <div class="col-xs-12 col-xl-11">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">FB Page Messenger URL</label>
                                                <asp:TextBox ID="Txtfb" class="form-control" runat="server"></asp:TextBox>
                                                <%--<input type="text" class="form-control" id="fb_url" name="fb_url" value="https://www.facebook.com/">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>


                                    </div>

                                </div>


                            </div>
                            <div class="col-xs-12 col-xl-12">

                                <div class="row  btntop">

                                    <div class="col-xl-2 col-xs-12 col-sm-4 sub1 textcen">

                                        <a href="#">
                                           <asp:Button ID="lbSubmit" runat="server" class="btn btn-primary btnsz btn1" Text="Submit" OnClick="lbSubmit_Click" />
                                            <asp:Button ID="lbUpdate" runat="server" class="btn btn-primary btnsz btn1" Text="Update" OnClick="lbUpdate_Click" />
                                            <%--<button class="btn btn-primary btnsz1 " type="submit" name="add_am">Submit</button></a>--%>
                                    </div>
                                 <%--   <div class="col-xl-3 col-xs-12 col-sm-4 textcen">
                                        <a href="../Default.aspx" target="_blank">
                                            <button class="btn btn-primary btnsz1 " type="button" name="">Preview Card</button></a>
                                    </div>--%>
                                    <div class="col-xl-2 col-xs-12 col-sm-4 textcen">
                                        <a href="Company.aspx">
                                            <button class="btn btn-primary btnsz1 " type="button" name="">Next</button></a>

                                        <!-- <a href="#" data-toggle="modal" data-target="#myModal"><button class="btn btn-primary" >Create</button></a> -->

                                    </div>

                                </div>

                            </div>



                        </div>
                        <!-- forms/validation -->
                    </div>
                </div>
        </div>
    </div>


</asp:Content>

