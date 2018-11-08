<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryInfo.aspx.cs" Inherits="A3RupinderSingh.A3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
    background-color: lightskyblue;
}
        h1,h2,h3 {
    color: red;
    font-family: "Freestyle Script";
    font-size:30px;
}

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1>Select the Category from the list below</h1>
                <asp:ListBox ID="Category" runat="server" Height="169px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="246px" AutoPostBack="True"></asp:ListBox><br /><br />
                <h3>Select the product from the dropdown</h3>
                <asp:DropDownList ID="Product" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="196px">
                </asp:DropDownList><br /><br />
                <h2>Table below is the orders for the Selected product</h2>
                <asp:GridView ID="order" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
