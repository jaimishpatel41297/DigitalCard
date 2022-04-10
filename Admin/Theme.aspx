<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Theme.aspx.cs" Inherits="Admin_Theme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
                    <li class="active">Theme</li>
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
                    <h4><a href="profile.html"><button class="btn btn-primary btn" style="width: 100%;background-color:#d49100 !important;color:#fff !important;    font-size: 19px;">Theme Settings</button></a></h4>
                </div>

                    <div class="col-xs-12 col-xl-12">
                        <div class="widget">

                            <div class="alert alert-success alert-dismissable" id="divSuccess" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                Your Settings Successfully Updated..
                            </div>
                            <div class="alert alert-danger alert-dismissable" id="divError" runat="server" visible="false">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                Failure !
                            </div>

                            <div class="row" style="margin-top: 32px;">
                                <div class="col-xl-6">


                                    <div class="row">

                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Select Color</label>
                                                <asp:DropDownList ID="DropDownList1" runat="server" style="width: 180px;">
                                                    <asp:ListItem>--Click Here--</asp:ListItem>
                                                    <asp:ListItem>green</asp:ListItem>
                                                    <asp:ListItem>red</asp:ListItem>
                                                    <asp:ListItem>blue</asp:ListItem>
                                                    <asp:ListItem>orange</asp:ListItem>
                                                    <asp:ListItem>pink</asp:ListItem>
                                                    <asp:ListItem>purple</asp:ListItem>
                                                </asp:DropDownList>
                                               <%-- <asp:TextBox ID="Txtname" class="form-control" runat="server"></asp:TextBox>--%>
                                                <%--<input type="text" class="form-control" id="f_name" name="f_name" value="" onkeypress="return ((event.charCode >= 65 &amp;&amp; event.charCode <= 90) || (event.charCode >= 97 &amp;&amp; event.charCode <= 122) || (event.charCode == 32))">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Select Version</label>
                                                <asp:DropDownList ID="DropDownList2" runat="server" style="width: 180px;">
                                                    <asp:ListItem>Light</asp:ListItem>
                                                    <asp:ListItem>dark</asp:ListItem>
                                                   
                                                </asp:DropDownList>
                                               <%-- <asp:TextBox ID="Txtname" class="form-control" runat="server"></asp:TextBox>--%>
                                                <%--<input type="text" class="form-control" id="f_name" name="f_name" value="" onkeypress="return ((event.charCode >= 65 &amp;&amp; event.charCode <= 90) || (event.charCode >= 97 &amp;&amp; event.charCode <= 122) || (event.charCode == 32))">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>
                                  


                                       <%-- <div class="col-xs-12 col-xl-11">
                                            <iframe class="dbiframe" id='video1' allowfullscreen="allowfullscreen"></iframe>

                                            </iframe>
                                        </div>
                                        <br>--%>


                                       

                                    </div>

                                </div>


                            </div>

                            <div class="col-xs-12 col-xl-12">

                                <div class="row  btntop textcen">

                                    <div class="col-xl-2 col-xs-12 col-sm-4 sub1 ">

                                        <a href="#">
                                            <asp:Button ID="lbSubmit" runat="server" class="btn btn-primary btnsz btn1" Text="Apply" OnClick="lbSubmit_Click" />
                                            <asp:Button ID="lbUpdate" runat="server" class="btn btn-primary btnsz btn1" Text="Apply" OnClick="lbUpdate_Click" />

                                            <%--<button class="btn btn-primary btnsz1 " type="submit" name="add_am">Submit</button></a>--%>
                                    </div>
                                    <div class="col-xl-3 col-xs-12 col-sm-4">
                                        <a href="../Default.aspx" target="_blank">
                                            <button class="btn btn-primary btnsz1 " type="button" name="">Preview Card</button></a>
                                    </div>
                                    <div class="col-xl-2 col-xs-12 col-sm-4">
                                        <a href="UploadImage.aspx">
                                            <button class="btn btn-primary btnsz1 " type="button" name="">Next</button></a>

                                        <!-- <a href="#" data-toggle="modal" data-target="#myModal"><button class="btn btn-primary" >Create</button></a> -->

                                    </div>

                                </div>

                            </div>

                            <!-- forms/validation -->
                        </div>
                    </div>


                </div>
        </div>
    </div>












</asp:Content>

