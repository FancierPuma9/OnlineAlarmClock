<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="OnlineAlarmClock.RegisterPage" %>

<!DOCTYPE html>
<script type="text/javascript">
    function alertBox(infoString) {
        var temp = document.createElement('div');
        temp.setAttribute('class', 'alertbox');
        temp.innerHTML = infoString;
        return temp;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registeration</title>
    <link rel="stylesheet" href="cssFiles/RegisterPage.css" />
</head>
<body>
    <h1 class="header">
        Alarm Clock
    </h1>

    <form id="form1" runat="server">
        <div class="singleField">
            <asp:Label CssClass="textLabel" ID="emailLabel" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox CssClass="textBox" ID="emailBox" runat="server"></asp:TextBox>
        </div>
        <div class="singleField">
            <asp:Label CssClass="textLabel" ID="emailConfirmLabel" runat="server" Text="Confirm Email:"></asp:Label>
            <asp:TextBox CssClass="textBox" ID="emailConfirmBox" runat="server"></asp:TextBox>
        </div>
        <div class="singleField">
            <asp:Label CssClass="textLabel" ID="userNameLabel" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox CssClass="textBox" ID="usernameBox" runat="server"></asp:TextBox>
        </div>
        <div class="singleField">
            <asp:Label CssClass="textLabel" ID="passwordLabel" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox CssClass="textBox" ID="passwordBox" runat="server"></asp:TextBox>
        </div>
        <div class="singleField">
            <asp:Label CssClass="textLabel" ID="confirmPasswordLabel" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox CssClass="textBox" ID="confirmPasswordBox" runat="server"></asp:TextBox>
        </div>
        <asp:Button runat="server" CssClass="submitButton" OnClick="SubmitClicked" Text="Submit" />
        <asp:Button runat="server" CssClass="cancelButton" OnClick="CancelClicked" Text="Return Home" />
    </form>
    <footer class="footer">
        <img src="imgs/GitHubIcon.png"/>
        Developed By: Jonathan Pross
    </footer>
</body>
</html>
