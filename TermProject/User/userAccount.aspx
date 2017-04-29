<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="userAccount.aspx.cs" Inherits="TermProject.User.WebForm6" %>

<%@ Register Src="~/accountSetting.ascx" TagName="accountSetting" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:accountSetting ID="accountSetting" runat="server" Visible="True" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
