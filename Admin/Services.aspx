<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="Admin_Services" %>

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
                        <a href="Profile.aspx">Dashboard                   </a>
                    </li>
                    <li class="active">Services </li>
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
            <div class="row m-b-20">
                <div class="col-xs-12 col-xl-12">
                    <div class="widget">

                        <div class="col-xl-12 col-xs-12 sharedbg shte">
                            <h4><a href="profile.html">
                                <button class="btn btn-primary btn" style="width: 100%; background-color: #d49100 !important; color: #fff !important; font-size: 19px;">Your Services</button></a></h4>
                        </div>
                        <div class="row" style="margin-top: 32px;">
                            <div class="col-xl-6">


                                <div class="row">

                                    <div class="col-xs-12 col-xl-11 ">
                                        <div class="form-group bmd-form-group">
                                            <label class="bmd-label-static">Title</label>
                                            <asp:TextBox ID="Txttitle" class="form-control" runat="server"></asp:TextBox>
                                            <%--<input type="text" class="form-control" id="f_name" name="f_name" value="" onkeypress="return ((event.charCode >= 65 &amp;&amp; event.charCode <= 90) || (event.charCode >= 97 &amp;&amp; event.charCode <= 122) || (event.charCode == 32))">--%>
                                            <small class="form-control-feedback"></small>
                                        </div>
                                    </div>
                                    <br>


                                    <div class="col-xs-12 col-xl-11 ">
                                        <div class="form-group bmd-form-group">
                                            <label class="bmd-label-static">Short Description</label>
                                            <asp:TextBox ID="Txtdes" class="form-control" runat="server"></asp:TextBox>
                                            <%--<input type="text" class="form-control" id="profession" name="profession" value="">--%>
                                            <small class="form-control-feedback"></small>
                                        </div>
                                    </div>
                                    <br>
                                </div>

                            </div>


                        </div>

                        <div class="col-xs-12 col-xl-12">
                            <div class="col-xl-2 col-xs-12 col-sm-4 sub1 ">

                                <a href="#">
                                    <asp:Button ID="lbSubmit" runat="server" class="btn btn-primary btnsz btn1" Text="Submit" OnClick="lbSubmit_Click1" />
                                    <asp:Button ID="lbUpdate" runat="server" class="btn btn-primary btnsz btn1" Text="Update" OnClick="lbUpdate_Click1" />
                            </div>

                            <div class="row textcen achv">
                               <%-- <div class="col-xl-2 col-sm-3 col-xs-6">

                                    <a href="../Default.aspx" target="_blank">
                                        <button class="btn btn-primary btnsz1 btn1" type="button" name="">Preview Card</button></a>
                                </div>--%>
                                <div class="col-xl-2 col-sm-3 col-xs-6">
                                    <a href="profile.aspx">
                                        <button class="btn btn-primary btnsz1 btn1" type="button" name="">Back</button></a>
                                </div>

                            </div>
                        </div>

                        <%-- <asp:Repeater ID="RepterDetails" runat="server">
<HeaderTemplate>
<table class="table table-striped table-hover" style="border: 1px solid #0000FF; width: 500px" cellpadding="0">
<tr style="background-color: #FF6600; color: #000000; font-size: large; font-weight: bold;">
<td colspan="2">
<b>Comments</b>
</td>
</tr>
                                </HeaderTemplate>
<ItemTemplate>
<tr style="background-color: #EBEFF0">
<td>
<table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; width: 500px">
<tr>
<td>Subject:
<asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>' Font-Bold="true" />
</td>
</tr>
</table>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblComment" runat="server" Text='<%#Eval("CommentOn") %>' />
</td>
</tr>
<tr>
<td>
<table style="background-color: #EBEFF0; border-top: 1px dotted #df5015; border-bottom: 1px solid #df5015; width: 500px">
<tr>
<td>Post By:
                                                        <asp:Label ID="lblUser" runat="server" Font-Bold="true" Text='<%#Eval("UserName") %>' /></td>
<td>Created Date:<asp:Label ID="lblDate" runat="server" Font-Bold="true" Text='<%#Eval("Post_Date") %>' /></td>
</tr>
</table>
</td>
</tr>
<tr>
<td colspan="2">&nbsp;</td>
</tr>

                                </ItemTemplate>

                                <FooterTemplate>
                                    </table>

                                </FooterTemplate>

                            </asp:Repeater>--%>

                        <%--</div>--%>
                        <%--<table class="table table-striped table-hover">
                                    <thead>
                                        <tr>
                                            <th style="color: white;">Sr.No.</th>
                                            <th style="color: white;">Name</th>
                                            <th style="color: white;">Description</th>
                                            <th style="color: white;">Edit</th>

                                            <th style="color: white;">Delete</th>
                                        </tr>
                                    </thead>
                                    <tbody class="row_position">

                                        <tr id="63">
                                            <td style="color: white;">1 </td>
                                            <td style="color: white;">Peter Winter</td>
                                            <td style="color: white;">555-555-0199@example.com</td>
                                            <td><a href="#" class="btn" data-toggle="modal" data-target="#myModal1" onclick="open_model('Peter Winter','63','555-555-0199@example.com');"><i class="fa fa-pencil m-r-5"></i></a></td>
                                            <td><a href="#" class="btn" onclick="delete_tag(63)"><i class="fa fa-trash m-r-5"></i></a></td>
                                        </tr>
                                    </tbody>
                                </table>--%>
                        <%--</div>--%>




                        <%--                            <div class="row textcen achv">
                                <div class="col-xl-2 col-sm-3 col-xs-6">

                                    <a href="../Default.aspx" target="_blank">
                                        <button class="btn btn-primary btnsz1 btn1" type="button" name="">Preview Card</button></a>
                                </div>
                                <div class="col-xl-2 col-sm-3 col-xs-6">
                                    <a href="profile.aspx">
                                        <button class="btn btn-primary btnsz1 btn1" type="button" name="">Back</button></a>
                                </div>

                            </div>--%>
                    </div>
                </div>
                <!-- forms/validation -->
            </div>
        </div>

    </div>




    <%--<div class="modal fade" id="myModal1" role="dialog">
        <div class="modal-dialog modal-sm">

            <!-- Modal content-->
            <div class="modal-content" style="background: #dcdbdb;">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h6 class="modal-title">Edit Product</h6>
                </div>
                <div class="modal-body">
                    <div class="form-group bmd-form-group">
                        <label class="bmd-label-static">
                            <p style="color: black;">Title</p>
                        </label>
                        <input type="text" class="form-control" id="e_name" name="e_name" required>
                        <small class="form-control-feedback"></small>
                    </div>
                    <div class="form-group bmd-form-group">
                        <label class="bmd-label-static">
                            <p style="color: black;">Short Description</p>
                        </label>
                        <input type="text" class="form-control" id="e_value" name="e_value" required>
                        <input type="hidden" name="tag_id" id="tag_id">
                        <small class="form-control-feedback"></small>
                    </div>

                    <div class="">

                           <asp:Button ID="Button1" runat="server" class="btn btn-primary btnsz btn1" Text="Submit" OnClick="Button1_Click" />
                                <asp:Button ID="Button2" runat="server" class="btn btn-primary btnsz btn1" Text="Update" OnClick="Button2_Click" />
                    </div>
                </div>

            </div>

        </div>
    </div>--%>
</asp:Content>

