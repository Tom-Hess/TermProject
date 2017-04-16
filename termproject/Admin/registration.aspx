<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="TermProject.Admin.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Register New Admin</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form2" runat="server">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblName" Text="Name: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblEmail" Text="Email: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblPassword" Text="Password: "></asp:Label>
                            <asp:TextBox runat="server" TextMode="Password" ID="txtPassword"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblConfirm" Text="Confirm Password: "></asp:Label>
                            <asp:TextBox runat="server" TextMode="Password" ID="txtConfirm"></asp:TextBox>
                        </div>
                        <div class="form-group" style="text-align:center">
                            <asp:Button runat="server" ID="btnSubmit" Text="Register" OnClick="btnSubmit_Click"/>
                            <asp:Label runat="server" ID="lblMsg" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <br />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
