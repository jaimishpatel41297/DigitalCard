<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Admin_Register" %>



<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>



<!doctype html>


<html xmlns="http://www.w3.org/1999/html">
<head>
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
       <link href="https://fonts.googleapis.com/css?family=Muli:300,300i,400,400i,600,600i,700,700i|Comfortaa:300,400,500,700" rel="stylesheet">
         <link rel="stylesheet" type="text/css" href="css/style.css" />
         <link rel="icon" type="image/x-icon" href="images/favicon1.ico">

    
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
<style type="text/css">
  .reg1{
      white-space: nowrap !important;
    color: red !important;
    display: inherit;
    vertical-align: middle;
    display: table-cell;
        padding-left: 2%;
}
.dblogo
{
  width: 100px;
}
</style>
</head>

<body style="background-image:url(#);    background-size: cover;
    background-repeat: no-repeat;background-position: center;" >
 
<form runat="server">

<div class="container-fluid pad1">
    <div class="row ">
         <div class="col-md-12">
          <div class="col-md-2 col-sm-12 col-xs-12">
            <a href="login.php">
            <!-- <a href="../newcardo/index.php"> -->
         <!-- <img src="assets/img/logo1.png" class="icns icns1"> -->
         <%-- <img src="assets/img/dbc.svg" class="icns dblogo">--%>
              <img src="../vcard/itfuturz.jpg" class="icns dblogo" style="margin-left: 703px;">
       </a>
       </div>
      </div>
        <div class="col-md-4 col-sm-offset-3 col-sm-6 col-xs-12 col-md-offset-4  tplogin1"   id="regi_div">
             <!-- <center><img src="assets/img/user.png" class="icns" style="width: 86px;    top: -54px;"></center> -->

            <div class="panel panel-default panel-color">
                <div class="panel panel-heading panel-color">
                    

                    <h3 class="text-center t1" >Register</h3>
                </div>
                <div class="panel panel-body">
            
                 <div class="form-group row col-sm-offset-2">
               
                      <!-- <label>First Name</label> -->
                    <div class="col-md-10 col-sm-10 input-group" style="margin-top: 20px;">
                      
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <%--<input class="form-control" type="text" name="name" id="name" placeholder="Full Name" onkeypress="return ((event.charCode >= 65 &amp;&amp; event.charCode <= 90) || (event.charCode >= 97 &amp;&amp; event.charCode <= 122) || (event.charCode == 32))" required>--%>
                        <asp:TextBox ID="Txtname" class="form-control" placeholder="Full Name" runat="server"></asp:TextBox>



                    <span class="reg1">*</span>
                        
                        
                       
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Txtname" ErrorMessage="[ Enter Name ]" ForeColor="#FF3300" ValidationGroup="submit"></asp:RequiredFieldValidator>
                
            </div>
            <!-- <div class="form-group row col-sm-offset-2">
               
                      <label>Last Name</label>
                    <div class="col-md-10 col-sm-10  input-group">
                      
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <input class="form-control" type="text" name="l_name" id="l_name" placeholder="Last Name" onkeypress="return ((event.charCode >= 65 &amp;&amp; event.charCode <= 90) || (event.charCode >= 97 &amp;&amp; event.charCode <= 122) || (event.charCode == 32))">
                </div>
               
                
            </div> -->
            <div class="form-group row col-sm-offset-2">
               
                      <!-- <label>Email Address</label> -->
                    <div class="col-md-10 col-sm-10 input-group">
                      
                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                    <%--<input class="form-control" type="email" name="email" id="email" onchange="check_email_exist();" placeholder="Email Address" required>--%>
                  <asp:TextBox ID="txtemail" class="form-control" placeholder="Email Address" runat="server"></asp:TextBox>
                        <span class="reg1">*</span>
                </div>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail" ErrorMessage="[ Enter Email ]" ForeColor="#FF3300" ValidationGroup="submit"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ControlToValidate="txtemail" ErrorMessage="Please enter corect email" ValidationGroup="submit"
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                
            </div>

                <div class="form-group row col-sm-offset-2">
               
                      <!-- <label>Email Address</label> -->
                    <div class="col-md-10 col-sm-10 input-group">
                      
                    <span class="input-group-addon"><i class="glyphicon glyphicon-phone"></i></span>
                    <%--<input class="form-control" type="tel" min='0' name="mobile"  minlength="10" maxlength="10"  required  placeholder="Mobile No" required>--%>
                  <asp:TextBox ID="txtmobile" class="form-control" placeholder="Mobile No" runat="server"></asp:TextBox>
                        <span class="reg1">*</span> 
                </div>
               
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtmobile" ErrorMessage="[ Enter Mobile No. ]" ForeColor="#FF3300" ValidationGroup="submit"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ValidationGroup="submit"
                    ControlToValidate="txtmobile" ErrorMessage="Enter 10 Digit Mobile No."  
                    ValidationExpression="[0-9]{10}" ForeColor="Red"></asp:RegularExpressionValidator>  
            </div>


            <div class="form-group row col-sm-offset-2">
               
                    <!-- <label>Password</label> -->
                <div class="col-md-10 col-sm-10 input-group">
                    
                   <span class="input-group-addon"><i class="fa fa-key"></i> </span>

                    <%--<input class="form-control" type="password"  name="password" id="password" onchange="check_repass();" placeholder="Password" required>--%>
                    <asp:TextBox ID="txtpass" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                        <span class="reg1">*</span>
                </div>
           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtpass" ErrorMessage="[ Enter Password ]" ForeColor="#FF3300" ValidationGroup="submit"></asp:RequiredFieldValidator>
                
            </div>
             <div class="form-group row col-sm-offset-2">
               
                    <!-- <label>Confirm Password</label> -->
                <div class="col-md-10 col-sm-10 input-group">
                    
                    <span class="input-group-addon"><i class="fa fa-key"></i> </span>
                    <asp:TextBox ID="Txtrepass" class="form-control" placeholder="Confirm Password" runat="server"></asp:TextBox>
                    <%--<input class="form-control" type="password"  name="re_pass" id="re_pass" onchange="check_repass();"  placeholder="Confirm Password" required>--%>
                    <span class="reg1">*</span>
                </div>
            
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Txtrepass" ErrorMessage="[ Enter Password ]" ForeColor="#FF3300" ValidationGroup="submit"></asp:RequiredFieldValidator>
                 <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Enter Correct Password" ControlToValidate="txtpass" ControlToCompare="txtrepass" ForeColor="#FF3300" ValidationGroup="submit"></asp:CompareValidator>
            </div>

            <%--<div class=" row col-sm-offset-2">
               
                     <!-- <label>Referral ID</label> -->
                    <div class="col-md-10 col-sm-10 input-group">
                      
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <input class="form-control" type="text" name="Refferal" id="Refferal"   placeholder="Referral" >
                    <span class="reg1" style="visibility: hidden;">*</span>
                </div>
               
                
            </div>--%>

            <%--<div class="row col-sm-offset-2">

              <div class="checkbox" >
                <label><input type="checkbox" name="remember" required=""><span  data-toggle="modal" data-target="#myModal"> Terms and Conditions</span></label>
              </div>
            </div>--%>
               <center>
                <%--<input type="submit" value="SUBMIT" class="btn btn-default  btn-color1 " name="register">--%>
                    <asp:Button ID="Button1" class="btn btn-default  btn-color1" ValidationGroup="submit" runat="server" Text="Register" OnClick="lblSubmit_Click"></asp:Button>
            </center>
               <center><!-- 
               <p class="mgt">Are you existing?<a href="login.php"> <span class="color ">Login</span></a></p> -->
               <p class="mgt">Are you already Registered?<a href="login.aspx"> <span class="color ">Login</span></a></p>

                <p class="mgt">View a Demo<a href="../Default.aspx"> <span class="color" style="color: red;">Click Here</span></a></p>
               </center>

            

        </div>
    </div>

