<%@ Page Title="" Language="C#" MasterPageFile="~/checkout/checkout.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="TermProject.checkout.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Checkout Error</h1>
    <p></p>
    <table id="ErrorTable">
        <tr>
            <td class="field"></td>
            <td><%=Request.QueryString.Get("ErrorCode")%></td>
        </tr>
        <tr>
            <td class="field"></td>
            <td><%=Request.QueryString.Get("Desc")%></td>
        </tr>
        <tr>
            <td class="field"></td>
            <td><%=Request.QueryString.Get("Desc2")%></td>
        </tr>
    </table>
    <p></p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
