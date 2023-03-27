<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FormsAuthenticationDemo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login Form</h2>
            <asp:Label ID="Lb_UserName" runat="server" Text="UserName"></asp:Label>
            <asp:TextBox ID="Tb_UserName" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="Lb_Password" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="Tb_Password" runat="server"></asp:TextBox>
            <br /><br />
            <asp:CheckBox ID="Cb_RememberMe" runat="server" />
            <asp:Label ID="Lb_RememberMe" runat="server" Text="Remember Me"></asp:Label>
            <br /><br />
            <asp:Button ID="Bt_Login" runat="server" Text="Login" OnClick="Bt_Login_Click" />
            <br /><br />
            <asp:Label ID="Lb_Message" runat="server" Text="Message"></asp:Label>
        </div>
    </form>
</body>
</html>
