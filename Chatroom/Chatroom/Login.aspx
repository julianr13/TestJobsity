<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Chatroom.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtUser" required runat="server" placeholder="User"></asp:TextBox>  <br />
        <asp:TextBox ID="txtPass" required runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
       <br />  <br />
        <asp:Button id="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click"/>
          <br />
        <asp:Button id="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"/>
         <br />
        <asp:Label ID="lblRes" runat="server" ForeColor ="Red" ></asp:Label>
    </div>
    </form>
</body>
</html>
