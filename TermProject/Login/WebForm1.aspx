<%@ Page Title="" Language="C#" MasterPageFile="~/Login/login.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TermProject.Login.WebForm1" %>

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
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:label runat="server" id="lblName" text="Email Address: "></asp:label>
                            <asp:textbox runat="server" id="txtName"></asp:textbox>
                        </div>
                        <div class="form-group">
                            <asp:label runat="server" id="lblPassword" text="Password: "></asp:label>
                            <asp:textbox runat="server" textmode="Password" id="txtPassword"></asp:textbox>
                        </div>
                        <div class="form-group">
                            <asp:label runat="server" id="lblRemember" text="Remember me: "></asp:label>
                            <asp:checkbox runat="server" id="chkRemember" />
                        </div>
                        <div class="form-group">
                            <asp:radiobutton id="rbAdmin" runat="server" text="Cloud Administrator" />
                            <asp:radiobutton id="rbUser" runat="server" text="Cloud User" />
                        </div>
                        <div class="form-group">
                            <asp:button runat="server" id="btnLogin" text="Log In" onclick="btnLogin_Click" />
                            <asp:label runat="server" id="lblMsg" text="" forecolor="#FF3300"></asp:label>
                        </div>
                        <br />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