</div>
</div>
</div>
<br>


</form>



<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title text-center" style="color: #07314A;">Welcome to B-Click Digital Community!</h4>
        </div>
        <div class="modal-body">
          <h4><b><u>Terms & Conditions</u></b></h4>
          <ol>
            <li>The yearly subscription fees for using Digital Cards is Rs. 1500/- (including 18% GST). </li>
            <li>GST would be applicable as per Government Norms. </li>
            <li>The card would be operation after 100% payment. </li>
            <li>All payments must be made in favour of <b>“B-Click Digital”,</b> payable at Surat.</li>
            <li>The payment once made is non-refundable & non-transferable.</li>
            <li>The company holds the right to change any Terms & Conditions.</li>
            <li>The user can’t share the ID & Password with anyone else.</li>
            <li>The Card can’t be further sold to anyone else.</li>
            <li>Invoice will be shared online on your card.</li>
            <li>Any discrepancies, are subject to Surat Jurisdiction only.</li>
            <li>Kindly provide the following alongwith your subscription fees<br>
                a.  Name at which you want invoice<br>
b.  Your GST Number (if any)<br>
c.  Your PAN Card<br>
d.  Your Bank Account Details (in which you want your Cash Rewards)

               </li>
              

            

          </ol>
        </div>
        <div class="modal-footer">

          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
  












  <script src="js/jquery.min.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/material.min.js"></script>
    <!-- Jquery easing -->
    <script type="text/javascript" src="js/jquery.easing.1.3.min.js"></script>
    <!-- Plugin For Google Maps -->
    <!-- Typing text -->
    <script src="js/typed.min.js" type="text/javascript"></script>
    <!-- sticky -->
    <script src="js/jquery.sticky.js" type="text/javascript"></script>
    <!-- owl  carousel -->
    <script src="js/owl.carousel.min.js" type="text/javascript"></script>
    <!-- contact form -->
    <script type="text/javascript" src="js/jqBootstrapValidation.js"></script>
    <!-- WOw js -->
    <script type="text/javascript" src="js/wow.min.js"></script>
    <!-- <script src="js/modernizr.js" type="text/javascript"></script> -->
    <script src="js/main.js" type="text/javascript"></script>
    <script type="text/javascript">
        // $('#phone').on('keypress', function (event) {
        //     var regex = new RegExp("^[a-zA-Z0-9]+$");
        //     var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        //     if (!regex.test(key)) {
        //        event.preventDefault();
        //        return false;
        //     }
        // });
        $(document).ready(function () {
            $("#Refferal").on('keypress', function (event) {
                var regex = new RegExp("^[a-zA-Z0-9]+$");
                var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
                if (!regex.test(key)) {
                    event.preventDefault();
                    return false;
                }
            });
        });

        $("#phone").keydown(function (event) {
            k = event.which;
            if ((k >= 96 && k <= 105) || k == 8) {
                if ($(this).val().length == 10) {
                    if (k == 8) {
                        return true;
                    } else {
                        event.preventDefault();
                        return false;

                    }
                }
            } else {
                event.preventDefault();
                return false;
            }

        });



        function check_email_exist() {

            var email = $('#email').val();
            var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;

            if (email != '') {
                if (testEmail.test(email)) {
                    // alert("hii");
                }
                else {
                    alert("Please Enter Valid Email-Id");
                    $('#email').val('');
                }
            }

            if (email != '') {
                jQuery.ajax({
                    type: 'POST',
                    data: { 'action': 'check_email', 'email': email },
                    url: 'ajax.php',
                    success: function (data) {
                        if (data) {
                            alert('Email-Id Already Exist.');
                            $('#email').val('');
                        }

                    },
                    error: function (e) {

                    }
                });
            }

        }

        function check_repass() {

            var pass = $('#password').val();
            var re_pass = $('#re_pass').val();
            if (pass != '' && re_pass != '') {
                if (pass != re_pass) {
                    alert('Password not matched.');
                    $('#re_pass').val('');
                }
            }

        }



    </script>
</body>
</html>
