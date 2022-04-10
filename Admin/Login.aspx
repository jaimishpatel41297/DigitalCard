<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Login" %>


<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>





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
     <link rel="manifest" href="/manifest.json">
     <script src="js/service-worker.js "></script>



<style type="text/css">

.dblogo
{
	width: 100px;
}



@media only screen and (max-width:767px)  {
 
}
</style>

</head>

<body style="background-image:url(#);    background-size: cover;    background-position: center;
    background-repeat: no-repeat;" >

<div class="container-fluid pad1 " >
    <div class="row ">
        <div class="col-md-12">
          <div class="col-md-2 col-sm-12 col-xs-12">
       <a href="login.php">
       <!-- <a href="../newcardo/index.php"> -->
        <%-- <img src="assets/img/dbc.svg" class="icns dblogo">--%>

             <img src="../vcard/itfuturz.jpg" class="icns dblogo" style="margin-left: 703px;">
         <!-- 
         <img src="assets/img/logo1.png" class="icns icns1"> -->
       </a> 
       </div>
      </div>
        <div class="col-md-4 col-sm-offset-3 col-sm-6 col-xs-12 col-md-offset-4  tplogin1">


             <!--<center><img src="assets/img/user.png" class="icns" style="width: 86px;    top: -54px;"></center> -->

            <div class="panel panel-default panel-color">
                <div class="panel panel-heading panel-color">
                    

                    <h3 class="text-center t1" >Login</h3>
                </div>
                <div class="panel panel-body">
            <form runat="server">
            <div class="form-group row col-sm-offset-3 ">
                    
                    <div class="alert alert-success" runat="server" visible="false" id="divSuccess">
                                                    <strong>Success !</strong> Invalid email or password.
                                                </div>
                                                <div class="alert alert-danger" runat="server" visible="false" id="divError">
                                                    <strong>Fail !</strong>
                                                    <asp:Literal runat="server" ID="ltrError"></asp:Literal>
                                                </div>
                     <!-- <label>Email Id</label> -->
                    <div class="col-md-8 col-sm-8 input-group">
                      
                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                    <asp:TextBox ID="Txtemail" class="form-control" placeholder=" Email Id " runat="server"></asp:TextBox>

                        <%--<input class="form-control" type="text" id="email" name="email" placeholder=" Email Id " required>--%>
                </div>
               
                
            </div>
            <div class="form-group row col-sm-offset-3">
               
                    <!-- <label>Password</label> -->
                <div class="col-md-8 col-sm-8 input-group">
                    
                    <span class="input-group-addon"><i class="fa fa-key"></i> </span>
                    <asp:TextBox ID="Txtpass" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                    <%--<input class="form-control" type="password"  id="password" name="password" placeholder="Password" required>--%>
                </div>
         
            </div>
                <center>
                    <asp:Button ID="Button1" class="btn btn-default  btn-color1 " runat="server" Text="LOGIN" OnClick="btnLogin_Click"></asp:Button>

                <%--<input type="submit" value="LOGIN" name="save" class="btn btn-default  btn-color1 ">--%>
            </center>
               <center>
                <p class="mgt"><a href="" style="color:#333;">New Here? </a><a href="register.aspx"> <span class="color">Create an account</span></a></p>
               </center>

            </form>

        </div>
    </div>

</div>
</div>
</div>

<script>
    if ('serviceWorker' in navigator) {
        // console.log("Will the service worker register?");
        navigator.serviceWorker.register('service-worker.js')
          .then(function (reg) {

          }).catch(function (err) {

          });
    }
</script>

</body>


</html>