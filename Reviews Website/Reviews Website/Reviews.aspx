<%@ Page Title="Reviews" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="Reviews_Website.Reviews" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3 id="h3" runat="server"></h3>
        <br />
        <center>
            <section>
                <asp:Label ID="lblProductName" runat="server" Text="Search Product by Product Name:"></asp:Label>
                <br />
                <asp:TextBox ID="ProductName" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <br />
                <br />
            </section>
        </center>
        <center>
            <section style="margin-top: 60px">
                <asp:Label ID="lblFetchedName" runat="server" Text=""></asp:Label>
                <h4 ID="FetchedName" runat="server"></h4>
                <asp:Label ID="lblFetchedDescription" runat="server" Text=""></asp:Label>
                <h4 ID="FetchedDescription" runat="server"></h4>
                <img id="FetchedImage" src="/" runat="server" />
            </section>
            <section>
                <h2>Reviews</h2>
                <asp:Label ID="lblReviews" runat="server" Text=""></asp:Label>
            </section>
        </center>

    </main>
</asp:Content>
