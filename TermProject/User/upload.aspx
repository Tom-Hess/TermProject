<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="TermProject.User.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-8 ">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Upload Files</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:TextBox runat="server" ID="txtPath"></asp:TextBox>
                            <asp:Button runat="server" ID="btnBrowse" Text="Browse" />
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnLogin" Text="Upload" />
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
