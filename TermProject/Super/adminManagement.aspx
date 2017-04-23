<%@ Page Title="" Language="C#" MasterPageFile="~/Super/Super.Master" AutoEventWireup="true" CodeBehind="adminManagement.aspx.cs" Inherits="TermProject.Super.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Administrator Management</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server" style="text-align: center">
                        <div>
                            <asp:Label runat="server" ID="lblMsg" ForeColor="Red" Text=""></asp:Label>
                        </div>
                        <div>
                            <asp:GridView ID="gvManagement" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False"
                                OnRowDeleting="gvManagement_RowDeleting"
                                OnRowCommand="gvManagement_RowCommand"
                                OnPageIndexChanging="gvManagment_PageIndexChanging" 
                                CellPadding="4" AllowPaging="True" AllowSorting="True" 
                                OnSorting="gvManagement_Sorting" CurrentSortDir="ASC" ForeColor="#333333" GridLines="None"  >
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="AccountID" ReadOnly="true" HeaderText="User ID" SortExpression="Name" />
                                    <asp:BoundField DataField="Name" ReadOnly="true" HeaderText="User Name" SortExpression="Name" />
                                    <asp:BoundField DataField="Email" ReadOnly="true" HeaderText="Email Address" SortExpression="Email" />
                                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" HeaderText="Delete Account" />
                                    <asp:TemplateField HeaderText="Reset Password" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:Button ID="btnReset" runat="server" CausesValidation="false"
                                                CommandName="ResetPassword" Text="Reset Password"
                                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
