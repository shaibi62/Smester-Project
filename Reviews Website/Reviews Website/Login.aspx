<%@ Page Title="Login as Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Reviews_Website.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <center>
          
                <h2 style="margin-top: 100px" id="title"><%: Title %></h2>
                <br />
                <br />
                <asp:Label  ID="lblFirstLogin" runat="server"></asp:Label>
                <br />
                <asp:Label  ID="lblUser" runat="server" Text="Enter User Name:"></asp:Label>
                <br />
                <asp:TextBox ID="u_name" name="u_name" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblPass" runat="server" Text="Enter User Password:"></asp:Label>
                <br />
                <asp:TextBox ID="password" name="password" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Submit" runat="server" Text="Login" OnClick="Submit_Click" />

        </center>

    </div>

    <script>


</script>

</asp:Content>
