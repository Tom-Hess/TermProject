<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="userForum.aspx.cs" Inherits="TermProject.User.WebForm8" %>

<%@ Register Src="~/forum.ascx" TagName="forum" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:forum ID="forum" runat="server" Visible="True" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
