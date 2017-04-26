<%@ Page Title="" Language="C#" MasterPageFile="~/checkout/checkout.Master" AutoEventWireup="true" CodeBehind="complete.aspx.cs" Inherits="TermProject.checkout.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Checkout Complete</h1>
    <p></p>
    <h3>Payment Transaction ID:</h3>
    <asp:Label ID="TransactionId" runat="server"></asp:Label>
    <p></p>
    <h3>Thank You!</h3>
    <p></p>
    <hr />
    <asp:Button ID="Continue" runat="server" Text="Continue Shopping" OnClick="Continue_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
