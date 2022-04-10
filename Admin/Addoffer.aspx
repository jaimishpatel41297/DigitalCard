<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Addoffer.aspx.cs" Inherits="Admin_Addoffer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="jumbotron-1">
        <div class="jumbotron jumbotron-fluid">
            <div class="container-fluid">
                <h1 class="display-3">Offer Add Settings</h1>
                <ol class="breadcrumb icon-home icon-angle-right no-bg">
                    <li>
                        <a href="Profile.aspx">Dashboard   </a>
                    </li>
                    <li class="active">Offer Add Settings</li>
                </ol>
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

                            <div class="row" style="margin-top: 32px;">
                                <div class="col-xl-6">


                                    <div class="row">

                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Offer Title</label>
                                                <asp:TextBox ID="Txtname" class="form-control" runat="server"></asp:TextBox>

                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>
                                        <br>

                                        <div class="col-xs-12 col-xl-11 ">
                                            <div class="form-group bmd-form-group">
                                                <label class="bmd-label-static">Offer Desscription</label>
                                                <asp:TextBox ID="Txtcompany" class="form-control" runat="server"></asp:TextBox>
                                                <small class="form-control-feedback"></small>
                                            </div>
                                        </div>
                                        <br>
                                    </div>

                                </div>


                            </div>

                            
                            <div class="col-xs-12 col-xl-12">

                                <div class="row  btntop textcen">

                                    <div class="col-xl-2 col-xs-12 col-sm-4 sub1 ">

                                        <a href="#">
                                            <asp:Button ID="lbSubmit" runat="server" class="btn btn-primary btnsz btn1" Text="Submit" OnClick="lbSubmit_Click1" />
                                            <asp:Button ID="lbUpdate" runat="server" class="btn btn-primary btnsz btn1" Text="Update" OnClick="lbUpdate_Click1" />
                                           <%-- <asp:Button ID="Button1" runat="server" class="btn btn-primary btnsz btn1" Text="card" OnClick="lbVcf_Click" />
                                            <asp:Button ID="Button2" runat="server" class="btn btn-primary btnsz btn1" Text="card" OnClick="lbVcf2_Click" />--%>
                                            <%--<button class="btn btn-primary btnsz1 " type="submit" name="add_am">Submit</button></a>--%>
                                    </div>
                                   <%-- <div class="col-xl-3 col-xs-12 col-sm-4">
                                        <a href="../Default.aspx" target="_blank">
                                            <button class="btn btn-primary btnsz1 " type="button" name="">Preview Card</button></a>
                                    </div>--%>
                                </div>

                            </div>
                        </div>


                    </div>
                </div>
        </div>
</asp:Content>

