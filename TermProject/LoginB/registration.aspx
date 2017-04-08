<%@ Page Title="" Language="C#" MasterPageFile="~/LoginB/login.Master" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="TermProject.LoginB.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Registration</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblName" Text="Name: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblEmail" Text="Email: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblPassword" Text="Password: "></asp:Label>
                            <asp:TextBox runat="server" TextMode="Password" ID="txtPassword"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblConfirm" Text="Confirm Password: "></asp:Label>
                            <asp:TextBox runat="server" TextMode="Password" ID="txtConfirm"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblAccountType" runat="server" Text="Account Type"></asp:Label>
                            &nbsp&nbsp
                            <asp:RadioButtonList runat="server" ID="rblRole">
                                <asp:ListItem Selected="True" Text="User" Value=0></asp:ListItem>
                                <asp:ListItem Text="Admin" Value=1></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblRemember" Text="Create cookie: "></asp:Label>
                            <asp:CheckBox runat="server" ID="chkRemember" />
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
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
</asp:Content>
