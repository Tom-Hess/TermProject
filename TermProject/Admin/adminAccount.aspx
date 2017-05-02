<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="adminAccount.aspx.cs" Inherits="TermProject.Admin.WebForm4" %>

<%@ Register Src="~/accountSetting.ascx" TagName="accountSetting" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:accountSetting ID="accountSetting" runat="server" Visible="True" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <p>
        This page utilizes custom user control
    </p>
</asp:Content>
