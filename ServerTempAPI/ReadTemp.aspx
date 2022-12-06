<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadTemp.aspx.cs" Inherits="ServerTemp.ReadTemp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Server Temperature and Humidity</title>
    <style>
        p {
            font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif
        }
    </style>
</head>
<body>
    <h2 style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif">Server Temp Read File</h2>
    <br />
    <button type="button" onclick="window.location.href='./Default.html'">Home</button><br /><br />
    <button type="button" onclick="window.location.href='./TempChart.aspx'">Temperature and Humidity Chart</button><br />
    
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Font-Names="Courier New" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
