<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="TermProject.User.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-8">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Account Information</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblName" Text="Name: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblPassword" Text="Password: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblConfirm" Text="Confirm: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtConfirm"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblEmail" Text="Email Address: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" ID="lblStorage" Text="Storage Space: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtStorage"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnUpdate" Text="Update" />
                            <asp:Label runat="server" ID="lblMsg" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
