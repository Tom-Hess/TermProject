<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="history.aspx.cs" Inherits="TermProject.User.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-8 ">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Transaction History</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblFrom" Text="From: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtFrom"></asp:TextBox>
                            <asp:Label runat="server" ID="lblTo" Text="To: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtTo"></asp:TextBox>
                            <asp:Button runat="server" ID="btnGenerate" Text="Generate" />
                        </div>
                        <div>
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
