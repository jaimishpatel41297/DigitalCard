<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="SocialLink.aspx.cs" Inherits="Admin_SocialLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="jumbotron-1">
        <div class="jumbotron jumbotron-fluid">
            <div class="container-fluid">
                <!-- <button class="btn btn-rounded btn-primary btn-outline">Message</button>
                <button class="btn btn-rounded btn-primary btn-outline">Follow</button> -->
                <h1 class="display-3">Digital Cards</h1>
                <ol class="breadcrumb icon-home icon-angle-right no-bg">
                    <li>
                        <a href="Profile.aspx">
                        Dashboard                   </a>
                    </li>
                    <li class="active">
                        Social Links </li>
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

                            <div class="row">
                                <div class="col-xl-6">


                                    <div class="row">

                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Facebook</label>
                                                <asp:TextBox ID="Txtfb" class="form-control" runat="server"></asp:TextBox>
                                                <%--<input type="text" class="form-control" id="c_name" name="c_name" value="">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>

                                        
                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Instagram</label>
                                                <asp:TextBox ID="Txtinsta" class="form-control" runat="server"></asp:TextBox>
                                                <%--<input type="text" class="form-control" id="vision" name="vision" value="">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>
                                        
                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">LinkedIn</label>
                                                <asp:TextBox ID="Txtlink" class="form-control" runat="server"></asp:TextBox>
                                                <%--<textarea class="form-control" id="about_comp" name="comp_address" required></textarea>--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>
                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Twitter</label>
                                                <asp:TextBox ID="Txttw" class="form-control" runat="server"></asp:TextBox>
                                                <%--<input class="form-control" type="url" id="about_cyoutube" name="about_cyoutube" value="">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-xl-11">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Google+</label>
                                                <asp:TextBox ID="Txtgoogle" class="form-control" runat="server"></asp:TextBox>
                                                <%--<input type="url" class="form-control" id="map_link" name="map_link" value="">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>

                                        <div class="col-xs-12 col-xl-11">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">YouTube</label>
                                                <asp:TextBox ID="Txtyou" class="form-control" runat="server"></asp:TextBox>
                                                <%--<input type="url" class="form-control" id="map_link" name="map_link" value="">--%>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>


                                    </div>

                                </div>


                            </div>

                            <div class="col-xs-12 col-xl-12">

                                <div class="row  btntop textcen">

                                    <div class="col-xl-2  col-xs-12 sub1 ">

                                        <a href="#">
                                            <asp:Button ID="lbSubmit" runat="server" class="btn btn-primary btnsz btn1" Text="Submit" OnClick="lbSubmit_Click" />
                                            <asp:Button ID="lbUpdate" runat="server" class="btn btn-primary btnsz btn1" Text="Update" OnClick="lbUpdate_Click" />
                                            <%--<button class="btn btn-primary btnsz btn1" type="submit" name="add_am">Submit</button></a>--%>
                                    </div>
                                   <%-- <div class="col-xl-2  col-xs-12" style="width:300px;">
                                        <a href="../Default.aspx" target="_blank">
                                            <button class="btn btn-primary btnsz btn1" type="button" name="">Preview Card</button></a>
                                    </div>--%>
                                    <div class="col-xl-2  col-xs-12">
                                        <a href="Services.aspx">
                                            <button class="btn btn-primary btnsz btn1" type="button" name="">Next</button></a>

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

