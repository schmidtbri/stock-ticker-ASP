<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WeatherByZipSOAP.aspx.cs" Inherits="WeatherByZipSOAP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Zip Code:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Temperature" />
        <br />
        <br />
        Note: The weather API that I used did not include high and low temperatures.</div>
    </form>
</body>
</html>
