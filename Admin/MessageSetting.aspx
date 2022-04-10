<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="MessageSetting.aspx.cs" EnableEventValidation="false" Inherits="Admin_MessageSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="jumbotron-1">
        <div class="jumbotron jumbotron-fluid">
            <div class="container-fluid">
                <!-- <button class="btn btn-rounded btn-primary btn-outline">Message</button>
                <button class="btn btn-rounded btn-primary btn-outline">Follow</button> -->
                <h1 class="display-3">DBCard Message Settings</h1>
                <ol class="breadcrumb icon-home icon-angle-right no-bg">
                    <li>
                        <a href="Profile.aspx">Dashboard                    </a>
                    </li>
                    <li class="active">DBCard Message Settings</li>
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

                        <div class="row">
                            <div class="col-xl-6">


                                <div class="row">
                                    <div class="col-xs-12 col-xl-11 " style="color: white;">
                                        <h6 style="color: white;">Message Update</h6>
                                        <br>

                                        <h6 style="color: white;">Please Select language</h6>

                                        <form method="post">
                                            <asp:Button ID="Button1" runat="server" Text="English" />
                                            <asp:Button ID="Button2" runat="server" Text="Hindi" OnClick="Bindhindi" />
                                            <asp:Button ID="Button3" runat="server" Text="Gujarati" OnClick="Bindguj" />


                                          <%--  <input type="radio" name="language" href="about.aspx" onclick="this.form.submit()" value="0" checked>English<br>
                                            <input type="radio" name="language" onclick="this.form.submit()" value="1">Hindi<br>
                                            <input type="radio" name="language" onclick="this.form.submit()" value="2">Gujarati--%>

                                                  <input type="hidden" name="setlanguage" value="1">
                                        </form>

                                        <!-- <h6>English</h6>
                                               <h6>Hindi</h6>
                                               <h6>Gujrati</h6> -->
                                        <form method="post">
                                            <br>
                                            <br>
                                            <h6 style="color: white;">Use Name to change with your contact name.</h6>
                                            <h6 style="color: white;">Use bcardurl to change with your BCard Link.</h6>
                                            <!-- <p>You SMS credit is 1</p> -->
                                            <br>
                                    </div>

                                    <%--<div class="col-xs-12 col-xl-11 ">
                                        <div class="form-group bmd-form-group">

                                            <label class="bmd-label-static">Email Template</label>

                                            <textarea class="form-control dbtext " rows="5" id="about_me" placeholder="" name="email_template"> Hello {name},
You can see my Digital Business Card from given below link:{bcardurl}
Regards                                                           </textarea>
                                            <small class="form-control-feedback"></small>
                                        </div>
                                    </div>--%>
                                    <%--<div class="col-xs-12 col-xl-11 ">
                                        <div class="form-group bmd-form-group">

                                            <label class="bmd-label-static">Email Subject</label>
                                            <input type="text" class="form-control" value="View my Digital Business Card." name="email_subject">

                                            <small class="form-control-feedback"></small>
                                        </div>
                                    </div>--%>



                                    <div class="col-xs-12 col-xl-11 ">
                                        <div class="form-group bmd-form-group">

                                            <label class="bmd-label-static">Whatsapp Template</label>

                                            <asp:TextBox ID="Txtwa" class="form-control" runat="server"></asp:TextBox>
                                            <%--<textarea class="form-control dbtext" name="whatsapp_template" rows="5" id="about_me" value="">Hello  {name},
You can see my Digital Business Card from given below link:{bcardurl}
Regards</textarea>--%>
                                            <small class="form-control-feedback"></small>
                                        </div>
                                    </div>
                                    <div class="col-xs-12 col-xl-11 ">
                                        <div class="form-group bmd-form-group">

                                            <label class="bmd-label-static">SMS Template</label>

                                            <asp:TextBox ID="Txtsms" class="form-control" runat="server"></asp:TextBox>
                                            <%--<textarea class="form-control dbtext" col="50" rows="5" id="about_me" name="sms_template" value="">Hello  {name},
You can see my Digital Business Card from given below link:{bcardurl}
Regards   </textarea>--%>
                                            <small class="form-control-feedback"></small>
                                        </div>
                                    </div>





                                </div>

                            </div>


                        </div>

                        <div class="col-xs-12 col-xl-12">

                            <div class="row">



                                <div class="col-xl-3  col-xs-12 sub1">
                                    <br>
                                    <a href="#">
                                        <asp:Button ID="lbSubmit" runat="server" class="btn btn-primary btnsz btn1" Text="Submit" OnClick="lbSubmit_Click1" />
                                            <asp:Button ID="lbUpdate" runat="server" class="btn btn-primary btnsz btn1" Text="Update" OnClick="lbUpdate_Click1" />
                                        <%--<button class="btn btn-primary btnsz2 " type="submit" name="add_am">Submit</button>--%></a>
                                </div>
                                <div class="col-xl-3  col-xs-12">
                                    <br>
                                   <%-- <a href="index.html">
                                        <button class="btn btn-primary btnsz2" type="button" name="add_am">Share Click Bcard</button></a>--%>
                                </div>

                                <!-- <a href="#" data-toggle="modal" data-target="#myModal"><button class="btn btn-primary" >Create</button></a> -->

                            </div>
                        </div>
                    </div>
                    <!-- forms/validation -->
                </div>
            </div>

        </div>
    </div>


</asp:Content>

