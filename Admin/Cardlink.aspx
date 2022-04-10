<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Cardlink.aspx.cs" Inherits="Admin_Cardlink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="jumbotron-1">
        <div class="jumbotron jumbotron-fluid">
            <div class="container-fluid">
                <!-- <button class="btn btn-rounded btn-primary btn-outline">Message</button>
                <button class="btn btn-rounded btn-primary btn-outline">Follow</button> -->
                <h1 class="display-3"> My Referral</h1>
                <ol class="breadcrumb icon-home icon-angle-right no-bg">
                    <li>
                        <a href="index.html">
                        Dashboard                   </a>
                    </li>
                    <li class="active">
                        My Referral</li>
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
                                    <div class="col-xs-12 col-xl-12">
                                        <div class="row">
                                             <div class=" col-xs-2 col-xl-2 ">
                                             </div>

                                      <div class=" col-xs-6 col-xl-7 ">
                                                    <div class="form-group bmd-form-group">
                                                     <!--    <label class="bmd-label-static">My Referral Link</label> -->
                                                        <input type="text" class="form-control" id="code" name="email" value="http://digitalbcards.in/register.php?zxc=" placeholder="My Referral Link">
                                                        <small class="form-control-feedback"></small>
                                                    </div>
                                                </div>
                                     <div class="col-xl-2  col-xs-2 myrefel">
                                        

                                <a href="#"><button class="btn btn-primary " onclick="copyToClipboard('#code')"  type="button" name="">Copy</button></a></div>

                                   </div>
                                </div>
                                        
                               </div>

                                    
                                

                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>








</asp:Content>

