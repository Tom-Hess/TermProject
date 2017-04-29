<%@ Page Title="" Language="C#" MasterPageFile="~/Super/Super.Master" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="TermProject.Super.WebForm4" %>

<%@ Register Src="~/accountSetting.ascx" TagName="accountSetting" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:accountSetting ID="accountSetting" runat="server" Visible="True" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
