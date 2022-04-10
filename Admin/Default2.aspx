<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="jumbotron-1">
        <div class="jumbotron jumbotron-fluid">
            <div class="container-fluid  ">
                <!-- <button class="btn btn-rounded btn-primary btn-outline">Message</button>
                <button class="btn btn-rounded btn-primary btn-outline">Follow</button> -->

                <div class="untext">
                    <!-- <h1 class="display-3 ">Welcome</h1> -->
                </div>

                <div class="row untext">
                    <ol class="breadcrumb icon-home icon-angle-right no-bg">
                        <li>
                            <a href="#">Dashboard             </a>
                        </li>
                        <!-- <li class="active">
                        Geographic </li> -->
                    </ol>

                    <!-- <div class=" bgcolor" style="">
                    <div class="cd-imgbox">
                    <div class="qrimg ">
                    <center><img src="https://chart.googleapis.com/chart?cht=qr&chl=Hello+World&chs=160x160&chld=L|0"
                    class="qr-code img-thumbnail img-responsive"></center>
                    </div>
                    </div>
                    </div> -->
                </div>
                <br>
            </div>


            <div class="row addindex" style="">
                <div class="col-xl-12 col-xs-12 sharedbg shte">
                    <a href="profile.php">
                        <button class="btn btn-primary btn dbtt1" style="width: 100%; background-color: #d49100 !important; color: #fff;">
                            Your DBCard <i class="fa fa-edit shared"></i>
                        </button>
                    </a>
                </div>
                <!-- <div class="col-xl-1 col-xs-2">
                        <i class="fa fa-edit shared" > </i>
                    </div> -->
            </div>
        </div>
    </div>


    <div class="col-xs-12 main">
        <div class="page-on-top">
            <!-- forms/validation -->
            <!--     <h5 style="color:#fff">(Step:1)</h5><br>   -->

            <!--    <h5 style="color:#fff">(Step:2)</h5><br> -->
            <div class="row">
                <div class="col-xl-11 col-xs-10">
                    <h5 style="color: #fff;">Share DBcard / Save Contact</h5>
                </div>
                <div class="col-xl-1 col-xs-2">
                    <a href="#" data-toggle="modal" data-target="#myModal1" style="color: #fff; font-size: 22px;"><span><i class="fa fa-share-alt"></i></span></a>
                </div>
            </div>
            <form method="post">
                <div class="row">
                    <div class="col-xs-12 col-xl-12">
                        <!--  <div class="col-xs-12 col-xl-12 ">
                                                        -->
                        <div class="form-group bmd-form-group ">
                            <input type="text" class="form-control" required id="name" name="name" placeholder="Type Receiver’s Name">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>

                    <div class="col-xs-12 col-xl-12 ">

                        <div class="form-group bmd-form-group ">
                            <select class="form-control select2 selid" placeholder="Decide Segment" style="width: 100%" id="segment" name="segment[]" multiple>

                                <option value="qa">qa</option>

                                <option value="fresher">fresher</option>

                                <option value="engineer">engineer</option>

                                <option value="student">student</option>

                                <option value="lecturer">lecturer</option>

                                <option value="kk">kk</option>

                                <option value="kkk">kkk</option>

                                <option value="geh">geh</option>

                                <option value="saf">saf</option>

                                <option value="marketing">marketing</option>

                                <option value="gfl">gfl</option>

                                <option value="career tainer">career tainer</option>

                                <option value="ESPI">ESPI</option>

                                <small class="form-control-feedback"></small>

                            </select>

                            <!--     <input type="text" class="form-control" id="segment" name="segment" autocomplete="off" placeholder="Enter Segment"> -->
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>

                    <!--  <div class="col-xs-12 col-xl-12 ">
                                                       
                                                            <div class="form-group bmd-form-group ">
                                                                <input type="text" class="form-control" id="remarks" name="remarks" autocomplete="off" placeholder="Enter Remark">
                                                                <small class="form-control-feedback"></small>
                                                            </div>
                                                   
                                                    </div> -->
                    <div class="col-xs-12 col-xl-12 ">

                        <div class="form-group bmd-form-group">
                            <input type="text" pattern="\d*" class="form-control" id="mobile" name="phone" maxlength="10" placeholder="Type Receiver’s Mobile" inputmode="numeric">
                            <small class="form-control-feedback"></small>
                            <input type="hidden" name="mobile" id="phone">
                        </div>


                    </div>


                    <!-- 
                                                     <div class="col-xs-12 col-xl-12 ">
                                                      
                                                            <div class="form-group bmd-form-group">
                                                                 <input id="phone" class="form-control" name="phone" type="tel"  placeholder="Type Receiver’s Mobile">
                                                                
                                                            </div>
                                                  
                                                    </div> -->


                    <!-- <div class="col-xs-12 col-xl-12 ">
                                                       
                                                            <div class="form-group bmd-form-group ">
                                                                <input type="text" class="form-control" id="mobile" name="whatsapp" maxlength="10" placeholder="Enter Recipient's Whats App Number">
                                                                <small class="form-control-feedback"></small>
                                                            </div>
                                                    
                                                    </div> -->


                    <div class="col-xs-12 col-xl-12 ">

                        <div class="form-group bmd-form-group ">
                            <input type="email" class="form-control" id="email" name="email" placeholder="Type Receiver’s Email">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>

                    <!--    </div>  -->
                </div>




                <div id="test" style="display: none">

                    <div class=" ">

                        <div class="form-group bmd-form-group ">
                            <input type="text" class="form-control" id="company_name" name="company_name" placeholder="Company  Name">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>

                    <div class=" ">

                        <div class="form-group bmd-form-group ">
                            <input type="text" class="form-control" id="position" name="position" autocomplete="off" placeholder="Position">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>



                    <div class=" ">

                        <div class="form-group bmd-form-group ">
                            <input type="text" class="form-control" id="address" name="address" placeholder="Address Line 1">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>
                    <div class="">

                        <div class="form-group bmd-form-group ">
                            <input type="text" class="form-control" id="address2" name="address2" placeholder="Address Line 2">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>



                    <div class="">

                        <div class="form-group bmd-form-group ">
                            <input type="text" class="form-control" id="city" name="city" placeholder="City">
                            <small class="form-control-feedback"></small>

                        </div>
                    </div>

                    <div class="">

                        <div class="form-group bmd-form-group ">
                            <input type="text" class="form-control" id="zip_code" name="zip_code" placeholder="Zip Code">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>



                    <div class="">

                        <div class="form-group bmd-form-group ">
                            <input type="text" class="form-control" id="state" name="state" placeholder="State">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>
                    <div class="">

                        <div class="form-group bmd-form-group">
                            <input type="text" class="form-control" id="country" name="country" placeholder="Country Name">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>



                    <div class="">

                        <div class="form-group bmd-form-group">
                            <input type="text" class="form-control" id="website" name="website" placeholder="Website">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>
                    <div class="">

                        <div class="form-group bmd-form-group">
                            <label>Birthday</label>
                            <input type="date" class="form-control" id="birthday" name="birthday">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>



                    <div class="">

                        <div class="form-group bmd-form-group ">
                            <label>Anniversary</label>
                            <input type="date" class="form-control" id="anniversory" name="anniversory">
                            <small class="form-control-feedback"></small>
                        </div>

                    </div>
                </div>

                <div class="form-group bmd-form-group   textcen">
                    <div class="row">
                        <div class="form-group  col-xs-6 col-xl-4">

                            <button type="button" id="button" class="btn btn-primary btnsz1">More</button>
                        </div>
                        <div class="form-group  col-xs-6 col-xl-4">
                            <button type="reset" onclick="location.href='index.php'" id="button" class="btn btn-primary btnsz1">Reset</button>
                        </div>
                        <div class="form-group  col-xs-6 col-xl-4">
                            <button type="submit" name="save_only" value="1" class="btn btn-primary btnsz1">SAVE NOW</button>
                        </div>




                        <div class="form-group  col-xs-6 col-xl-4">
                            <button type="submit" name="send_whatsapp" class="btn btn-primary btnsz1">WhatsApp</button>
                        </div>
                        <div class="form-group  col-xs-6 col-xl-4">
                            <button type="submit" name="send_email" class="btn btn-primary btnsz1">Send Email</button>
                        </div>
                        <div class="form-group col-xs-6 col-xl-4">
                            <button type="submit" name="send_sms" class="btn btn-primary btnsz1">Send SMS</button>
                        </div>
                    </div>
                </div>
                <!-- <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal1">Open Modal</button> -->
                <!-- <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button> -->



                <!-- </div> -->


            </form>
            <!-- forms/validation -->
        </div>
    </div>


    <!-- Modal -->


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
                        
                        <a href="https://api.whatsapp.com/send?text=Hey%2C%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link%20%0Ahttp%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D%20%0A%0A%0ASay%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20.%0A%0A%0A"> <i class="fa fa-whatsapp facardwt"></i></a>

                                       
                        <!-- <a href="https://www.facebook.com/sharer/sharer.php?u=Hey,  I am using this Digital Business Card. I loved using it. Have a look at it from the below link 
