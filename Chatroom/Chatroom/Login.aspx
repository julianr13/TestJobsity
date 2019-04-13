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
    
        <asp:TextBox ID="txtUser" runat="server" placeholder="User"></asp:TextBox>  <br />
        <asp:TextBox ID="txtPass" runat="server" placeholder="Password"></asp:TextBox>
       <br />  <br />
        <asp:Button id="btnLogin" runat="server" Text="Login"/>
          <br />
        <asp:Button id="btnRegister" runat="server" Text="Register"/>
    </div>
    </form>
</body>
</html>
