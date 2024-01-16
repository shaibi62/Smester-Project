<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Reviews_Website.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">

        <center>
            <h3 style="margin-top: 100px; margin-bottom: 100px">DASHBOARD of Admin</h3>

            <h2>Add Product <span style="font-size: 15px">for Reviews</span></h2>
            <br />
            <br />
            <asp:Label ID="lblFirstLogin" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblProductName" runat="server" Text="Enter Product Name:"></asp:Label>
            <br />
            <asp:TextBox ID="ProductName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblProductDescription" runat="server" Text="Enter Product Description:"></asp:Label>
            <br />
            <asp:TextBox ID="ProductDescription" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblProductImage" runat="server" Text="Select Product Image:"></asp:Label>
            <br />
            <asp:FileUpload id="image" runat="server" />
            <br />
            <br />
            <asp:Button ID="btnAdd" runat="server" Text="Add Now" OnClick="btnAdd_Click" />
            <br />
            <asp:Label ID="lblShow" runat="server" Text=""></asp:Label>
            <br />
            
        </center>


    </main>

</asp:Content>
