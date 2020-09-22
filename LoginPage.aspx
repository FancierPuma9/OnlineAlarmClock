<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="OnlineAlarmClock.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link rel="stylesheet" href="cssFiles/LoginPage.css" />
</head>
<body>
    <h1 class="header">
        Alarm Clock
    </h1>
    <form id="form1" runat="server">
        <div class="singleField">
            <asp:Label CssClass="textLabel" ID="usernameLabel" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox CssClass="textBox" ID="usernameBox" runat="server"></asp:TextBox>
        </div>
        <div class="singleField">
            <asp:Label CssClass="textLabel" ID="passwordLabel" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox CssClass="textBox" ID="passwordBox" runat="server"></asp:TextBox>
        </div>
        <asp:Button runat="server" CssClass="loginButton" OnClick="LoginClicked" Text="Login" />
        <asp:Button runat="server" CssClass="cancelButton" OnClick="CancelClicked" Text="Return Home" />
    </form>
    <footer class="footer">
        <img src="imgs/GitHubIcon.png"/>
        Developed By: Jonathan Pross
    </footer>
</body>
</html>
