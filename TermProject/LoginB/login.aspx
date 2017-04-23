<%@ Page Title="" Language="C#" MasterPageFile="~/LoginB/login.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TermProject.LoginB.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Login</strong></h3>
                </div>
                <div class="panel-body" style="text-align:center">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblEmail" Text="Email Address: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblPassword" Text="Password: "></asp:Label>
                            <asp:TextBox runat="server" TextMode="Password" ID="txtPassword"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblRemember" Text="Remember me "></asp:Label>
                            <asp:CheckBox runat="server" ID="chkRemember" />
                        </div>
                        <div class="form-group" style="text-align:center">
                            <asp:Button runat="server" ID="btnLogin" Text="Log In" OnClick="btnLogin_Click" />
                            <br />
                            <asp:Label runat="server" ID="lblMsg" Text="" ForeColor="#FF3300"></asp:Label>

                        </div>
                        <br />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <p>
        For testing purpose only: ID: user@user, password: user. ID: admin@admin, password: admin. ID: super@super, password: super.
    </p>
</asp:Content>