http%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D 


Say goodbye to Cards.  Use Digital Business Cards - You are one click away. . .


                        "><i class="fa fa-facebook facardfb"></i></a> -->

                        <a href="https://www.facebook.com/sharer/sharer.php?u=http://digitalbcards.in/Bcard.php?zxc=&quote=Hey,  I am using this Digital Business Card. I loved using it. Have a look at it from the below link.Say goodbye to Cards.  Use Digital Business Cards - You are one click away. . . "><i class="fa fa-facebook facardfb"></i></a>


                        <a href="https://twitter.com/intent/tweet?text=Hey%2C%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link%20%0Ahttp%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D%20%0A%0A%0ASay%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20.%0A%0A%0A&source=&related=shareaholic"> <i class="fa fa-twitter facardtt"></i></a>

                        <a href="https://plus.google.com/share?url=http://digitalbcards.in/Bcard.php?zxc=">  <i class="fa fa-google-plus facardgp"></i></a>


                       <!--  <a href="https://www.linkedin.com/sharing/share-offsite/?url=Hey%2C%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link%20%0Ahttp%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D%20%0A%0A%0ASay%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20.%0A%0A%0A"> <i class="fa fa-linkedin facardld"></i></a> -->

                         <a href="https://www.linkedin.com/shareArticle?mini=true&url=http://digitalbcards.in/Bcard.php?zxc=&title=Hey%2C%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link%20%0Ahttp%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D%20%0A%0A%0ASay%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20.%0A%0A%0A&source=LinkedIn"> <i class="fa fa-linkedin facardld"></i></a>

                      <!--   https://www.linkedin.com/shareArticle?mini=true&url=http://developer.linkedin.com&title=LinkedIn%20Developer%20Network&summary=My%20favorite%20developer%20program&source=LinkedIn -->
                        <!-- <a href="http://pinterest.com/pin/create/button/?url=http%3A%2F%2Fandroappstech.in%2FDigitalbcard.in%2Fbcard_web%2FBcard.php%3Fzxc%3D&media=..%2Fupload%2F"> <img src="images/icon/pin.png" class="center-block"></a>  -->
                        <!-- <a href="https://in.pinterest.com/pin/../upload/"> <img src="images/icon/pin.png" class="center-block"></a>  -->
                        
                        <a href="mailto:?subject=Digital Bcard&body=Hey%2C%20%20I%20am%20using%20this%20Digital%20Business%20Card.%20I%20loved%20using%20it.%20Have%20a%20look%20at%20it%20from%20the%20below%20link%20%0Ahttp%3A%2F%2Fdigitalbcards.in%2FBcard.php%3Fzxc%3D%20%0A%0A%0ASay%20goodbye%20to%20Cards.%20%20Use%20Digital%20Business%20Cards%20-%20You%20are%20one%20click%20away.%20.%20.%0A%0A%0A"> <i class="fa fa-envelope facardml"></i></a>
                    </div></center>
                </div>

            </div>

        </div>
    </div>


    <!-- <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script> -->
    <script src="https://code.jquery.com/jquery-latest.min.js"></script>


    <!-- build:js js/vendor.js -->
    <!-- <script src="bower_components/jquery/dist/jquery.min.js"></script> -->

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
    <!-- <script src="scripts/app.js"></script> -->
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
    <!-- <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.5/js/select2.full.min.js"></script> -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.5/js/select2.min.js"></script>
    <script src="js/intlTelInput.js"></script>
    <script>
        var input = document.querySelector("#mobile");
        var a = window.intlTelInput(input, {
            initialCountry: "auto",
            geoIpLookup: function (success, failure) {


                $.get("https://ipinfo.io", function () { }, "jsonp").always(function (resp) {
                    var countryCode = (resp && resp.country) ? resp.country : "";
                    success(countryCode);
                });
            },

            hiddenInput: "full_phone",
            utilsScript: "js/utils.js?1537717752654" // just for formatting/placeholders etc
        });

        $("#mobile").on("keyup change", function () {
            var input = document.querySelector("#mobile");
            var intlNum = a.getNumber();

            var intlNumber = a.getSelectedCountryData();

            if ($("#mobile").val().length == 10) {

                var xyz = intlNum;
                // alert(xyz);
                $("#phone").val(xyz);
                // var op = string.split(/(?=.{10}$)/).join(' ');
                // alert(op);
                // $("#mobile").val(xyz);
                // console.log(intlNumber.dialCode);
            }


            // if (intlNumber) {

            //     if ( $("#mobile").val().length==10) {

            //         var xyz=intlNum;
            //         alert(xyz);
            //         $("#mobile").val(intlNumber.dialCode);
            //         console.log(intlNumber.dialCode);
            //     }
            // } else {
            // }
        });




    </script>
    <script type="text/javascript">

        $(".select2").select2({
            'tags': true,
            placeholder: "Decide Segment"

        });
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            $(".cd-imgbox").hide();

        });
    </script>







</asp:Content>

