<%@ Page Title="" Language="C#" MasterPageFile="~/LoginB/login.Master" AutoEventWireup="true" CodeBehind="invalid.aspx.cs" Inherits="TermProject.LoginB.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-4 col-md-offset-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Invalid Login</strong></h3>
                </div>
                <div class="panel-body" style="text-align:center">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <p>You account has been deactivated. Contact administrator to activate the account. </p>
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
