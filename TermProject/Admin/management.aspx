<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="management.aspx.cs" Inherits="TermProject.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-8 ">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Management</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div>
                            <asp:GridView ID="gvManagement" runat="server"></asp:GridView>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
