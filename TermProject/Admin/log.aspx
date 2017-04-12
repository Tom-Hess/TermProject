<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="log.aspx.cs" Inherits="TermProject.Admin.WebForm2" %>
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
                            <asp:Label runat="server" ID="lblEmail" Text="Email Address: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                            <asp:Label runat="server" ID="lblFrom" Text="From: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtFrom"></asp:TextBox>
                            <asp:Label runat="server" ID="lblTo" Text="To: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtTo"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnFind" Text="Find" OnClick="btnFind_Click" />
                            <asp:Label runat="server" ID="lblMsg" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <br />
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
