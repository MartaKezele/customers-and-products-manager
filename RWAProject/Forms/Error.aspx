<%@ Page Title="" Language="C#" MasterPageFile="~/Forms/Layout.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="RWAProject.Forms.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 style="color: red">Error</h2>
    <h3 id="errorMessage" runat="server" style="color: red"></h3>
    <asp:HyperLink ID="homePage" runat="server" Text="< Home page" NavigateUrl="~/Home/Index"></asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsContent" runat="server">
</asp:Content>
