<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="INDEX.aspx.cs" Inherits="Remedial_Biblioteca.INDEX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Lista de Uusuarios<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        </div>
    </form>
</body>
</html>
