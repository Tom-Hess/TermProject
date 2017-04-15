<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="management.aspx.cs" Inherits="TermProject.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Management</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div>
                            <asp:GridView ID="gvManagement" runat="server" AutoGenerateColumns="False" 
                                OnRowCancelingEdit="gvManagement_RowCancelingEdit" 
                                OnRowEditing="gvManagement_RowEditing" 
                                OnRowUpdating="gvManagement_RowUpdating" 
                                OnRowDeleting="gvManagement_RowDeleting"
                                OnRowResetting="gvManagment_RowResetting" 
                                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" >
                                <Columns>
                                    <asp:BoundField DataField="Name" ReadOnly="true" HeaderText="User name" SortExpression="Name" />
                                    <asp:BoundField DataField="Email" ReadOnly="true" HeaderText="Email Address" SortExpression="Email" />
                                    <asp:BoundField DataField="StorageSpace" ReadOnly="true" HeaderText="Storage Capacity" SortExpression="StorageSpace" />
                                    <asp:BoundField DataField="StorageUsed" ReadOnly="true" HeaderText="StorageUsed" SortExpression="StorageUsed" />
                                    <asp:CommandField ButtonType="Button" EditText="Modify" ShowEditButton="True" ShowHeader="True" />
                                    <asp:CommandField ButtonType="Button" EditText="Reset Pasword" ShowEditButton="True" ShowHeader="True" />
                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                </Columns>
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                <RowStyle BackColor="White" ForeColor="#003399" />
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                <SortedDescendingHeaderStyle BackColor="#002876" />
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
