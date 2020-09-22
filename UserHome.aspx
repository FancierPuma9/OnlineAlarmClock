<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="OnlineAlarmClock.UserHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Your Home</title>
    <link rel="stylesheet" href="cssFiles/UserHome.css" />
    <script type="text/javascript" src="jsFiles/UserHome.js"></script>
</head>
<body onload="JavaScript:onloadTimer()">
    
    <h1 class="header">
        Alarm Clock
    </h1>
    <div  class="alarmSet">
        <div class="chunk">
            <label>Current Time: </label>
            <label id="curTime">curTimeHere</label>
        </div>
        <div class="chunk">
            <label>Choose Alarm Time: </label>
            <asp:Label runat="server" ID="alarmTime">alarmTimeHere</asp:Label>

            <button id="upTime" onclick="upClicked()" >/\</button>
            <button id="downTime" onclick="downClicked()">\/</button>
        </div>
        <form id="optionsForm" runat="server">
            <asp:ScriptManager ID="scriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
            <div class="chunk">
                <asp:Label runat="server">Do you want to include a math problem?</asp:Label>
                <asp:CheckBox runat="server" ID="mathCheck" />
            </div>
            <div class="chunk">
            <asp:Label runat="server" Text="Alarm Sound: " />
            <asp:DropDownList runat="server" ID="soundList" />
                </div>
            <div class="chunk">
            <asp:Label runat="server" Text="Alarm Name: " />
            <asp:TextBox runat="server" ID="alarmName" />
                </div>
            <div class="chunk">
            <asp:Label runat="server" Text="Alarm Description: " />
            <asp:TextBox runat="server" ID="alarmDescription" />
                </div>
            <asp:Button runat="server" ID="resetButton"  Text="Reset Settings" />
            <asp:Button runat="server" ID="saveButton" OnClick="saveButton_Click" Text="Save Alarm"/>
            
        </form>
    </div>
    <div class="alarmList">
        <asp:Label runat="server" ID="list" Text="hmmmm"/>
        
    </div>
    <footer class="footer">
        <img src="imgs/GitHubIcon.png"/>
        Developed By: Jonathan Pross
    </footer>
</body>
</html>


