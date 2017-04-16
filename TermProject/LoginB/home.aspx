<%@ Page Title="" Language="C#" MasterPageFile="~/LoginB/login.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="TermProject.LoginB.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><strong>Home</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <h3>
                                Welcome to Temple University Cloud Storage Site
                            </h3>
                        </div>
                        <div class="form-group" style="text-align:center">
                            <p>
                                To login to the cloud, click Login
                            </p>
                        </div>
                        <div class="form-group" style="text-align:center"> 
                            <p>
                                To register a new account, click Registration
                            </p>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
