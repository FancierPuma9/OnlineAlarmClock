<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="OnlineAlarmClock.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alarm Clock App</title>
    <link rel="stylesheet" href="cssFiles/Home.css" />
</head>
<body>
    <form runat="server">


        <h1 class="header">Alarm Clock
        </h1>

        <p class="description">
            This alarm clock application runs right here in your browser! 
        The goal of this alarm is to allow the user to customize their alarm in more ways than one.
        Sign-up is free and using the app is as user-friendly as possible.
        </p>

        <div class="loginRegister">
            <asp:Button runat="server" class="loginButton" Text="Login" OnClick="LoginClicked" />
            <asp:Button runat="server" class="registerButton" Text="Register" OnClick="RegisterClicked" />
        </div>



        <footer class="footer">
            <img src="imgs/GitHubIcon.png" />
            Developed By: Jonathan Pross
        </footer>


    </form>
</body>
</html>
